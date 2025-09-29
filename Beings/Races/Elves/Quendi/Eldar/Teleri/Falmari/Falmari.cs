using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda.Beings.Races.Elves.Quendi.Eldar.Teleri.Falmari__Sea_elves_
{
    internal class Falmari : Eldar
    {
        string _familyTree = "Olwë";

        public string FamilyTree
        {
            get { return _familyTree; }
        }

        public Falmari(string name, int age, string title, string origin) : base(name, age, title, origin)
        {
        }
    }
}
