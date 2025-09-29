using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    public class Character
    {

        public string Name { get; set; }
        public int Health { get; set; } = 100;
        public string Gender { get; set; }
        public string Title { get; set; } = "The Curious";
        public string Race { get; set; } = "Human";
        public Stats Stats { get; set; } = new Stats(10,10,10,10);
        public string Birthplace { get; set; }


        public  Character (string name, string gender, string birthplace)
        {
            Name  = name;
            Gender = gender;
            Birthplace = birthplace;

        }

    

      public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Health: {Health}, Gender: {Gender}, Title: {Title}, Birthplace: {Birthplace}, Race: {Race}");
            Console.WriteLine($"Stats: {Stats}");
        }
    }
}
