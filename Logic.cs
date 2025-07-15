namespace SlotMachine
{
    class Logic
    {
        public static void EvaluateUserInput(string userInput)
        {
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out gameChoice) && gameChoice >= Constants.CENTRAL_LINE && gameChoice <= Constants.DIAGONAL_LINES)
            {
                break;
            }

            else
            {
                //Console.WriteLine("Incorrect input. Please choose a number 1-4.");
            }
        }

        public static void GenerateRandomNumber()
            //code here

            public static bool CheckWin(int[,] slotGrid)
        {
            //code here
        }

        public static bool CheckCentralLineWin(int[,] slotGrid)
        {
            int middleLine = Constants.ROWS / 2;
            bool centerWin = true;

            for (int i = middleLine; i < Constants.ROWS; i++)
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
        }

        public static int SubtractWagerFromBalance(int balance, int wagerInt)
        {
            balance -= wagerInt;
        }

        public static int AddWagerToBalance(int balance, int wagerInt)
        {
            balance += wagerInt * 2;
        }
           

        
    }
}
