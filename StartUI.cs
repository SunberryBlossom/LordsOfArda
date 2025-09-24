using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    internal class StartUI
    {
        public void IntroScene(string logo)
        {
            Console.WriteLine(logo);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public void StartMenu()
        {
            string logo = AssetManager.GetAsciiArt(ArtType.Logo);
            IntroScene(logo);
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
