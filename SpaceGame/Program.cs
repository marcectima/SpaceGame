using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setting the conolse text color to green
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            // Creating the univers
            List<PlanetarySystem> universe = Utilities.OperationGenesis();

            // Creating trading goods and trade menus
            Goods[] tradingGoods = Utilities.CreateTradingGoods();
            string[] TradeMenu = Utilities.CreateTradeMenus(tradingGoods);

            Console.WriteLine("\nWelcome to Space Trader");

            // Creating a new user.
            Player myPlayer = new Player();
            Console.Clear();

            // Opens action menu. This is where the game runs.
            ShowActionMenu(myPlayer, universe, tradingGoods, TradeMenu);

            // Quits the Game
            Environment.Exit(-1);
        }

        // Action menu
        private static void ShowActionMenu(Player myPlayer, List<PlanetarySystem> universe, Goods[] tradingGoods, string[] TradeMenu)
        {
            bool keepLooping = true;
            do
            {
                bool commandNotExecuted = true;
                do
                {
                    try
                    {
                        Console.Write("\nSelect from the following options:\n\n1. Status\n2. Trade\n3. Travel to...\n4. Refuel\n5. Change ship\n6. Quit game\n\n>>> ");
                        MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());
                        if (Enumerable.Range(1, 6).Contains(selection.GetSelection()))
                        {
                            switch (selection.GetSelection())
                            {
                                case 1:
                                    myPlayer.ShowStatus(myPlayer);
                                    break;
                                case 2:
                                    myPlayer.Trade(tradingGoods, myPlayer, TradeMenu);
                                    break;
                                case 3:
                                    myPlayer.Travel(myPlayer, universe);
                                    break;
                                case 4:
                                    myPlayer.Refuel(true);
                                    break;
                                case 5:
                                    myPlayer.newShip(true);
                                    break;
                                case 6:
                                    Console.WriteLine("You chose to end the game.\n");
                                    Utilities.EndGameReport(myPlayer);
                                    keepLooping = false;
                                    break;
                            }
                            commandNotExecuted = false;
                        }
                        else
                        {
                            Console.Clear();
                            throw new Exception("\nInvalid Entry");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } while (commandNotExecuted);
                Console.WriteLine("\nCommand successfully executed. Press Enter to Continue.");
                Console.ReadLine();
                Console.Clear();
            } while (keepLooping);
        }
    }
}