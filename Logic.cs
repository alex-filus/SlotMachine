namespace SlotMachine
{
    class Logic
    {
        public int balance = 0;
        public int wagerInt = 0;
        public static bool CheckWin(int[,] slotGrid)
        {
            return CheckCentralLineWin(slotGrid) || CheckHorizontalLines(slotGrid) || CheckVerticalLines(slotGrid) || CheckDiagonalLines(slotGrid);
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


        public static bool CheckHorizontalLines(int[,] slotGrid)
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


                if (rowWin)
                {
                    horizontalWin = true;
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

        public static bool CheckVerticalLines(int[,] slotGrid)
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

                if (columnWin)
                {
                    verticalWin = true;
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

        public static bool CheckDiagonalLines(int[,] slotGrid)
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
