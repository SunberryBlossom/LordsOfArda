using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda.Items
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; }
        public int Size { get; set; }
        public bool Dirty { get; set; }
        public bool Bloody { get; set; }
        public bool Looted { get; set; }
        public bool Wet {  get; set; }
        public int Healing { get; set; }
        public int Damage { get; set; }

        public Item()
        {
           
        }
    }
}
