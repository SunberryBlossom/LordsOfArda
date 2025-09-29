using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda.Beings.Races.Elves.Quendi.Eldar.Noldor
{
    internal class Noldor : Eldar
    {
        private bool _isCalaquendi = true;

        public bool IsCalaquendi 
        {
            get { return _isCalaquendi; } 
            set { Console.WriteLine("All of the Noldors are considered Calaquendi."); } 
        }

        public Noldor(string name, int age, string title, string origin) : base(name, age, title, origin)
        {

        }
    }
}
