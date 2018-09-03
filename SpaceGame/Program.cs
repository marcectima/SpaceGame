﻿using System;
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
            // Create the univers
            List<PlanetarySystem> universe = Utilities.OperationGenesis();
            // Creates trading goods.
            Goods[] tradingGoods = Utilities.CreateTradingGoods();
            string[] TradeMenu = Utilities.CreateTradeMenus(tradingGoods);
            Console.WriteLine("\nWelcome to Space Trader");
            // Creates a new user.
            Player myPlayer = new Player();
            Console.Clear();
            // Opens action menu. This is where the game runs.
            ShowActionMenu(myPlayer, universe, tradingGoods, TradeMenu);
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
                                    Trade(tradingGoods, myPlayer, TradeMenu);
                                    break;
                                case 3:
                                    Travel(myPlayer, universe);
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

        // Identifies the Planets within reach with the current fuel level 
        private static List<Planet> ReachablePlanets(Player myPlayer, List<PlanetarySystem> universe)
        {
            double maxRange = 0.0;
            List<Planet> reachablePlanets = new List<Planet>();

            // 1 ton of fuel is spent to travel 1 lightyear, regardless of the ship's model
            maxRange = myPlayer.GetFuel();
            // loops through all planets and creates a list of all the reachable ones
            for (int i = 0; i < universe.Count(); i++)
            {
                for (int j = 0; j < universe[i].GetPlanets().Count(); j++)
                {
                    // Ensures that the current location is not listed
                    if (universe[i].GetPlanets()[j].GetName() != myPlayer.GetLocation().GetName())
                    {
                        // Compares the distance of the next planet on the list to the maximum distance possible to travel with current fuel level
                        if (GetDistance(myPlayer.GetLocation().GetCoordinates(), universe[i].GetPlanets()[j].GetCoordinates()) <= maxRange)
                        {
                            reachablePlanets.Add(universe[i].GetPlanets()[j]);
                        }
                    }
                }
            }
            return reachablePlanets;
        }

        // Calculates the distance between two planets in lightyears
        private static double GetDistance(double[] from, double[] to)
        {
            return Math.Sqrt(Math.Pow((from[0] - to[0]), 2) + Math.Pow((from[1] - to[1]), 2));
        }

        // Calculates the time spent on each trip in years
        private static double GetTimeElapsed(double distance, double W)
        {
            return distance / (Math.Pow(W, 10.0 / 3.0) + Math.Pow(10 - W, -11.0 / 3.0));
        }

        // Executes the trading decisions
        private static void Trade(Goods[] tradingGoods, Player myPlayer, string[] TradeMenu)
        {
            string buyMenu = TradeMenu[0];
            string sellMenu = TradeMenu[1];
            Console.Write("\nSelect from the following options:\n\n1. buy\n2. sell\n\n>>> ");
            MenuSelection tradeMode = new MenuSelection(Console.ReadLine().Trim());
            if (tradeMode.GetSelection() == 1)
            {
                Console.WriteLine(buyMenu);
                MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());

                Console.WriteLine("How many units would you like to buy?");
                MenuSelection quantity = new MenuSelection(Console.ReadLine().Trim());

                // Checks if there is enough room in the ship's cargo bay 
                if (myPlayer.GetCargo().Count() + quantity.GetSelection() <= myPlayer.GetShip().GetCargoCapacity())
                {
                    // Adds an item to the player's cargo
                    myPlayer.AddCargo(tradingGoods[selection.GetSelection()]);

                    // Updates the user's wallet 
                    myPlayer.SetWallet(-tradingGoods[selection.GetSelection()].GetPrice() * myPlayer.GetLocation().GetMultiplier());
                }
                else
                {
                    Console.WriteLine("The ship's cargo is full.");
                }
            }
            else if (tradeMode.GetSelection() == 2)
            {
                Console.WriteLine(sellMenu);
                MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());

                // Counts how many of selected items does the user have in his cargo
                int count = 0;
                foreach (Goods good in myPlayer.GetCargo())
                {
                    if (good.GetName() == tradingGoods[selection.GetSelection()].GetName())
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    Console.WriteLine("How many units would you like to sell?\n\n>>> ");
                    MenuSelection quantity = new MenuSelection(Console.ReadLine().Trim());
                    if (quantity.GetSelection() <= count)
                    {
                        // removes the sold item from the user's cargo
                        myPlayer.RemoveCargo(tradingGoods[selection.GetSelection()]);

                        // Updates the user's wallet. 10% sales tax is added.
                        myPlayer.SetWallet(tradingGoods[selection.GetSelection()].GetPrice() * myPlayer.GetLocation().GetMultiplier() * 1.1);
                    }
                }
            }
        }

        // Updates user location and travel time
        private static void Travel(Player myPlayer, List<PlanetarySystem> universe)
        {
            double[] from = myPlayer.GetLocation().GetCoordinates();
            double[] to = new double[2];
            double distance = 0;
            double travelTime = 0;
            double W = myPlayer.GetShip().GetSpeed();
            List<Planet> destinationList = new List<Planet>();
            try
            {
                destinationList = ReachablePlanets(myPlayer, universe);

                string menuList = "\n";
                for (int i = 0; i < destinationList.Count(); i++)
                {
                    menuList += $"{i + 1}. {destinationList[i].GetName()}";
                    if (((i + 1) % 5 != 0) || (i == 0))
                    { menuList += " \t"; }
                    else
                    { menuList += "\n"; }
                }
                Console.Write($"\nWhere would you like to travel to:\n" + menuList + "\n\n>>> ");
                MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());
                if (Enumerable.Range(1, destinationList.Count()).Contains(selection.GetSelection()))
                {
                    to = destinationList[selection.GetSelection() - 1].GetCoordinates();
                    Planet destination = destinationList[selection.GetSelection() - 1];
                    // Calculating the distance and time traveled
                    distance = GetDistance(from, to);
                    travelTime = GetTimeElapsed(distance, myPlayer.GetShip().GetSpeed());
                    // Updates the user's travel time
                    myPlayer.SetTravelTime(travelTime);
                    // Checks to total time elapsed
                    if (myPlayer.GetTravelTime() >= 40)
                    {
                        Utilities.EndGameReport(myPlayer);
                        Environment.Exit(-1);
                    }
                    // Updates the user's location
                    myPlayer.SetLocation(destination);
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
        }




    }
}