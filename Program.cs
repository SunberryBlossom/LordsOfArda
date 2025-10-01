using LordsOfArda.Saving;

namespace LordsOfArda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid(10,15);
            grid.PrintGrid();
            Console.ReadLine();
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
