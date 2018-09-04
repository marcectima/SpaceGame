using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Utilities
    {
        // Creates the Universe
        public static List<PlanetarySystem> OperationGenesis()
        {
            string systemName = "";
            string planetName = "";
            int numberOfPlanets = 0;
            double x = 0.0;
            double y = 0.0;
            double multiplier = 0.0;
            Random rnd = new Random();
            List<Planet>[] listOfPlanets = new List<Planet>[50];
            List<double[]> coordinates = new List<double[]>();
            List<PlanetarySystem> universe = new List<PlanetarySystem>();
            int planetCount = 0;

            // Populates the univrse with 50 planetary systems, each one of which have up to 10 planets. 
            for (int i = 0; i < 50; i++)
            {
                // Generating a random name for a system
                char letter = (char)rnd.Next(65, 90);
                int number = rnd.Next(999);
                systemName = letter + Convert.ToString(number);

                // Generating coordinates for the planetary system
                x = Math.Round(rnd.NextDouble() * 100.0 - 50.0, 4);
                y = Math.Round(rnd.NextDouble() * 100.0 - 50.0, 4);

                // Generating a list of planets for the system 
                listOfPlanets[i] = new List<Planet>();
                numberOfPlanets = rnd.Next(1, 10);
                for (int j = 0; j < numberOfPlanets; j++)
                {
                    if (i == 0)
                    {
                        //Create the solar system
                        numberOfPlanets = 8;
                        string[] ssPlanets = { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptun" };
                        double[,] ssCoordinates = new double[,] { { 0.0, -0.0039 }, { 0.0, -0.0030 }, { 0.0, 0.0 }, { 0.0, 0.004 }, { 0.0, 0.0078 }, { 0.0, 0.0105 }, { 0.0, 0.015 }, { 0.0, 0.023 } };
                        multiplier = 1;
                        listOfPlanets[i].Add(new Planet(ssPlanets[j], new double[] { ssCoordinates[j, 0], ssCoordinates[j, 1] }, multiplier));
                    }
                    else
                    {
                        // creates an array of coordinates for the planet and adds it to the list of coordinates
                        coordinates.Add(new double[2]);
                        // Generating a random name for a system
                        planetName = systemName + "-" + Convert.ToString(j + 1);
                        // Generating coordinates within .005 lightyear radius around the system center. 
                        x = x + Math.Round((rnd.NextDouble() * .01 - .005), 4);
                        y = y + Math.Round((rnd.NextDouble() * .01 - .005), 4);
                        coordinates[planetCount][0] = x;
                        coordinates[planetCount][1] = y;
                        // Generating a random number between 0.5 and 2.0
                        multiplier = rnd.NextDouble() * (2.0 - 0.5) + 0.5;
                        // adds the created planet to the list of planets
                        listOfPlanets[i].Add(new Planet(planetName, coordinates[planetCount], multiplier));
                        planetCount++;
                    }
                }
                // adds the created planetary system to the universe
                universe.Add(new PlanetarySystem(systemName, numberOfPlanets, listOfPlanets[i]));
            }
            return universe;
        }

        // Generates trading goods
        public static Goods[] CreateTradingGoods()
        {
            Goods[] arrayOfGoods = new Goods[10];
            {
                arrayOfGoods[0] = new Goods("silver", 249.99, 10);
                arrayOfGoods[1] = new Goods("Palladium", 499.99, 9);
                arrayOfGoods[2] = new Goods("Iridium", 749.99, 8);
                arrayOfGoods[3] = new Goods("gold", 999.99, 7);
                arrayOfGoods[4] = new Goods("Platinum", 1449.99, 6);
                arrayOfGoods[5] = new Goods("diamonds", 2249.99, 5);
                arrayOfGoods[6] = new Goods("Painite", 2999.99, 4);
                arrayOfGoods[7] = new Goods("Rhodium", 4499.99, 3);
                arrayOfGoods[8] = new Goods("Dilithium Crystals", 7249.99, 2);
                arrayOfGoods[9] = new Goods("Neutronium", 9999.99, 1);
            }
            return arrayOfGoods;
        }

        // Creates Trade Menu Lists
        public static string[] CreateTradeMenus(Goods[] tradingGoods)
        {
            // Building the output strings for buy and sell menues
            string itemList = "";
            int count = 1;
            foreach (Goods good in tradingGoods)
            {

                itemList += count++ + ". " + good.GetName() + "\n";
                if (count == 11)
                {
                    itemList += "\n>>> ";
                }
            }
            string[] tradeMenu = { "\nWhat would you like to buy?\n\n" + itemList, "\nWhat would you like to sell?\n\n" + itemList };
            return tradeMenu;
        }

        // Displays the endgame stats.
        public static void EndGameReport(Player myPlayer)
        {
            myPlayer.ShowStatus();
            Console.WriteLine("\nYour Journey is over. ");
            Console.WriteLine($"You started the game with 15000 credits and ended with {myPlayer.GetWallet()}." +
                              $"\nYou are leaving the game with an overall profit of {myPlayer.GetWallet() - 15000}." +
                              $"\nYour overall travel time in the universe is {myPlayer.GetTravelTime()} years." +
                              $"\n\nBest of luck to you in real life.");
            // Quits the Game
            Environment.Exit(-1);
        }
    }
}
