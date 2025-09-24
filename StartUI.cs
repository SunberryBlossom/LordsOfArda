using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    internal class StartUI
    {
        // Plays simple intro scene with logo
        private void DisplayIntroScene(string logo)
        {
            Console.WriteLine(logo);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        // First menu shown to player, contains starter options and loops until exit is selected
        public void StartMenu()
        {
            string logo = AssetManager.GetAsciiArt(ArtType.Logo);
            DisplayIntroScene(logo);
            string[] mainMenuOptions = { "New Game", "Load Game","Options","Credits", "Exit" };
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
                        break;
                    case StartMenuOptions.Exit:
                        isContinue = false;
                        break;
                }
            }
        }
    }
}
