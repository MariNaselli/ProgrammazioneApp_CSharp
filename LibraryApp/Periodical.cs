using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{

    public enum MediaType
    {
        Print,
        Digital
    }
    public class Periodical : Document
    {
        public Periodical
            (
            int id,
            string ubication,
            string title,
            int publicationYear,
            string issueNumber,
            string issnCode,
            MediaType mediaType
            ) : base(id, ubication, title, publicationYear)
        {
         
            IssueNumber = issueNumber;
            IssnCode = issnCode;
            MediaType = mediaType;
        }
        public string IssueNumber { get; set; }
        public string IssnCode { get; set; }
        public MediaType MediaType { get; set; }

    }
}
