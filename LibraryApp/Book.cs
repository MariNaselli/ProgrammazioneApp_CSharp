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
            string[] genres
            ) : base(id, ubication, title, publicationYear)
        {
            Authors = authors;
            Editor = editor;
            EditionNumber = editionNumber;
            IsbnCode = isbnCode;
            Genres = genres;
        }

        public Person[] Authors { get; set; }
        public Person Editor { get; set; }
        public int EditionNumber { get; set; }
        public string IsbnCode { get; set; }
        public string[] Genres { get; set; }

    }
}
