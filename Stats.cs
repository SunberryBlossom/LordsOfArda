using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    public class Stats
    {
            public int Strength { get; set; }
            public int Agility { get; set; }
            public int Intelligence { get; set; }
            public int Endurance { get; set; }

            public Stats(int strength, int agility, int intelligence, int endurance)
            {
                Strength = strength;
                Agility = agility;
                Intelligence = intelligence;
                Endurance = endurance;
            }

            public override string ToString()
            {
                return $"STR: {Strength}, AGI: {Agility}, INT: {Intelligence}, END: {Endurance}";
            }
        }
    
}
