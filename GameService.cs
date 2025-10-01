using LordsOfArda.GameObjects;
using LordsOfArda.GameObjects.Objects;
using LordsOfArda.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    // Handles game loop functionality, main game class
    public class GameService
    {
        private SaveData _saveData;
        private PlayerObject _player;
        private List<GameObject> _gameObjects = new List<GameObject>();
        public GameService(SaveData save)
        {
            _saveData = save;
            _player = save.Player;
            _gameObjects.Add(_player);
        }
        public void StartGame()
        {
            Grid grid = new Grid(10, 15, _gameObjects);
            bool isContinue = true;
            // Main game loop
            Console.Clear();
            while (isContinue)
            {
                int oldX = _player.X;
                int oldY = _player.Y;
                grid.PrintGrid();
                // This section controls player movement. Might be able to make this into an interface
                ConsoleKey movementKey = Console.ReadKey().Key;
                switch (movementKey)
                {
                    case ConsoleKey.UpArrow:
                        _player.Y--;
                        break;
                    case ConsoleKey.DownArrow:
                        _player.Y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        _player.X--;
                        break;
                    case ConsoleKey.RightArrow:
                        _player.X++;
                        break;
                }
                if (_player.X != oldX || _player.Y != oldY)
                {
                    bool isMoved = grid.MoveObject(_player, oldX, oldY);
                    if (!isMoved)
                    {
                        _player.X = oldX;
                        _player.Y = oldY;
                    }
                }
            }
        }
    }
}
