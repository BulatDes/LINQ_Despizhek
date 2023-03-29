using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_DB
{
     class Person
    {
        public string Name { get; set; }
        public string Fam { get; set; }
        public string Otch { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }

        public Person(string name,string fam,string otch,int age,double weight)
        {
            Name= name;
            Fam = fam;
            Otch= otch;
            Age = age;
            Weight = weight;
        }
    }
}
