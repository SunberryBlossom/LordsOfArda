namespace LordsOfArda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Stats heroStats = new Stats(strength: 10, agility: 8, intelligence: 7, endurance: 9);
            Character test = new Character("Bobbey", 10, "Male", "", "The Shire",heroStats );

            test.PrintInfo();
        }

       
    }
}
