using LordsOfArda.GameObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    public abstract class Character : GameObject
    {
        public override string CharacterSign => "C";

        public string Name { get; set; }
        public int Health { get; set; } = 100;
        public string Gender { get; set; }
        public string Title { get; set; } = "The Curious";
        public string Race { get; set; } = "Human";
        public Stats Stats { get; set; } = new Stats(10,10,10,10);
        public string Birthplace { get; set; }

      public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Health: {Health}, Gender: {Gender}, Title: {Title}, Birthplace: {Birthplace}, Race: {Race}");
            Console.WriteLine($"Stats: {Stats}");
        }
    }
}
