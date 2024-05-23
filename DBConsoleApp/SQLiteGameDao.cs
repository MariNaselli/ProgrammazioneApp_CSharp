using GameDal;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConsoleApp
{
    class SQLiteGameDao : GameDao
    {
        public SQLiteGameDao(string connectionString) :
       base
       (
           () => new SQLiteConnection(connectionString),
           ":",
           "||"
       )
        {
        }
    }
}
