using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labb_7.UI
{
    internal static class Menu
    {
        // Helper method to show alternatives that can be selected with arrow keys and enter
        public static T ReadOption<T>(string questionText, string[] menuOptions) where T : Enum
        {
            int i = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(questionText+"\n");
                for (int j = 0; j < menuOptions.Length; j++)
                {
                    Console.BackgroundColor = i == j ? ConsoleColor.White : ConsoleColor.Black;
                    Console.ForegroundColor = i == j ? ConsoleColor.Black : ConsoleColor.White;
                    Console.WriteLine(menuOptions[j]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (i < menuOptions.Length-1) i++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (i > 0) i--;
                        break;
                    case ConsoleKey.Enter:
                        // returns specified enum
                        return (T)Enum.ToObject(typeof(T), i);

                }
            }
        }
        // Helper method to show alternatives that can be selected with arrow keys and enter, made for int
        public static int ReadOption(string questionText, string[] menuOptions)
        {
            int i = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(questionText + "\n");
                for (int j = 0; j < menuOptions.Length; j++)
                {
                    Console.BackgroundColor = i == j ? ConsoleColor.White : ConsoleColor.Black;
                    Console.ForegroundColor = i == j ? ConsoleColor.Black : ConsoleColor.White;
                    Console.WriteLine(menuOptions[j]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (i < menuOptions.Length - 1) i++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (i > 0) i--;
                        break;
                    case ConsoleKey.Enter:
                        // returns index as int
                        return i;

                }
            }
        }
        // Helper method, allow user to press right or left arrow keys to control value in middle and Enter to choose
        public static int ReadSlider(string questionText, string[] menuOptions)
        {
            int i = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(questionText + "\n");
                var sliderStructure = new StringBuilder(menuOptions[i]);
                if (i > 0) sliderStructure.Insert(0,"<- ");
                if (i < menuOptions.Length) sliderStructure.Append(" ->");
                Console.WriteLine(sliderStructure);
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        if (i < menuOptions.Length - 1) i++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (i > 0) i--;
                        break;
                    case ConsoleKey.Enter:
                        return i;

                }
            }
        }
        // Helper method to take in and verify a string
        public static string ReadInput(string questionText, int minLength = 1, int maxLength = int.MaxValue)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(questionText);
                string? userInput = Console.ReadLine();
                if (userInput != null)
                {
                    (bool, string) verifyInput = VerifyString(userInput, minLength, maxLength);
                    if (verifyInput.Item1)
                    {
                        Console.WriteLine(verifyInput.Item2);
                        return userInput;
                    }
                    else
                    {
                        Console.WriteLine(verifyInput.Item2);
                    }
                }

            }
        }
        // Helper method to get an int from user input
        public static int ReadInt(string questionText, int minInt = 0, int maxInt = int.MaxValue)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(questionText);
                string? userInput = Console.ReadLine();
                if (userInput != null)
                {
                    int parsedValue;
                    bool success = int.TryParse(userInput, out parsedValue);
                    if (success && parsedValue >= minInt && parsedValue <= maxInt)
                    {
                        return parsedValue;
                    }
                    else if (!success)
                    {
                        Console.WriteLine("You must provide a real number!");
                    }
                    else
                    {
                        Console.WriteLine("That number is outside of the allowed range");
                    }
                }
            }
        }
        // Helper method to verify string with error message
        public static (bool, string) VerifyString(string unverifiedString, int minLength = 1, int maxLength = int.MaxValue)
        {
            if (unverifiedString.Length < minLength)
            {
                return (false, $"You must enter at least {minLength} character(s)!");
            }
            if (unverifiedString.Length > maxLength)
            {
                return (false, $"You can maximum enter {maxLength} characters");
            }
            return (true, "Success!");
        }
    }
}
