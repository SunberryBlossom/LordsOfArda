using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda.Beings.Races.Elves.Quendi.Eldar.Teleri.Sindar
{
    internal class Sindar : Eldar
    {
        string _familyTree = "Thingol";

        public string FamilyTree
        {
            get { return _familyTree; }
        }

        public Sindar(string name, int age, string title, string origin) : base(name, age, title, origin)
        {
        }
    }
}
