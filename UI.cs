using System;
using System.Diagnostics;

namespace SlotMachine
{
    class UI
    {

        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Slot Machine!");
            Console.WriteLine();
        }

        public static void PrintGrid(int[,] slotGrid)
        {
            for (int i = 0; i < Constants.ROWS; i++)
            {
                for (int j = 0; j < Constants.COLUMNS; j++)
                {
                    slotGrid[i, j] = random.Next(Constants.RANDOM_LOW_RANGE, Constants.RANDOM_HIGH_RANGE);
                    Console.Write(slotGrid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintGameOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Choose an option you would like to play. Enter a number 1-4:");
            Console.WriteLine($"{Constants.CENTRAL_LINE} - Center line");
            Console.WriteLine($"{Constants.HORIZONTAL_LINES} - All horizontal lines");
            Console.WriteLine($"{Constants.VERTICAL_LINES} - All vertical lines");
            Console.WriteLine($"{Constants.DIAGONAL_LINES} - Diagonal lines");
            Console.WriteLine();
        }

        public static void PrintIncorrectInputMessage()
        {
            Console.WriteLine("Incorrect input. Please choose a number 1-4.");
        }

        public static void AskForWager()
        {
            Console.WriteLine();
            Console.WriteLine("Enter your wager.");
            string wager = Console.ReadLine();
        }

        public static void PrintStartGameMessage()
        {
            Console.WriteLine("Press SPACE to start the game.");
        }

        public static void PrintWrongInputMessage()
        {
            Console.WriteLine("Wrong input. Try again.");
        }

        public static void PrintPressSpaceMessage()
        {
            Console.WriteLine("Please press SPACE instead.");
        }

        public static void PrintNoMatchMessage()
        {
            Console.WriteLine("No match.");
        }

        public static void PrintYouWinMessage()
        {
            Console.WriteLine("You win!");
        }

    }
}
