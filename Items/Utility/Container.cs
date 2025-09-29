using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda.Items.Utility
{
    internal class Container : Item
    {
        public string Type { get; set; }
        public int Capacity { get; set; }
        public string Material { get; set; }
        public bool Locked { get; set; }

    }
}
