using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda.GameObjects
{
    // Abstract class that is used for the Grid
    public abstract class GameObject
    {
        public abstract string CharacterSign { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; } = 1;
        public bool IsWalkable { get; set; }

        public GameObject(int startX = 1, int startY = 1, bool isWalkable = false)
        {
            X = startX;
            Y = startY;
            IsWalkable = isWalkable;
        }
    }
}
