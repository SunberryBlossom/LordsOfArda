using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda.Monsters
{
    abstract class Monsters
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackStats { get; set; }
        public int DefenseStats { get; set; }
        public int MonsterLevel { get; set; }

        protected Monsters(string name, int health, int attackStats, int defenseStats, int monsterLevel)
        {
            Name = name;
            Health = health;
            AttackStats = attackStats;
            DefenseStats = defenseStats;
            MonsterLevel = monsterLevel;
        }

        public bool Alive ()
        {
            if (Health <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public abstract void Loot();




    }
}
