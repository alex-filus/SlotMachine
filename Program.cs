using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //testing grid
            int[,] slotGrid =
        {
    { 1, 5, 1 },
    { 0, 1, 2 },
    { 1, 0, 2 }
        };


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

            int gameChoice = 0;
            while (true)
            {
                // Options of the games:
                Console.WriteLine();
                Console.WriteLine("Choose an option you would like to play. Enter a number 1-4:");
                Console.WriteLine("1 - Center line");
                Console.WriteLine("2 - All horizontal lines");
                Console.WriteLine("3 - All vertical lines");
                Console.WriteLine("4 - Diagonal lines");
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

            //Random random = new Random();
            //int[,] slotGrid = new int[ROWS, COLUMNS];

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
                            Console.Write(slotGrid[i, j] + " ");
                            //slotGrid[i,j] = random.Next(1, 9);
                            //Console.Write(slotGrid[i,j] + " ");
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
                case 1: //center line option
                    int middleLine = ROWS / 2;
                    bool centerWin = true;

                    for (int i = middleLine; i < ROWS; i++)
                    {
                        if (slotGrid[middleLine, 0] != slotGrid[middleLine, i])
                        {
                            centerWin = false;
                            Console.WriteLine("No match.");
                            balance -= wagerInt;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You win!");
                            balance += wagerInt * 2;
                        }
                    }
                    break;

                case 2: //all horizontal lines option

                    bool horizontalWin = true;
                    for (int i = 0; i < ROWS; i++)
                    {
                        for (int j = 1; j < COLUMNS; j++)
                        {
                            if (slotGrid[i, 0] != slotGrid[i, j])
                            {
                                horizontalWin = false;
                                break;
                            }
                        }
                        if (horizontalWin)
                        {
                            Console.WriteLine("You win!");
                            balance += wagerInt * 2;
                            break;
                        }
                    }
                    if (!horizontalWin)
                    {
                        Console.WriteLine($"No match.");
                        balance -= wagerInt;
                    }
                    break;

                case 3: //all vertical lines option

                    bool verticalWin = true;
                    for (int i = 0; i < ROWS; i++)
                    {
                        for (int j = 0; j < COLUMNS; j++)
                        {
                            if (slotGrid[0, j] != slotGrid[i, j])
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
                    }
                    if (!verticalWin)
                    {
                        Console.WriteLine($"No match.");
                        balance -= wagerInt;
                    }
                    break;

                case 4: //Diagonal lines

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








        }
    }
}


