using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    public class CharacterMaster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public string Gender { get; set; }
        public string Title { get; set; } = "The Brave";
        public string Birthplace { get; set; }

        public CharacterMaster(string name, string gender, string birthplace)
        {
            Name = name;
            Gender = gender;
            Birthplace = birthplace;
            // Base health, can be modified later with race/species/whatever
            Health = 100;
        }
    }
}
