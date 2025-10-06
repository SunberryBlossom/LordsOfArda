using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    internal static class Menu
    {
        // Helper method to show alternatives that can be selected with arrow keys and enter, made to return an Enum
        public static TEnum ReadOption<T, TEnum>(string questionText, T[] menuOptions) where TEnum : Enum
        {
            int i = 0;
            while (true)
            {
                Console.Clear();
                // Write out question and display options, currently selected index gets highlighted
                Console.WriteLine(questionText + "\n");
                for (int j = 0; j < menuOptions.Length; j++)
                {
                    Console.BackgroundColor = i == j ? ConsoleColor.White : ConsoleColor.Black;
                    Console.ForegroundColor = i == j ? ConsoleColor.Black : ConsoleColor.White;
                    Console.WriteLine(menuOptions[j]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                // Reset color and read the key that user presses
                Console.ResetColor();
                ConsoleKey key = Console.ReadKey().Key;
                // Check what user pressed and go up or down in index as long as it is within the length of menuOptions. Enter returns Enum
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (i < menuOptions.Length - 1) i++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (i > 0) i--;
                        break;
                    case ConsoleKey.Enter:
                        // returns specified enum
                        return (TEnum)Enum.ToObject(typeof(TEnum), i);

                }
            }
        }
        // Helper method to show alternatives that can be selected with arrow keys and enter, made to return int
        public static int ReadOptionIndex<T>(string questionText, T[] menuOptions)
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
                if (i > 0) sliderStructure.Insert(0, "<- ");
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
                        DisplayStatus(verifyInput.Item2, ConsoleColor.Green);
                        return userInput;
                    }
                    else
                    {
                        DisplayStatus(verifyInput.Item2, ConsoleColor.Red);
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
                        DisplayStatus("Error: You must provide a real number!", ConsoleColor.Red);
                    }
                    else
                    {
                        DisplayStatus("Error: That number is outside of the allowed range", ConsoleColor.Red);
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

        public static void DisplayStatus(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
            Console.WriteLine("Click any key to continue...");
            Console.ReadKey();

        }
    }
}
