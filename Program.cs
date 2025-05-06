using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagerInt = 0;


            Console.WriteLine("Welcome to the Slot Machine!");
            Console.WriteLine();

            Console.WriteLine("Enter your wager.");

            //if wager is not an integer, ask again

            while (true)

            {
                string wager = Console.ReadLine();



                if (wager.All(char.IsDigit))
                {
                    wagerInt = Convert.ToInt32(wager);
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
            int[,] slotGrid = new int[3, 3];

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
                            slotGrid[i,j] = random.Next(1, 9);
                            Console.Write(slotGrid[i,j] + " ");
                        }
                        Console.WriteLine();

                    }
                }


                else
                {
                    Console.WriteLine("Please press SPACE instead.");
                }
            }

            //Win options
            int win1 = 0;
            int win2 = 0;
            int win3 = 0;
            int win4 = 0;


            if (slotGrid[0,0] == slotGrid[1,1] && slotGrid[1,1] == slotGrid[2,2])
            {
                win1 = 1;
            }

            if (slotGrid[0, 2] == slotGrid[1, 1] && slotGrid[1, 1] == slotGrid[2, 0])
            {
                win2 = 1;

            }

           

        }







    }
}


