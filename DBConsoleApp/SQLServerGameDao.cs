using GameDal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConsoleApp
{
     class SQLServerGameDao : GameDao
    {
        public SQLServerGameDao(string connectionString) :
        base
        (
            () => new SqlConnection(connectionString),
            "@",
            "+"
        )
        {
        }
    }
}
