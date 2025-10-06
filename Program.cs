using LordsOfArda.Saving;

namespace LordsOfArda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
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
