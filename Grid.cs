using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    // Grid class sets a grid with a 2d char array and keeps track of where player is inside this. It also paints every character in the array.
    internal class Grid
    {
        public char[,] GridArray { get; set; }
        public int _playerX = 1;
        public int _playerY = 1;
        protected int origRow = Console.CursorTop;
        protected int origCol = Console.CursorTop;

        public int PlayerX
        {
            get { return _playerX; }
            set
            {
                if (value < 0 || value >= GridArray.GetLength(0))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Value must be in range of GridArray");
                }
                _playerX = value;
            }
        }
        public int PlayerY
        {
            get { return _playerY; }
            set
            {
                if (value < 0 || value >= GridArray.GetLength(1))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Value must be in range of GridArray");
                }
                _playerX = value;
            }
        }
        public Grid(int height, int width)
        {
            GridArray = new char[height, width];
            // Fill array with walls, corners and empty space on start
            for (int i = 0; i < GridArray.GetLength(0); i++)
            {
                for (int j = 0; j < GridArray.GetLength(1); j++)
                {
                    // Every corner
                    if ((i == 0 || i == GridArray.GetLength(0) - 1) && (j == 0 || j == GridArray.GetLength(1) - 1))
                    {
                        GridArray[i, j] = '+';
                    }
                    // Walls upper and lower
                    else if ((i == 0 || i == GridArray.GetLength(0) -1 ) && j < GridArray.GetLength(1) - 1 && j > 0)
                    {
                        GridArray[i, j] = '-';
                    }
                    // Walls left and right
                    else if ((j == 0 || j == GridArray.GetLength(1) - 1) && i < GridArray.GetLength(1) - 1 && i > 0)
                    {
                        GridArray[i, j] = '|';
                    }
                    else
                    {
                        // Empty Space
                        GridArray[i, j] = ' ';
                    }
                    GridArray[PlayerX, PlayerY] = 'o';
                }
            }
        }

        public void PrintGrid()
        {
            Console.Clear();
            for (int i = 0; i < GridArray.GetLength(0); i++)
            {
                for (int j = 0; j < GridArray.GetLength(1); j++)
                {
                    Console.SetCursorPosition(origCol+j,origRow+i);
                    Console.Write(GridArray[i, j]);
                }
                Console.WriteLine("");
            }
        }

    }
}
