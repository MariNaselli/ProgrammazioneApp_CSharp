using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Person
    {
        public Person(string lastName, string name)
        {
            LastName = lastName;
            Name = name;
            
        }

        public string LastName { get; set; }
        public string Name { get; set; }


        
    }


}
    
