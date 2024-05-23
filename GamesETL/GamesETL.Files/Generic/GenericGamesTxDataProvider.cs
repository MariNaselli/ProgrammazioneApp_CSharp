using GamesETL.Common;
using GamesETL.Core;
using GamesETL.Models;
using Microsoft.Extensions.Logging;
using MoreLinq;
using System.Globalization;
using System.Text;

namespace GamesETL.Files.Generic;
public class GenericGamesTxDataProvider : IGamesTxDataProvider
{
    private static Dictionary<string, string> StoreAliases;
    static GenericGamesTxDataProvider()
    {
        StoreAliases =
            new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"epic", "Epic Store"},
                {"eshop", "Nintendo Shop"},
                {"nintendo", "Nintendo Shop"},
                {"xbox","Microsoft Store" },
                {"microsoft","Microsoft Store" },
            };
    }

    private readonly string _sourceFile; //ruta del archivo para leer las transacciones
    private readonly ILogger _logger;
    public GenericGamesTxDataProvider
    (
        string sourceFile,
        ILogger<GenericGamesTxDataProvider> logger
    )
    {
        _sourceFile = sourceFile ?? throw new ArgumentException(nameof(sourceFile));
        _logger = logger ?? throw new ArgumentException(nameof(logger));
    }
    public async ValueTask<GameTxImportData[]> GetGamesTxAsync() //metodo p/obtener las transcacciones de los juegos
    {
        //bool IsSeparetorLine(string s) => //toma una cadena y devuelve un booleano
        //    s.StartsWith('-') //verifica si una línea es un separador válido y empieza en - termina en - y mayor a 9
        //    && s.EndsWith("-")
        //    && s.Length > 9;

        bool IsSeparetorLine(string line) =>
            line
            .Trim()
            .Apply(
                trimmedLine =>
                    trimmedLine.StartsWith('-')
            && line.EndsWith("-")
            && line.Length > 9
        );

        if (!File.Exists(_sourceFile)) //se verifica si el archivo fuente no existe en la ruta especificada
        {
            _logger.LogError("File{sourceFile} does not exist", _sourceFile);
            throw new FileNotFoundException("");
        }
        var lines = await File.ReadAllLinesAsync(_sourceFile);
        //se lee de forma asincronica todas las lineas del archivo fuente especificado y se almacena en la 
        //variable lines
        return
        lines
            .SkipUntil(IsSeparetorLine)//Se omite/salta las lineas de archivo hasta encontrar una linea que cumpla con la condicion
            .Where(line => line.HasText())
            //.Where(line => !string.IsNullOrEmpty(line))//se filtran lineas para eliminar las vacias o nulas
            //.Where(line => !line.TrimStart().StartsWith('#'))//se filtran las lineas para eliminar las que comiencen con # (comentario en el archivo) y se recortan los espacios en blanco al principio de la linea
            .Split(IsSeparetorLine)//se separan las lineas en bloques donde cada bloque comienza y termina con la linea separadora 
            .Select(b => BuildGameTxFromLines(b, _logger))//para cada bloque de lineas se llama a la funcion b.. para construir un objeto GameTxImportData
            .ToArray();//Finalmente convierte un resultado en un array de objetos GameTxImportData
    }
    private static GameTxImportData BuildGameTxFromLines
        (
        IEnumerable<string> lines,
        ILogger logger
        )
    {
        (string key, string value) ExtractKeyAndValue(string line)
        {
            int pos = line.IndexOf(':');

            if (pos < 1)
            {
                logger.LogError($"Line '{line}' is missing :", line);
                throw new Exception($"Line '{line}' is missing :");
            }

            string key = line.Substring(0, pos);
            string value = line.Substring(pos + 1);

            return (key, value.Trim());
        }


        DateOnly ToDateOnly(string value) =>
            DateOnly.TryParseExact(value.Trim(), "yyyy,MM,DD", out DateOnly result)
            ? result
            : throw new Exception("Invalid acquire date");

        decimal ToDecimal(string value) =>
            decimal.TryParse(value, CultureInfo.InvariantCulture, out decimal result)
            ? result
            : throw new Exception("Invalid price");

        string GetStoreAlias(string? alias) =>
            StoreAliases
            .TryGetValue(
                alias?.GetNonNullOrThrow("Store")!,
                out string? storeAlias
                )
            ? storeAlias!
            : alias!;

        string? title = null;
        DateOnly? acquireDate = null;
        decimal? price = null;
        string? store = null;
        string? launcher = null;
        string? platform = null;
        string? media = null;
        string? gameId = null;
        string? masterGameId = null;

        ISet<string> propSet =
            new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

        foreach (var line in lines.Where(line => line.HasText()))
        {
            var (key, value) = ExtractKeyAndValue(line);

            if (propSet.Contains(key))
            {
                throw new Exception($"Property '{key}' already set");
            }
            propSet.Add(key);

            if (key.EqualsIgnoreCase("title"))
            {
                title = value;
            }

            if (key.EqualsIgnoreCase("acquire Date"))
            {
                acquireDate = ToDateOnly(value);
            }

            if (key.EqualsIgnoreCase("acquire Price"))
            {
                price = ToDecimal(value);
            }

            else if (key.EqualsIgnoreCase("store"))
            {
                store = value;
            }
            else if (key.EqualsIgnoreCase("launcher"))
            {
                launcher = value;
            }
            else if (key.EqualsIgnoreCase("platform"))
            {
                platform = value;
            }
            else if (key.EqualsIgnoreCase("media"))
            {
                media = value;
            }
            else if (key.EqualsIgnoreCase("gameId"))
            {
                gameId = value;
            }
            else if (key.EqualsIgnoreCase("masterGameId"))
            {
                masterGameId = value;
            }

            else
            {
                logger.LogError("Invalid property {property}", key);
                throw new Exception($"Invalid Property {key}");

            }
        }
        return
        new GameTxImportData
       (
       Title: title.GetValueOrThrow(() => ("Missing t"), x => !x.HasText()),
       AcquireDate: acquireDate.GetValueOrThrow(() => "Missing Acquire Data")!.Value,
       Price: price.GetValueOrThrow(() => "Missing Price")!.Value,
       Store: GetStoreAlias(store),
       Launcher: launcher.GetValueOrThrow(() => "Missing Launcher"),
       Platform: platform.GetValueOrThrow(() => "Missing Launcher"),
       Media: media ?? "Digital",
       GameId: gameId ?? BuildGameIdFromTitle(title!),
       MasterGameId: masterGameId
        );

    }

    private static string BuildGameIdFromTitle(string title)
    {
        string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return
                stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }

        title = RemoveDiacritics(title);

        const char minus = '-';

        char[] slugChars = new char[title.Length];

        int j = 0;
        bool lastCharIsMinus = true;
        for (int i = 0; i < title.Length; i++)
        {
            char c = title[i];
            if (char.IsLetterOrDigit(c))
            {
                slugChars[j] = char.ToLower(c);
                j++;
                lastCharIsMinus = false;
            }
            else if (char.IsWhiteSpace(c) || c == minus)
            {
                if (!lastCharIsMinus)
                {
                    slugChars[j] = minus;
                    j++;
                    lastCharIsMinus = true;
                }
            }
        }

        if (j > 0 && slugChars[j - 1] == minus)
        {
            --j;
        }
        return new string(slugChars, 0, j);

    }
}



