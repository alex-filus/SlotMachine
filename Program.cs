using System;
using System.Transactions;

namespace SlotMachine
{
    internal class Program
    {
        public static int balance = 0;
        public static int wagerInt = 0;
        static void Main(string[] args)
        {
       
        //Display welcome message
        UI.PrintWelcomeMessage();

            //initialize the grid
            int[,] slotGrid = new int[Constants.ROWS, Constants.COLUMNS];

        bool keepPlaying = true;
            while (keepPlaying)
            {
                int gameChoice = 0;
                while (true)
                {
                    // Options of the games:
                    UI.PrintGameOptions();
                    gameChoice = UI.CheckUserInput();
                    break;
                }

    UI.AskForWager();

                while (true)
                {
                    UI.PrintPressSpaceToStartMessage();
                    if (UI.IsSpacePressed())
                    {
                        UI.PrintGrid(slotGrid);
                        break;
                    }
                    else
{
    UI.PrintPressSpaceInsteadMessage();
}
                }
                Logic.CheckWin(slotGrid, gameChoice, balance, wagerInt);

UI.PrintBalance(balance);

//After each game, ask the player if they want to continue playing             
while (true)
{
    if (!UI.AskIfKeepPlaying())
    {
        keepPlaying = false;
        break;
    }
    else
    {
        break;
    }
}
            }
        }
    }
}



