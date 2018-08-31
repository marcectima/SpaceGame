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
            // Create the univers
            List<PlanetarySystem> universe = OperationGenesis();
            Planet currentPlanet = universe[49].GetPlanets()[2]; 

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nWelcome to Space Trader");

            // Creates a new user.
            Player myPlayer = CreateUser();
            Console.Clear();

            Console.WriteLine($"\nHello {myPlayer.GetName()}. Your character has been created and awarded with 15,000 credits to start the game.");
            Console.WriteLine("\nPress Enter to Continue");
            Console.ReadLine();
            Console.Clear();

            // Purchase the first ship.
            Ship myShip = CreateShip(myPlayer);
            Refuel(myPlayer);
            Console.Clear();

            // Opens action menu. This is where the game runs.
            ShowActionMenu(myPlayer, myShip, currentPlanet, universe);
            Environment.Exit(-1);
        }
        
        // Action menu
        private static void ShowActionMenu(Player myPlayer, Ship myShip, Planet currentPlanet, List<PlanetarySystem> universe )
        {
            bool keepLooping = true;
            do
            {
                try
                {
                    Console.Write("Select from the following options:\n1. Status\n2. Trade\n3. Travel to...\n4. Change ship\n5. Quit game\n\n>>> ");
                    int selection = int.Parse(Console.ReadLine());
                    switch (selection)
                    {
                        case 1:
                            ShowStatus(myPlayer, myShip);
                            break;
                        case 2:
                            Trade(myPlayer, myShip, currentPlanet);
                            break;
                        case 3:
                            Travel(myPlayer, myShip, currentPlanet, universe);
                            break;
                        case 4:
                            myShip = CreateShip(myPlayer);
                            break;
                        case 5:
                            Console.WriteLine("You chose to end the game.\n");
                            EndGameReport(myPlayer, myShip);
                            keepLooping = false;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("\nPress Enter to Continue");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (keepLooping);
        }

        // Updates user location and travel time
        private static void Travel(Player myPlayer, Ship myShip, Planet currentPlanet, List<PlanetarySystem> universe)
        {
            double[] from = currentPlanet.GetCoordinates();
            double[] to = new double[2];
            string whereTo = "";
            double distance = 0;
            double travelTime = 0;
            double W = myShip.GetSpeed();
            List<Planet> destinationList = new List<Planet>();
            try
            {
                destinationList = ReachablePlanets(myPlayer, myShip, currentPlanet, universe);

                string menuList = "";
                for (int i = 0; i < destinationList.Count(); i++)
                {
                    menuList += $"\n{i+1}. {destinationList[i].GetName()}";
                }
                Console.WriteLine($"Where would you like to travel to:" + menuList);

                // Calculating the distance and time traveled
                distance = GetDistance(from, to);
                travelTime = GetTimeElapsed(distance, myShip.GetSpeed());

                // Updates the user's travel time
                myPlayer.SetTravelTime(travelTime);

                // Checks to total time elapsed
                if (myPlayer.GetTravelTime() >= 40)
                {
                    EndGameReport(myPlayer, myShip);
                    Environment.Exit(-1);
                }

                // Updates the user's location
                myPlayer.SetLocation(whereTo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Identifies the Planets within reach with the current fuel level 
        private static List<Planet> ReachablePlanets(Player myPlayer, Ship myShip, Planet currentPlanet, List<PlanetarySystem> universe)
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
                    if (universe[i].GetPlanets()[j].GetName() != currentPlanet.GetName())
                    { 
                        // Compares the distance of the next planet on the list to the maximum distance possible to travel with current fuel level
                        if(GetDistance(currentPlanet.GetCoordinates(), universe[i].GetPlanets()[j].GetCoordinates()) <= maxRange)
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
        private static void Trade(Player myPlayer, Ship myShip, Planet currentPlanet)
        {
            // Creates trading goods.
            Goods[] tradingGoods = CreateTradingGoods();
             
            int selection = 0;
            int quantity = 0;
            
            // Building the output strings for buy and sell menues
            string itemList = "";
            foreach (Goods good in tradingGoods)
            {
                int count = 1;
                itemList += count++ + ". " + good.GetName() + "\n";
                if (count == 10)
                {
                    itemList += "\n >>> ";
                }
            }
            string buyMenu = "What would you like to buy? \n" + itemList;
            string sellMenu = "What would you like to sell? \n" + itemList;
            
            Console.WriteLine("Select from the following options: \n1. buy\n2. sell\n\n >>> ");
            int tradeMode = int.Parse(Console.ReadLine().Trim());
            if (tradeMode == 1)
            {
                Console.WriteLine(buyMenu);
                selection = int.Parse(Console.ReadLine().Trim());

                Console.WriteLine("How many units would you like to buy?");
                quantity = int.Parse(Console.ReadLine().Trim());

                // Checks if there is enough room in the ship's cargo bay 
                if (myPlayer.GetCargo().Count() + quantity <= myShip.GetCargoCapacity())
                {
                    // Adds an item to the player's cargo
                    myPlayer.AddCargo(tradingGoods[selection]);

                    // Updates the user's wallet 
                    myPlayer.SetWallet(-tradingGoods[selection].GetPrice() * currentPlanet.GetMultiplier());
                }
                else
                {
                    Console.WriteLine("The ship's cargo is full.");
                }
            }
            else if (tradeMode == 2)
            {
                Console.WriteLine(sellMenu);
                selection = int.Parse(Console.ReadLine().Trim());

                // Counts how many of selected items does the user have in his cargo
                int count = 0;
                foreach (Goods good in myPlayer.GetCargo())
                {
                    if (good.GetName() == tradingGoods[selection].GetName())
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    Console.WriteLine("How many units would you like to sell?\n\n>>> ");
                    int sellQuantity = int.Parse(Console.ReadLine().Trim());
                    if (sellQuantity <= count)
                    {
                        // removes the sold item from the user's cargo
                        myPlayer.RemoveCargo(tradingGoods[selection]);

                        // Updates the user's wallet. 10% sales tax is added.
                        myPlayer.SetWallet(tradingGoods[selection].GetPrice() * currentPlanet.GetMultiplier() * 1.1);
                    }
                }
            }
        }

        // Displays information about user and currentShip
        private static void ShowStatus(Player myPlayer, Ship myShip)
        {
            Console.WriteLine($"wallet: {myPlayer.GetWallet()}");
            Console.WriteLine($"travel time: {myPlayer.GetTravelTime()}");
            Console.WriteLine($"location: {myPlayer.GetLocation()}");
            Console.WriteLine($"fuel: {myPlayer.GetFuel()}");
        }

        // Purchasing a ship
        private static Ship CreateShip(Player myPlayer)
        {
            string model = "";
            string[] modelNames = { "Shuttlecraft", "Freighter", "Cruise Freighter", "Starship" };

            try
            {
                // prompts the user to select a ship
                Console.Write("Select the type of ship you want to purchase:\n1. Shuttlecraft\n2. Freighter\n3. Cruise Freighter\n4. Starship\n\n>>> ");
                model = modelNames[int.Parse(Console.ReadLine().Trim()) - 1 ];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Ship myShip = new Ship(model);

            // Updates user's wallet.
            myPlayer.SetWallet(-myShip.GetPrice());

            return myShip;
        }

        // Creates a player
        private static Player CreateUser()
        {
            string playerName = "";
            string gender = "";
            string location = "";
            double wallet = 0;
            double travelTime = 0;

            var keepLookping = true;
            do
            {
                try
                {
                    // enter user;s name
                    Console.Write("\nType your name\n\n>>> ");
                    string input = Console.ReadLine().Trim();
                    if (input != "")
                    {
                        playerName = input;
                    }
                    else
                    {
                        throw new Exception("Invalid Entry");
                    }

                    // enter user's gender
                    Console.Write("\nSelect your gender\n1. Male\n2. Female\n\n>>> ");
                    if (Console.ReadLine().Trim() == "1")
                    {
                        gender = "Male";
                    }
                    else if (Console.ReadLine().Trim() == "2")
                    {
                        gender = "Female";
                    }
                    else
                    {
                        throw new Exception("Invalid Entry");
                    }

                    // mark starting point as Earth
                    location = "Earth";

                    // give starting credits to the player
                    wallet = 15000.00;

                    // Set travel time to zero at the beginning of the game
                    travelTime = 0;

                    keepLookping = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (keepLookping);

            // create a new player based on the inputted and initial parameters
            return new Player(playerName, gender, location, wallet, travelTime);
        }

        // Creates the Universe
        private static List<PlanetarySystem> OperationGenesis()
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
                char letter = (char)rnd.Next(65,90);
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
                    if (i < 49)
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
                    else
                    {
                        //Create the solar system
                        numberOfPlanets = 8;
                        string[] ssPlanets = { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptun" };
                        double[,] ssCoordinates = new double[,] { { 0.0, -0.0039 }, { 0.0, -0.0030 }, { 0.0, 0.0 }, { 0.0, 0.004 }, { 0.0, 0.0078 }, { 0.0, 0.0105 }, { 0.0, 0.015 }, { 0.0, 0.023 } };
                        multiplier = 1;
                        listOfPlanets[i].Add(new Planet(ssPlanets[j], new double[] {ssCoordinates[j , 0], ssCoordinates[j , 1]}, multiplier));
                    }
                }
                // adds the created planetary system to the universe
                universe.Add(new PlanetarySystem(systemName, numberOfPlanets, listOfPlanets[i]));
            }
            return universe;
        }

        // Allows the user to buy fuel
        private static void Refuel(Player myPlayer)
        {
            Console.Write("\nHow many tons of fuel do you wish to buy?\n\n>>> ");
            FuelControl(myPlayer, double.Parse(Console.ReadLine()));
        }

        // Increase or decrease fuel level
        private static void FuelControl(Player myPlayer, double fuel)
        {
            myPlayer.SetFuel(fuel);
        }

        // Generates trading goods
        private static Goods[] CreateTradingGoods()
        {
            Goods[] arrayOfGoods = new Goods[10];
            {
                arrayOfGoods[0] = new Goods("silver", 249.99, 10);
                arrayOfGoods[0] = new Goods("Palladium", 499.99, 9);
                arrayOfGoods[0] = new Goods("Iridium", 749.99, 8);
                arrayOfGoods[0] = new Goods("gold", 999.99, 7);
                arrayOfGoods[0] = new Goods("Platinum", 1449.99, 6);
                arrayOfGoods[0] = new Goods("diamonds", 2249.99, 5);
                arrayOfGoods[0] = new Goods("Painite", 2999.99, 4);
                arrayOfGoods[0] = new Goods("Rhodium", 4499.99, 3);
                arrayOfGoods[0] = new Goods("Dilithium Crystals", 7249.99, 2);
                arrayOfGoods[0] = new Goods("Neutronium", 9999.99, 1);
            }
            return arrayOfGoods;
        }

        // Displays the endgame stats.
        private static void EndGameReport(Player myPlayer, Ship myShip)
        {
            ShowStatus(myPlayer, myShip);
            Console.WriteLine("\nYour Journey is over. ");
            Console.WriteLine($"You started the game with 15000 credits and ended with {myPlayer.GetWallet()}." +
                              $"\nYou are leaving the game with an overall profit of {myPlayer.GetWallet() - 15000}." +
                              $"\nYour overall travel time in the universe is {myPlayer.GetTravelTime()} years." +
                              $"\n\nBest of luck to you in real life.");
            Console.WriteLine("                                                             " +
                  "\n                                                                       " +
                  "\n                                                                       " +
                  "\n                                                                       " +
                  "\n                  \"Live long and prosper\"                            " +
                  "\n                                                                       " +
                  "\n                                                                       " +
                  "\n                                                                       " +
                  "\n             __                        ___                             " +
                  "\n           /    \\                    /    \\                          " +
                  "\n          |      \\                  /      |___                       " +
                  "\n         __\\      \\                /       /    \\                   " +
                  "\n       /    \\      \\              /       /      |                   " +
                  "\n      |      \\      \\            /       /       /                   " +
                  "\n       \\      \\      \\          /       /       /                   " +
                  "\n        \\      \\      \\        /       /       /                    " +
                  "\n         \\      \\      \\      /       /       /                     " +
                  "\n          \\      \\      \\    /       /       /                      " +
                  "\n           \\      \\      \\__/       /       /                       " +
                  "\n            \\      \\               /       /                         " +
                  "\n             \\      \\             /       /               __         " +
                  "\n              \\                          |           ___/   \\        " +
                  "\n              |                         |       ___/        |          " +
                  "\n              |                          \\____/          __/          " +
                  "\n              |                                       __/              " +
                  "\n              |                                   ___/                 " +
                  "\n              |                                __/                     " +
                  "\n              \\                             __/                       " +
                  "\n               \\                         __/                          " +
                  "\n                \\                     __/                             " +
                  "\n                 |                   /                                 " +
                  "\n                                                                       " +
                  "\n                                                                       ");
        }
    }
}