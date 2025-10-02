using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    public abstract class AsciiArt
    {
        public string FilePath { get; set; }
        public string Name { get; set; }
        public ConsoleColor Color { get; set; }

    }
}
