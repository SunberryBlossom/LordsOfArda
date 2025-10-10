using LordsOfArda.GameObjects.Objects;
using LordsOfArda.Saving;
using LordsOfArda.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    internal class StartUI
    {
        // First menu shown to player, contains starter options and loops until exit is selected
        public void StartMenu()
        {
            string logo = AssetManager.GetAsciiArt(ArtType.Logo);
            DisplayIntroScene(logo);
            string[] mainMenuOptions = { "New Game", "Load Game", "Options", "Credits", "Exit" };
            bool isContinue = true;
            while (isContinue)
            {
                StartMenuOptions selectedOption = Menu.ReadOption<string,StartMenuOptions>(logo, mainMenuOptions);
                switch (selectedOption)
                {
                    case StartMenuOptions.NewGame:
                        PlayerObject character = CharacterCreationMenu();
                        SaveData newGameSave = CreateSave(character);
                        new GameService(newGameSave).StartGame();
                        break;
                    case StartMenuOptions.LoadGame:
                        var loadGameSave = LoadSavesMenu();
                        new GameService(loadGameSave).StartGame();
                        break;
                    case StartMenuOptions.Options:
                        break;
                    case StartMenuOptions.Credits:
                        ShowCredits();
                        break;
                    case StartMenuOptions.Exit:
                        isContinue = false;
                        break;
                }
            }
        }
        // Plays simple intro scene with logo
        private void DisplayIntroScene(string logo)
        {
            Console.WriteLine(logo);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        // Shows simple credits screen, can be swapped to rolling credits in future
        private void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("Game developed by...");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
        private SaveData CreateSave(PlayerObject createdCharacter)
        {
            SaveMaster saveMaster = new SaveMaster();
            // Create a new save file here
            Console.Clear();
            SaveData saveData = new SaveData(createdCharacter);
            Console.WriteLine("Saving your file!");
            bool success = saveMaster.SaveGame(saveData);
            if (success)
            {
                Console.WriteLine("Successfully saved!");
                return saveData;
            }
            return saveData;
            // After creating save file 
        }
        private SaveData LoadSavesMenu()
        {
            SaveMaster saveMaster = new SaveMaster();
            // Display list of save folders, lets user choose one to load
            string[] saveDirectories = Directory.GetDirectories(@".\Saves");
            int chosenDirectoryIndex = Menu.ReadOptionIndex("Which character would you like to load save files from?",saveDirectories.Select(item => Path.GetFileName(item)).ToArray());
            string chosenDirectory = saveDirectories[chosenDirectoryIndex];

            // Display save files within the save folder to load from
            string[] saveFiles = Directory.GetFiles(chosenDirectory);
            int chosenFileIndex = Menu.ReadOptionIndex("Which save file would you like to load?", saveFiles.Select(item => Path.GetFileName(item)).ToArray());
            string chosenFile = saveFiles[chosenFileIndex];
            
            // Load game data
            SaveData saveData = saveMaster.LoadGame(chosenFile);
            saveData.Player.PrintInfo();
            Console.ReadKey();
            return saveData;

        }
        private PlayerObject CharacterCreationMenu()
        {
            string characterName = Menu.ReadInput("Enter a name for your character (max 20 characters): ", maxLength:20);
            string characterGender = Menu.ReadInput("What's your gender? (max 20 characters)", maxLength:20);
            string characterBirthplace = Menu.ReadInput("What's your birthplace? (max 20 characters)", maxLength:20);
            PlayerObject createdCharacter = new PlayerObject(characterName,characterGender,characterBirthplace);
            return createdCharacter;
        }
    }
}
