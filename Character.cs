using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    internal class Character
    {

        private string _name;
        private int _health;
        private string _gender;
        private string _title;
        private string _race;
        private Stats _stats;
        private string _birthplace;


        public  Character (string name, int health, string gender, string title, string birthplace, Stats stats)
        {
            _name  = name;
            _health = health;
            _gender = gender;
            _title = title;
            _stats = stats;
            _birthplace = birthplace;

        }

    

      public void PrintInfo()
        {
            Console.WriteLine($"Name: {_name}, Health: {_health}, Gender: {_gender}, Title: {_title}, Birthplace: {_birthplace}, Race: {_race}");
            Console.WriteLine($"Stats: {_stats}");
        }
    }
}
