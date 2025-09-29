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
        private string _familyTree;

        public bool IsCalaquendi 
        {
            get { return _isCalaquendi; } 
            set { Console.WriteLine("All of the Noldors are considered Calaquendi."); } 
        }

        public string FamilyTree 
        { 
            get { return _familyTree; } 
            
            set
            {
                if(value == "Fëanor" || value == "Fingolfin" || value == "Finarfin")
                {
                    _familyTree = value;
                }
                else
                {
                    Console.WriteLine("The three households of the Noldor are:\nFëanor\nFingolfin\nFinarfin\n\nPlease try assign one of these as your Family Tree.");
                }
            }
            
        }

        public Noldor(string familyTree, string name, int age, string title, string origin) : base(name, age, title, origin)
        {
            FamilyTree = familyTree;
        }
    }
}