//Declaro variables para almacenar los diferentes campos
//Los campos se inicializan con valores predeterminados.

// aca puedo hacer game= new GameTxImportData meter abajo todo como null y abajo hacer
//las excepciones de todo y retornar game.
//string title = "";
//DateOnly acquireDate = default;
//decimal price = 0.0m;
//string store = "";
//string launcher = "";
//string platform = "";
//string media = "digital";
//string gameId = "";
//string? masterGameId = null;

// 012345678
// title  :  cippalippa
//foreach (var line in lines)
//{
//    int pos = line.IndexOf(':');
//    if (pos < 1)
//    {
//        throw new Exception($"Line {line}is missing :");
//    }
//    string key = line.Substring(0, pos).Trim();

//    string value = line.Substring(pos + 1).Trim();

//    //Para cada línea, se busca el índice del primer carácter ":".
//    //Luego, se divide la línea en una clave(key) y un valor(value)
//    //basado en la posición del ":".
//    //Se eliminan los espacios en blanco alrededor de la clave y el valor utilizando el método Trim().

//if (string.Equals(key, "Title", StringComparison.InvariantCultureIgnoreCase))
//{
//    title = value;
//}
//Se comparan las claves obtenidas de cada línea con cadenas específicas
//ignorando las diferencias de mayúsculas y minúsculas.
//Dependiendo de la clave encontrada, se asigna el valor correspondiente a la variable apropiada.

//if (string.Equals(key, "Acquire Date", StringComparison.InvariantCultureIgnoreCase))
//{
//    if (!DateOnly.TryParse(value, out acquireDate))
//    {
//        throw new Exception($"Invalid Date :{value}");
//    }
//}

//if (string.Equals(key, "Price", StringComparison.InvariantCultureIgnoreCase))
//{
//    if (!decimal.TryParse(value, CultureInfo.InvariantCulture, out price))
//    {
//        throw new Exception($"Invalid Price :{value}");
//    }

//    //convierte una cadena en un decimal
//}

//if (string.Equals(key, "Store", StringComparison.InvariantCultureIgnoreCase))
//{
//    store = value;
//}

//if (string.Equals(key, "Launcher", StringComparison.InvariantCultureIgnoreCase))
//{
//    launcher = value;
//}

//if (string.Equals(key, "Platform", StringComparison.InvariantCultureIgnoreCase))
//{
//    platform = value;
//}

//if (string.Equals(key, "Media", StringComparison.InvariantCultureIgnoreCase))
//{
//    // Verifica si el valor proporcionado en el archivo es diferente de digital
//    if (!string.Equals(value, "digital", StringComparison.InvariantCultureIgnoreCase))
//    {
//        media = value;
//    }
//}

//if (string.Equals(key, "Game Id", StringComparison.InvariantCultureIgnoreCase))
//{
//    if (!string.IsNullOrEmpty(value))
//    {
//        gameId = value; // Asigno el valor solo si no es nulo ni vacío
//    }
//}

//if (string.Equals(key, "Master Game Id", StringComparison.InvariantCultureIgnoreCase))
//{
//    masterGameId = value; // Asigno el valor directamente (puede ser nulo)
//}
