using LordsOfArda.GameObjects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda.GameObjects
{
    // Grid class sets a grid with a 2d char array and keeps track of where player is inside this. It also paints every character in the array.
    internal class Grid
    {
        // Declare variables. GridArray is a 2D array with a list for x and y coordinates. List is responsible for layering objects on top of eachother.
        public List<GameObject>[,] GridArray { get; set; }
        public char[,] GridTop { get; set; }
        protected int origRow = Console.CursorLeft;
        protected int origCol = Console.CursorTop;

        public Grid(int height, int width, List<GameObject> gameObjects)
        {
            GridArray = new List<GameObject>[height, width];
            GridTop = new char[height,width];

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
                    GameObject[] coordinateObjects = gameObjects.Where(item => item.X == j && item.Y == i).ToArray();
                    if (coordinateObjects != null && coordinateObjects.Length > 0)
                    {
                        // Add all objects on that coordinate to list
                        GridArray[i, j].AddRange(coordinateObjects);
                    }
                }
            }
        }

        public void PrintGrid()
        {
            Console.CursorVisible = false;
            // Iterate through y,x and write either empty space if no object exists in list or write the gameobjects CharacterSign
            for (int i = 0; i < GridArray.GetLength(0); i++)
            {
                for (int j = 0; j < GridArray.GetLength(1); j++)
                {
                    // Check if buffer and original cells list is above 0, if they are return their CharacterSign, else return empty space
                    var GridCell = GridArray[i, j];
                    string GridChar = GridCell.Count > 0 ? GridCell[^1].CharacterSign : " ";
                    // If current rendered top layer is different from new top layer, render that position with new character and add the character to GridTop
                    if (GridChar.Length > 1)
                    {
                        if (GridChar != $"{GridTop[i, j]}{GridTop[i+1, j+1]}")
                        {
                            Console.SetCursorPosition(origCol + j, origRow + i);
                            Console.Write("\u001b[48;2;34;139;34m" + GridChar + "\u001b[0m");
                            GridTop[i, j] = GridChar[0];
                            GridTop[i, j + 1] = GridChar[1];
                            j += GridChar.Length -1;
                        }
                    }
                    else if(GridChar.Length == 1)
                    {
                        if (GridChar[0] != GridTop[i, j])
                        {
                            Console.SetCursorPosition(origCol + j, origRow + i);
                            Console.Write("\u001b[48;2;34;139;34m" + GridChar + "\u001b[0m");
                            GridTop[i, j] = GridChar[0];
                        }
                    }
                }
            }
            Console.CursorVisible = false;
        }

        public bool MoveObject(GameObject obj, int oldX, int oldY)
        {
            // Check if player can move over object, if they can we remove old position from List layer and add same object to new position
            if (CanMove(obj,oldX,oldY))
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

        public bool CanMove(GameObject obj, int oldX, int oldY)
        {
            // obj.X and obj.Y is where player currently wants to move. Note that emojis renders a bit with at like 1.5 of a console index. So they may be 5 characters, but actual space they need is less than 2.
            // If GameObject CharacterSign is 2 or more we check collision at 1 more index to the right.
            if (obj.CharacterSign.Length >= 2 && oldX-obj.X == -1 && oldY-obj.Y == 0)
            {
                // Check if there is an object in the list layer that has IsWalkable == false.
                bool charOne = GridArray[obj.Y, obj.X + 1].Select(item => item.IsWalkable == false).ToArray().Length == 0;
                if (charOne)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // If gameObjects charactersign is 2 or more we check collision on Y level.
            else if (obj.CharacterSign.Length >= 2 && oldY - obj.Y != 0)
            {
                // Future implementation would be better to check multiple spaces at once.
                bool charOne = GridArray[obj.Y, obj.X].Select(item => item.IsWalkable == false).ToArray().Length == 0;
                bool charTwo = GridArray[obj.Y, obj.X + 1].Select(item => item.IsWalkable == false).ToArray().Length == 0;
                if (charOne && charTwo)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // Check where object wants to be moved and check if there is an object there
            else
            {
                bool charOne = GridArray[obj.Y, obj.X].Select(item => item.IsWalkable == false).ToArray().Length == 0;
                return charOne;
            }
        }

    }
}
