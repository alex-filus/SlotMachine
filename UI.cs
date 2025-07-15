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
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter your wager.");
                string wager = Console.ReadLine();
                int wagerInt = 0;

                if (wager.All(char.IsDigit))
                {
                    wagerInt = Convert.ToInt32(wager);
                    Console.WriteLine($"Betting ${wagerInt}?");
                    break;
                }

                else
                {
                    Console.WriteLine("Wrong input. Try again.");
                }
            }
        }

        public static void PrintGrid()
        {
            while (true)
            {
                Console.WriteLine("Press SPACE to start the game.");

                Random random = new Random();
                int[,] slotGrid = new int[Constants.ROWS, Constants.COLUMNS];

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                //if user enters SPACE, proceed with generating the grid of random numbers
                if (keyInfo.Key == ConsoleKey.Spacebar)
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
                    break;
                }

                else
                {
                    Console.WriteLine("Please press SPACE instead.");
                }

            }
        }

        public static void PrintNoMatchMessage()
        {
            Console.WriteLine("No match.");
        }

        public static void PrintYouWinMessage()
        {
            Console.WriteLine("You win!");
        }

        public static string AskIfKeepPlaying()
        {
            Console.WriteLine("Keep playing? Y/N");
            string keepPlayingUserChoice = Console.ReadLine()?.ToUpper();
        }

        public static void PrintGoodbyeMessage()
        {
            Console.WriteLine("Ok, goodbye!");
        }

        public static void PrintBalance(int balance)
        {
            Console.WriteLine($"Your current balance is ${balance}");
        }

    }
}
