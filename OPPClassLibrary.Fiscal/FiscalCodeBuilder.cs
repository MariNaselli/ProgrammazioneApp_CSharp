using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OPPClassLibrary.Fiscal
{
    public class FiscalCodeBuilder
    {

        public static string BuildFiscalCode(Person person)
        {
            // 1. Obtener los primeros tres caracteres del apellido
            string lastNamePart = GetLastNamePart(person.LastName);

            // 2. Obtener los primeros tres caracteres del nombre
            string firstNamePart = GetFirstNamePart(person.FirstName);

            // 3. Tomar los dos últimos dígitos del año de nacimiento
            string yearPart = (person.DateOfBirth.Year).ToString().Substring(2, 2);

            // 4. Asociar una letra del alfabeto a cada mes y usarla para representar el mes de nacimiento
            string monthPart = GetMonthPart(person.DateOfBirth.Month);

            // 5. Tomar el día de nacimiento y ajustarlo si es necesario para representar el género
            string dayPart = GetDayPart(person.DateOfBirth.Day, person.Gender);

            // 6. Obtener el código del comune o del país de nacimiento
            string birthPlacePart = GetBirthPlacePart(person.PlaceOfBirth);

            // 7. Calcular el carácter de control
            string controlCharacter = CalculateControlCharacter($"{lastNamePart}{firstNamePart}{yearPart}{monthPart}{dayPart}{birthPlacePart}");

            // 8. Combinar todas las partes para formar el código fiscal completo
            string fiscalCode = $"{lastNamePart}{firstNamePart}{yearPart}{monthPart}{dayPart}{birthPlacePart}{controlCharacter}";
            //string fiscalCode = $"{lastNamePart}{firstNamePart}{yearPart}{monthPart}{dayPart}{birthPlacePart}";

            fiscalCode = SanitizeFiscalCode(fiscalCode);

            return fiscalCode.ToUpper(); // Convertir a mayúsculas y devolver el código fiscal
        }

        // Función para obtener los primeros tres caracteres del apellido
        private static string GetLastNamePart(string lastName)
        {
            // Eliminar espacios y convertir a mayúsculas
            lastName = lastName.Trim().ToUpper();

            // Remover vocales y caracteres no alfabéticos
            string consonants = new string(lastName.Where(c => char.IsLetter(c) && !"AEIOU".Contains(c)).ToArray());

            // Si hay menos de 3 consonantes, agregar vocales según sea necesario
            if (consonants.Length < 3)
            {
                string vowels = new string(lastName.Where(c => "AEIOU".Contains(c)).ToArray());
                consonants += vowels.Substring(0, 3 - consonants.Length);
            }

            // Tomar los primeros 3 caracteres (o menos si el nombre tiene menos de 3 consonantes)
            return consonants.Substring(0, 3);
        }

        // Función para obtener los tres caracteres del nombre 
        private static string GetFirstNamePart(string firstName)
        {
            // Eliminar espacios y convertir a mayúsculas
            firstName = firstName.Trim().ToUpper();

            // Remover vocales y caracteres no alfabéticos
            string consonants = new string(firstName.Where(c => char.IsLetter(c) && !"AEIOU".Contains(c)).ToArray());
            string vowels = new string(firstName.Where(c => "AEIOU".Contains(c)).ToArray());
            

            string firstNamePart = consonants.Length > 3 ?
                          string.Concat(consonants[0], consonants[2], consonants[3]) :
                          consonants;            

            // Si aún no hay 3 consonantes, agregar vocales según sea necesario
            if (firstNamePart.Length < 3)
            {

                firstNamePart += vowels;
            }

            firstNamePart = firstNamePart.Substring(0, 3);

            return firstNamePart;
        }

        // Función para obtener la letra correspondiente al mes de nacimiento
        private static string GetMonthPart(int month)
        {
            string[] monthCodes = { "A", "B", "C", "D", "E", "H", "L", "M", "P", "R", "S", "T" };
            return monthCodes[month - 1]; // Restamos 1 porque los meses comienzan desde 1 en lugar de 0
        }

        // Función para obtener el día de nacimiento ajustado para representar el género
        private static string GetDayPart(int day, Gender gender)
        {
            if (gender == Gender.Female)
            {
                day += 40;
            }
            return day.ToString("D2"); // Formatear como dos dígitos
        }

        // Función para obtener el código del comune o del país de nacimiento
        private static string GetBirthPlacePart(string placeOfBirth)
        {
            string birthPlacePart = "XXXX";
            if (placeOfBirth.Trim().ToUpper() == "ARGENTINA")
            {
                birthPlacePart = "Z600";
            }
            return birthPlacePart; // Placeholder para el código del comune o del país de nacimiento
        }

        // Función para calcular el carácter de control
        private static string CalculateControlCharacter(string partialFiscalCode)
        {
            // Aquí deberías implementar la lógica para calcular el carácter de control
            // Como es una implementación específica de cálculo, basada en el algoritmo proporcionado, debes seguir las reglas detalladas en la documentación
            // Puedes usar la lógica de conversión y cálculo proporcionada en la documentación
            // Por ahora, vamos a devolver un valor predeterminado
            return "X"; // Placeholder para el carácter de control
        }

        private static string SanitizeFiscalCode(string? fiscalCode)
        {
            if (fiscalCode is null)
            {
                throw new ArgumentNullException(nameof(fiscalCode));
            }
            if (fiscalCode.Length != 16)
            {
                throw new ArgumentException("Fiscal code must have length 16");
            }
            return fiscalCode;
        }
    }
}
