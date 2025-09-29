using LordsOfArda.Saving;

namespace LordsOfArda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Contains("dev"))
            {
                
            }
            else
            {
                StartUI startUI = new StartUI();
                startUI.StartMenu();
            }
        }
    }
}
