using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class ScientificPublication : Document
    {
        public ScientificPublication
            (
            int id,
            string ubication,
            string title,
            int publicationYear,
            Person [] authors,
            string universityName,
            string description
            ) : base(id, ubication, title, publicationYear)
        {
            Authors = authors;
            UniversityName = universityName;
            Description = description;
        }

        public Person[] Authors { get; set; }
        public string UniversityName { get; set; }
        public string Description { get; set; }
    }
}
