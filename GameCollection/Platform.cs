using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection
{
    public class Platform
    {
        public enum PlatformType
        {
            Console,
            PC,
            Mobile,
 
        }
        public Platform(int id, string name, PlatformType type)
        {
            Id = id;
            Name = name; //Xbox,PlayStation,Pc, etc
            Type = type; //consola",pc,móvil, et
        }

        public int Id {  get; set; }
        public string Name { get; set; }
        public PlatformType Type { get; set; }


    }
}
