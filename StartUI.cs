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
                StartMenuOptions selectedOption = Menu.ReadOption<StartMenuOptions>(logo, mainMenuOptions);
                switch (selectedOption)
                {
                    case StartMenuOptions.NewGame:
                        break;
                    case StartMenuOptions.LoadGame:
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
        private void CreateSaveMenu()
        {
            string saveName = Menu.ReadInput("Enter a name for your save file (max 20 characters): ", 20);
            // Create a new save file here
            Console.Clear();

            // After creating save file load character creation menu
        }
        private void LoadSavesMenu()
        {
            // Load and display list of save files here, let user choose one to load
        }
        private void CharacterCreationMenu()
        {
            string characterName = Menu.ReadInput("Enter your character's name: ", 20);
        }
    }
}
