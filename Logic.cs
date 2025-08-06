namespace SlotMachine
{
    class Logic
    {
        public static void CheckWin(int[,] slotGrid, int gameChoice, int balance, int wagerInt)
        {
            switch (gameChoice)
            {
                case Constants.CENTRAL_LINE:
                    CheckCentralLineWin(slotGrid, balance, wagerInt);
                    break;
                case Constants.HORIZONTAL_LINES:
                    CheckHorizontalLines(slotGrid, balance, wagerInt);
                    break;
                case Constants.VERTICAL_LINES:
                    CheckVerticalLines(slotGrid, balance, wagerInt);
                    break;
                case Constants.DIAGONAL_LINES:
                    CheckDiagonalLines(slotGrid, balance, wagerInt);
                    break;
                default:
                    Console.WriteLine("Invalid game option.");
                    break;
            }
        }

        public static bool CheckCentralLineWin(int[,] slotGrid, int balance, int wagerInt)
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
            }

            if (!centerWin)
            {
                balance = SubtractWagerFromBalance(balance, wagerInt);
                UI.PrintNoMatchMessage();
            }
            if (centerWin)
            {
                balance = AddWagerToBalance(balance, wagerInt);
                UI.PrintYouWinMessage();
            }
            return centerWin;
        }


        public static bool CheckHorizontalLines(int[,] slotGrid, int balance, int wagerInt)
        {
            bool horizontalWin = true;
            for (int i = 0; i < Constants.ROWS; i++)
            {
                bool rowWin = true;

                for (int j = 1; j < Constants.COLUMNS; j++)
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
                balance = AddWagerToBalance(balance, wagerInt);
                UI.PrintYouWinMessage();

            }

            else
            {
                balance = SubtractWagerFromBalance(balance, wagerInt);
                UI.PrintNoMatchMessage();
            }

            return horizontalWin;
        }

        public static bool CheckVerticalLines(int[,] slotGrid, int balance, int wagerInt)
        {
            bool verticalWin = true;
            for (int i = 0; i < Constants.ROWS; i++)
            {
                bool columnWin = true;
                for (int j = 0; j < Constants.COLUMNS; j++)
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
                balance = AddWagerToBalance(balance, wagerInt);
                UI.PrintYouWinMessage();

            }

            if (!verticalWin)
            {
                balance = SubtractWagerFromBalance(balance, wagerInt);
                UI.PrintNoMatchMessage();
            }
            return verticalWin;
        }

        public static bool CheckDiagonalLines(int[,] slotGrid, int balance, int wagerInt)
        {
            bool diagonalWin1 = true;
            for (int i = 1; i < Constants.ROWS; i++)
            {

                if (slotGrid[0, 0] != slotGrid[i, i])
                {
                    diagonalWin1 = false;
                    break;
                }
            }

            if (diagonalWin1)
            {
                balance = AddWagerToBalance(balance, wagerInt);
                UI.PrintYouWinMessage();
            }

            bool diagonalWin2 = true;
            for (int j = 1; j < Constants.COLUMNS; j++)
            {

                if (slotGrid[Constants.ROWS - 1, 0] != slotGrid[Constants.COLUMNS - 1 - j, j])
                {
                    diagonalWin2 = false;
                    break;
                }
            }

            if (diagonalWin2)
            {
                balance = AddWagerToBalance(balance, wagerInt);
                UI.PrintYouWinMessage();
            }

            if (!diagonalWin1 && !diagonalWin2)
            {
                balance = SubtractWagerFromBalance(balance, wagerInt);
                UI.PrintNoMatchMessage();
            }
            return diagonalWin1 || diagonalWin2;
        }

        public static int SubtractWagerFromBalance(int balance, int wagerInt)
        {
            balance -= wagerInt;
            return balance;
        }

        public static int AddWagerToBalance(int balance, int wagerInt)
        {
            balance += wagerInt * 2;
            return balance;
        }



    }
}
