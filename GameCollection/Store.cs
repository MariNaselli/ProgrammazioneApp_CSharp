using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection
{
    public class Store
    {
        public enum StoreType
        {
            Online,
            Physical,
        }
        public Store(int id, string name, StoreType type)
        {
            Id = id;
            Name = name;
            Type = type;//tienda fisica o en linea.. 
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public StoreType Type { get; set; }
    }
}
