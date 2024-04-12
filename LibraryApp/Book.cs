using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryApp
{
    public class Book : Document
    {
        public Book
            (
            int id,
            string ubication,
            string title,
            int publicationYear,
            Person[] authors,
            Person editor,
            int editionNumber,
            string isbnCode,
            List<BookCategory> categories
            ) : base(id, ubication, title, publicationYear)
        {
            Authors = authors;
            Editor = editor;
            EditionNumber = editionNumber;
            IsbnCode = isbnCode;
            Categories = categories;
        }

        public Person[] Authors { get;}
        public Person Editor { get; }
        public int EditionNumber { get; }
        public string IsbnCode { get; }
        public List<BookCategory> Categories { get; }

    }
}
