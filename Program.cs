using System;
using System.Transactions;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int ROWS = 3;
            const int COLUMNS = 3;
            const int CENTRAL_LINE = 1;
            const int HORIZONTAL_LINES = 2;
            const int VERTICAL_LINES = 3;
            const int DIAGONAL_LINES = 4;
            int balance = 0;
            int wagerInt = 0;

            Console.WriteLine("Welcome to the Slot Machine!");
            Console.WriteLine();

            bool keepPlaying = true;
            while (keepPlaying)
            {

                int gameChoice = 0;
                while (true)
                {
                    // Options of the games:
                    Console.WriteLine();
                    Console.WriteLine("Choose an option you would like to play. Enter a number 1-4:");
                    Console.WriteLine($"{CENTRAL_LINE} - Center line");
                    Console.WriteLine($"{HORIZONTAL_LINES} - All horizontal lines");
                    Console.WriteLine($"{VERTICAL_LINES} - All vertical lines");
                    Console.WriteLine($"{DIAGONAL_LINES} - Diagonal lines");
                    Console.WriteLine();

                    string userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out gameChoice) && gameChoice >= CENTRAL_LINE && gameChoice <= DIAGONAL_LINES)
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Incorrect input. Please choose a number 1-4.");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Enter your wager.");

                //if wager is not an integer, ask again

                while (true)

                {
                    string wager = Console.ReadLine();

                    wagerInt = 0;
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

                Console.WriteLine("Press SPACE to start the game.");

                Random random = new Random();
                int[,] slotGrid = new int[ROWS, COLUMNS];

                while (true)
                {

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    //if user enters SPACE, proceed with generating the grid of random numbers
                    if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        for (int i = 0; i < ROWS; i++)

                        {
                            for (int j = 0; j < COLUMNS; j++)
                            {
                                slotGrid[i, j] = random.Next(1, 9);
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

                switch (gameChoice)
                {
                    case CENTRAL_LINE: //center line option
                        int middleLine = ROWS / 2;
                        bool centerWin = true;

                        for (int i = middleLine; i < ROWS; i++)
                        {
                            if (slotGrid[middleLine, 0] != slotGrid[middleLine, i])
                            {
                                centerWin = false;
                                break;
                            }
                            else
                            {
                                centerWin = true;
                            }
                        }

                        if (!centerWin)
                        {
                            Console.WriteLine("No match.");
                            balance -= wagerInt;
                        }

                        else
                        {
                            Console.WriteLine("You win!");
                            balance += wagerInt * 2;
                        }
                        break;

                    case HORIZONTAL_LINES: //all horizontal lines option

                        bool horizontalWin = true;
                        for (int i = 0; i < ROWS; i++)
                        {
                            bool rowWin = true;

                            for (int j = 1; j < COLUMNS; j++)
                            {
                                if (slotGrid[i, 0] != slotGrid[i, j])
                                {
                                    rowWin = false;
                                    break;
                                }
                            }

                            if (!rowWin)
                            {
                                horizontalWin = false;
                                break;
                            }
                        }

                        if (horizontalWin)
                        {
                            Console.WriteLine("You win!");
                            balance += wagerInt * 2;
                        }

                        else
                        {
                            Console.WriteLine($"No match.");
                            balance -= wagerInt;
                        }
                        break;

                    case VERTICAL_LINES: //all vertical lines option

                        bool verticalWin = true;
                        for (int i = 0; i < ROWS; i++)
                        {
                            bool columnWin = true;
                            for (int j = 0; j < COLUMNS; j++)
                            {
                                if (slotGrid[0, j] != slotGrid[i, j])
                                {
                                    columnWin = false;
                                    break;
                                }
                            }

                            if (!columnWin)
                            {
                                verticalWin = false;
                                break;
                            }
                        }
                        if (verticalWin)
                        {
                            Console.WriteLine("You win!");
                            balance += wagerInt * 2;
                            break;
                        }

                        if (!verticalWin)
                        {
                            Console.WriteLine($"No match.");
                            balance -= wagerInt;
                        }
                        break;

                    case DIAGONAL_LINES: //Diagonal lines

                        bool diagonalWin1 = true;
                        for (int i = 1; i < ROWS; i++)
                        {

                            if (slotGrid[0, 0] != slotGrid[i, i])
                            {
                                diagonalWin1 = false;
                                break;
                            }
                        }

                        if (diagonalWin1)
                        {
                            Console.WriteLine("You win!");
                            balance += wagerInt * 2;
                            break;
                        }

                        bool diagonalWin2 = true;
                        for (int j = 1; j < COLUMNS; j++)
                        {

                            if (slotGrid[ROWS - 1, 0] != slotGrid[COLUMNS - 1 - j, j])
                            {
                                diagonalWin2 = false;
                                break;
                            }
                        }

                        if (diagonalWin2)
                        {
                            Console.WriteLine("You win!");
                            balance += wagerInt * 2;
                            break;
                        }

                        if (!diagonalWin1 && !diagonalWin2)
                        {
                            Console.WriteLine($"No match.");
                            balance -= wagerInt;
                        }

                        break;

                }

                Console.WriteLine($"Your current balance is ${balance}");

                //After each game, ask the player if they want to continue playing
                while (true)
                {
                    Console.WriteLine("Keep playing? Y/N");
                    string keepPlayingUserChoice = Console.ReadLine()?.ToUpper();

                    if (keepPlayingUserChoice == "Y")
                    {
                        break;
                    }

                    if (keepPlayingUserChoice == "N")
                    {
                        Console.WriteLine("Ok, goodbye!");
                        return;
                    }

                    else
                    {
                        continue;

                    }
                }

            }



        }
    }
}


