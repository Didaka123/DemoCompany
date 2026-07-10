using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCompany
{
    internal class Person
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public int Age { get; set; }

        public Person(string name, string family, int age)
        {
             Name = name;
             Family = family;
             Age = age;
        }
        
    }
}
