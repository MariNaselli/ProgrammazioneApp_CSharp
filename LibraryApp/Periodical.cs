using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
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
            string mediaType
            ) : base(id, ubication, title, publicationYear)
        {
         
            IssueNumber = issueNumber;
            IssnCode = issnCode;
            MediaType = mediaType;
        }
        public string IssueNumber { get; set; }
        public string IssnCode { get; set; }
        public string MediaType { get; set; }

    }
}
