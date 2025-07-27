using System;
using System.Transactions;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Display welcome message
            UI.PrintWelcomeMessage();

            //initialize the grid
            int[,] slotGrid = new int[Constants.ROWS, Constants.COLUMNS];

            bool keepPlaying = true;
            while (keepPlaying)
            {
                //int gameChoice = 0;
                while (true)
                {
                    // Options of the games:
                    UI.PrintGameOptions();
                }

                UI.AskForWager();

                UI.PrintGrid(slotGrid);

                Logic.CheckWin(slotGrid);

                UI.PrintBalance(balance);

                //After each game, ask the player if they want to continue playing
                while (true)
                {
                    UI.AskIfKeepPlaying();
                  
                }
            }
            }
        }
    }



