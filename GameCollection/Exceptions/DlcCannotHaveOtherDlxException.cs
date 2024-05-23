using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Exceptions
{
    public class DlcCannotHaveOtherDlcException : Exception
    {
        public DlcCannotHaveOtherDlcException(string? message) : base(message)
        {
        }
    }
}
