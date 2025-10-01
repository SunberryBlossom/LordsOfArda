using LordsOfArda.GameObjects;
using LordsOfArda.GameObjects.Objects;
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
        // Declare variables. GridArray is a 2D array with a list for x and y coordinates. List is responsible for layering.
        public List<GameObject>[,] GridArray { get; set; }
        protected int origRow = Console.CursorTop;
        protected int origCol = Console.CursorTop;

        public Grid(int height, int width, List<GameObject> gameObjects)
        {
            GridArray = new List<GameObject>[height, width];

            // For loop iterates through grids height and width
            for (int i = 0; i < GridArray.GetLength(0); i++)
            {
                for (int j = 0; j < GridArray.GetLength(1); j++)
                {
                    // Instalize a new List for every coordinate
                    GridArray[i, j] = new List<GameObject>();
                    // Add every corner
                    if ((i == 0 || i == GridArray.GetLength(0) - 1) && (j == 0 || j == GridArray.GetLength(1) - 1))
                    {
                        GridArray[i, j].Add(new Corner(startX:j,startY:i));
                    }
                    // Add walls for upper and lower
                    else if ((i == 0 || i == GridArray.GetLength(0) -1 ) && j < GridArray.GetLength(1) - 1 && j > 0)
                    {
                        GridArray[i, j].Add(new WallHorizontal(startX: j, startY: i));
                    }
                    // Add walls for left and right
                    else if ((j == 0 || j == GridArray.GetLength(1) - 1) && i < GridArray.GetLength(1) - 1 && i > 0)
                    {
                        GridArray[i, j].Add(new WallVertical(startX: j, startY: i));
                    }
                    // Get potenial game objects for that coordinate
                    GameObject[] coordinateObjects = gameObjects.TakeWhile(item => item.X == j && item.Y == i).ToArray();
                    if (coordinateObjects != null)
                    {
                        // Add all objects on that coordinate to list
                        foreach (var item in coordinateObjects)
                        {
                            GridArray[i, j].Add(item);
                        }
                    }
                }
            }
        }

        public void PrintGrid()
        {
            Console.CursorVisible = false;
            // Iterate through y,x and write either empty space if no object exists in list or write the gameobjexts charactersign
            for (int i = 0; i < GridArray.GetLength(0); i++)
            {
                for (int j = 0; j < GridArray.GetLength(1); j++)
                {
                    Console.SetCursorPosition(origCol + j, origRow + i);
                    // If grid is empty, print an empty character, else print the highest object in the list
                    if (GridArray[i,j].Count == 0)
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write(GridArray[i, j][^1].CharacterSign);
                    }
                }
            }
            Console.CursorVisible = false;
        }

        public bool MoveObject(GameObject obj, int oldX, int oldY)
        {
            // Check if player can move over object, if they can we remove old position from List layer and add same object to new position
            if (CanMove(obj))
            {
                GridArray[oldY, oldX].Remove(obj);
                GridArray[obj.Y, obj.X].Add(obj);
                PrintGrid();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanMove(GameObject obj)
        {
            // Check if there is an object in the list that has IsWalkable == false
            return GridArray[obj.Y, obj.X].Select(item => item.IsWalkable == false).ToArray().Length <= 0;
        }

    }
}
