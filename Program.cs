using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Welcome to the Slot Machine!");
            Console.WriteLine();

            Console.WriteLine("Enter your wager.");
            
            //if wager is not an integer, ask again

            while (true)

            {
                string wager = Console.ReadLine();

                

                if (wager.All(char.IsDigit))
                {
                    int wagerInt = Convert.ToInt32(wager);
                    break;
                }

                else
                {
                    Console.WriteLine("Wrong input. Try again.");
                }
                }

                Console.WriteLine();
                Console.WriteLine("Press SPACE to start");
                Console.WriteLine();


                Random random = new Random();


                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    //if user enters SPACE, proceed with generating the grid of random numbers
                    if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        for (int i = 0; i < 3; i++)

                        {

                            for (int j = 0; j < 3; j++)
                            {
                                int randomNumber = random.Next(1, 9);
                                Console.Write(randomNumber + " ");
                            }
                            Console.WriteLine();

                        }
                    }


                    else
                    {
                        Console.WriteLine("Please press SPACE instead.");
                    }
                }
            }







        }
    }


