using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection
{
    public class User
    {
        public User(int id, string username, List<Game> gameCollection)
        {
            Id = id;
            Username = username;
            GameCollection = gameCollection;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public List<Game> GameCollection { get; set; }
    }
}
