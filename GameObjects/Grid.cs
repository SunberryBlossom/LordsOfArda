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
                            j++;
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

        public bool CanMove(GameObject moveableObj, int oldX, int oldY)
        {
            // Grab all gameobjects on current Y axis row
            List<GameObject>[] objectsRow = Enumerable.Range(0, GridArray.GetLength(1)).Select(item => GridArray[moveableObj.Y, item]).ToArray();
            // Check every gameobject if their width correlates with coordinates for player, if it does return bool as false
            for (int i = 0; i < objectsRow.Length; i++)
            {
                for (int j = 0; j < objectsRow[i].Count; j++)
                {
                    var currentObject = objectsRow[i][j];
                    // Check if player with width applied and the currentObject we are checking inside row with width apllied collides with eachother
                    if ((moveableObj.X < currentObject.X + currentObject.Width) && (moveableObj.X + moveableObj.Width > currentObject.X) && moveableObj != currentObject && !currentObject.IsWalkable)
                    {
                        // Collision detected return false
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
