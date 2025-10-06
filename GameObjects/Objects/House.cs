using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda.GameObjects.Objects
{
    public class House : GameObject
    {
        public override string CharacterSign => "🏠";
        public int width = 3;
        public int height = 3;
        public House(int startX = 1, int startY = 1) : base(startX,startY)
        {
        
        }
    }
}
