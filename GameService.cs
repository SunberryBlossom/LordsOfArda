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
        // Declare variables and set initial data
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
            // Create grid and give it gameObjects. In the future grid should be fetched from SaveMaster
            Grid grid = new Grid(20, 100, _gameObjects);
            bool isContinue = true;
            // Begin main game loop
            Console.Clear();
            while (isContinue)
            {
                // Store old values for refrence when moving character
                int oldX = _player.X;
                int oldY = _player.Y;
                grid.PrintGrid();
                // This section controls player movement. Might be able to make this into an interface or put it somewhere else
                // TODO: Add ability to move in two directions at once
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
                // check if position has updated, if it has we try to move object. If it fails we revert to old coordinates
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
