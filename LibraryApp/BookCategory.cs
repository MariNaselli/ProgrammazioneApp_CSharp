using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryApp
{
    public class BookCategory
    {
        public string Name { get; }

        //Tiene una propiedad pública Name que solo tiene un getter,
        //lo que significa que solo puede ser leída desde fuera de la clase.

        private BookCategory(string name)
        {
            Name = name;
        }

        //Tiene un constructor privado que acepta un parámetro name.
        //Esto significa que los objetos de tipo BookCategory solo se pueden crear desde dentro de la clase.

        public override string ToString() =>
        Name;
        //Sobrescribe el método ToString() para devolver el nombre de la categoría.

        // Categorías predefinidas
        public static BookCategory Mystery { get; } = new BookCategory("Mystery");
        public static BookCategory Adventure { get; } = new BookCategory("Adventure");
        public static BookCategory Children { get; } = new BookCategory("Children");
        public static BookCategory Thriller { get; } = new BookCategory("Thriller");
        public static BookCategory ScienceFiction { get; } = new BookCategory("Science Fiction");


        private static Dictionary<string, BookCategory> _wellKnownCategories;

        static BookCategory()
        {
            _wellKnownCategories = new Dictionary<string, BookCategory>(StringComparer.InvariantCultureIgnoreCase);

            // Agregar las categorías predefinidas al diccionario
            PropertyInfo[] staticProps = typeof(BookCategory)
                .GetProperties(BindingFlags.Public | BindingFlags.Static);

            foreach (PropertyInfo prop in staticProps)
            {
                if (prop.PropertyType == typeof(BookCategory))
                {
                    BookCategory category = (BookCategory)prop.GetValue(null)!;
                    _wellKnownCategories.Add(category.Name, category);
                }
            }
        }

        public static BookCategory GetCategory(string categoryName)
        {
            ArgumentNullException.ThrowIfNull(categoryName, nameof(categoryName));
            if (_wellKnownCategories.TryGetValue(categoryName, out var category))
            {
                return category;
            }

            // Si la categoría no está predefinida, lanzar una excepción o devolver nulo según lo prefieras
            throw new ArgumentException($"Category '{categoryName}' not found.");

        }

        // Método para agregar una nueva categoría
        public static void AddCategory(string categoryName)
        {
            if (!_wellKnownCategories.ContainsKey(categoryName))
            {
                var newCategory = new BookCategory(categoryName);
                _wellKnownCategories.Add(categoryName, newCategory);
            }
        }

        // Método para eliminar una categoría
        public static void RemoveCategory(string categoryName)
        {
            _wellKnownCategories.Remove(categoryName);
        }

        // Método para obtener todas las categorías
        public static List<BookCategory> GetAllCategories()
        {
            return _wellKnownCategories.Values.ToList();
        }

        // Método para buscar libros por categoría
        public static List<Book> GetBooksByCategory(string categoryName)
        {
            // Supongamos que tienes una lista de libros llamada "allBooks"
            List<Book> allBooks = new List<Book>(); // Supongamos que tienes una lista de libros

            // Filtrar los libros cuyas categorías coincidan con el nombre de categoría proporcionado
            var booksInCategory = allBooks.Where(book => book.Categories.Any(category => category.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase))).ToList();

            return booksInCategory;
        }


    }
}

