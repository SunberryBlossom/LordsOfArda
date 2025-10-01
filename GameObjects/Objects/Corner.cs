using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda.GameObjects.Objects
{
    public class Corner : GameObject
    {
        public Corner(int startX = 1, int startY = 1) : base(startX, startY)
        {
        }

        public override char CharacterSign => '+';
    }
}
