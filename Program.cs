using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagerInt = 0;
            const int ROWS = 3;
            const int COLUMNS = 3;

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

                if (int.TryParse(userInput, out gameChoice) && gameChoice >= 1 && gameChoice <= 4)
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
            int[,] slotGrid = new int[3, 3];

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
                            slotGrid[i,j] = random.Next(1, 9);
                            Console.Write(slotGrid[i,j] + " ");
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
               case 1:
                    if (slotGrid[0,1] == slotGrid[1,1] && slotGrid[1, 1] == slotGrid[2,1])
                    {
                        Console.WriteLine("Center line win!!");
                    }
                    else
                    {
                        Console.WriteLine("No match.");
                    }
                    break;
                case 2:
                    if (slotGrid[0, 0] == slotGrid[1, 0] && slotGrid[1, 0] == slotGrid[2, 0]
                        || slotGrid[0, 1] == slotGrid[1, 1] && slotGrid[1,1] == slotGrid[2, 1]
                        || slotGrid[0,2] == slotGrid[1,2] && slotGrid[1,2] == slotGrid[2,2])
                    {
                        Console.WriteLine("All horizontal lines match!");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you lose.");
                    }
                    break;
                case 3:
                    if (slotGrid[0,0] == slotGrid[0,1] && slotGrid[0,1] == slotGrid[0,2]
                        || slotGrid[1,0] == slotGrid[1,1] && slotGrid[1,1] == slotGrid[1,2]
                        || slotGrid[2,0] == slotGrid[2,1] && slotGrid[2,1] == slotGrid[2,2])
                    {
                        Console.WriteLine("All vertical lines match!");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you lose.");
                    }
                    break;
                case 4:
                    if (slotGrid[0,0] == slotGrid[1,1] && slotGrid[1,1] == slotGrid[2,2]
                        || slotGrid[0,2] == slotGrid[1,1] && slotGrid[1,1] == slotGrid[2,0])
                    {
                        Console.WriteLine("You win!");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you lose.");
                    }
                    break;
            }



        }







    }
}


