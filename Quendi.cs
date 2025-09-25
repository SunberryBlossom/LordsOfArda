using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    internal class Quendi // What should this have access wise? internal good?
    {
        // Properties-------------------------------------------------
        public string Name { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Gender { get; set; }
        public string Origin { get; set; }

        // Constructor-----------------------------------------------
        public Quendi(string name, int age, string title, string origin) 
        { 
            Name = name;
            Age = age;
            Title = title;
            Origin = origin;
        }
        
        // Methods----------------------------------------------------
        public void Introduce()
        {
            Console.WriteLine($"Grettings. I am {Name}, Elven {Title} of {Origin}. I have roamed these lands for {Age} years.");
        }
    }
}