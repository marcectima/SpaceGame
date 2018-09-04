using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Player
    {
        public Player()
        {
            bool keepLooping = true;
            // enter user's name
            do
            {
                try
                {
                    Console.Write("\nType your name\n\n>>> ");
                    string input = Console.ReadLine().Trim();
                    if (input != "")
                    {
                        this.name = input;
                        keepLooping = false;
                        Console.Clear();
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
            } while (keepLooping);
            // enter user's gender
            keepLooping = true;
            do
            {
                try
                {
                    string[] genderArray = { "Male", "Female" };
                    Console.Write($"\nSelect your gender, {this.name}:\n\n1. {genderArray[0]}\n2. {genderArray[1]}\n\n>>> ");
                    MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());
                    if (Enumerable.Range(1, 2).Contains(selection.GetSelection()))
                    {
                        this.gender = genderArray[selection.GetSelection() - 1];
                        keepLooping = false;
                        Console.Clear();
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
            } while (keepLooping);
            // mark starting point as Earth
            double[] startingPoint = { 0.0, 0.0 };
            this.location = new Planet("Earth", startingPoint, 1);
            // give starting credits to the player
            this.wallet = 15000;
            // Set travel time to zero at the beginning of the game
            this.travelTime = 0;
            Console.WriteLine($"\nHello {this.GetName()}. Your character has been created and awarded with 15,000 credits to start the game.");
            Console.WriteLine("\nPress Enter to Continue");
            Console.ReadLine();
            Console.Clear();
            // prompt the user to purchase a ship
            this.ship = newShip(true);
            Console.Clear();
            // Updates user's wallet.
            SetWallet(-ship.GetPrice());
            Console.Clear();
            Refuel(true);
            Console.Clear();
        }

        private string name;
        private string gender;
        private Planet location;
        private double wallet;
        private double travelTime;
        private double fuel;
        private List<Goods> cargo = new List<Goods>();
        private Ship ship;

        public string GetName() => this.name;
        public void SetName(string name) => this.name = name;

        public string GetGender() => this.gender;
        public void SetGender(string gender) => this.gender = gender;

        public Planet GetLocation() => this.location;
        public void SetLocation(Planet location) => this.location = location;

        public double GetWallet() => this.wallet;
        public void SetWallet(double wallet) => this.wallet += wallet;

        public double GetTravelTime() => this.travelTime;
        public void SetTravelTime(double travelTime) => this.travelTime += travelTime;

        public double GetFuel() => this.fuel;
        public void SetFuel(double fuel) => this.fuel += fuel;

        public List<Goods> GetCargo() => this.cargo;
        public int GetCargoCount() => this.cargo.Count();
        public void AddCargo(Goods cargo) => this.cargo.Add(cargo);
        public void RemoveCargo(Goods cargo) => this.cargo.Remove(cargo);

        public Ship GetShip() => this.ship;



        // Buy goods
        public void BuyGoods(string buyMenu, Goods[] tradingGoods)
        {
            bool keepLooping = true;
            do
            {
                try
                {
                    if (GetCargo().Count() != GetShip().GetCargoCapacity())
                    {
                        Console.Write(buyMenu);
                        MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());
                        if (Enumerable.Range(1, 10).Contains(selection.GetSelection()))
                        {
                            Console.Write("\nHow many units would you like to buy?\n\n>>> ");
                            MenuSelection quantity = new MenuSelection(Console.ReadLine().Trim());
                            // Checks if there is enough room in the ship's cargo bay 
                            if (GetCargo().Count() + quantity.GetSelection() <= GetShip().GetCargoCapacity())
                            {
                                // Adds an item to the player's cargo
                                for (int i = 0; i < quantity.GetSelection(); i++)
                                {
                                    AddCargo(tradingGoods[selection.GetSelection()]);
                                }
                                // Updates the user's wallet 
                                SetWallet(-tradingGoods[selection.GetSelection()].GetPrice() * GetLocation().GetMultiplier());
                                keepLooping = false;
                            }
                            else
                            {
                                throw new Exception("\nThere isn't enough room in the ship's cargo bay for the selected quantity. Select fewer items.");
                            }
                        }
                        else
                        {
                            throw new Exception("\nInvalid Entry");
                        }
                    }
                    else
                    {
                        keepLooping = false;
                        throw new Exception("\nThe ship's cargo bay is full. Sell some goods before you attempt to purchase more.");
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            } while (keepLooping);
        }

        // Sell goods
        public void SellGoods(string sellMenu, Goods[] tradingGoods)
        {
            bool keepLooping = true;
            do
            {
                try
                {
                    Console.Write(sellMenu);
                    MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());
                    if (Enumerable.Range(1, 10).Contains(selection.GetSelection()))
                    {
                        // Counts how many of selected items does the user have in his cargo
                        int count = 0;
                        foreach (Goods good in GetCargo())
                        {
                            if (good.GetName() == tradingGoods[selection.GetSelection()].GetName())
                            {
                                count++;
                            }
                        }
                        if (count > 0)
                        {
                            Console.Write("\nHow many units would you like to sell?\n\n>>> ");
                            MenuSelection quantity = new MenuSelection(Console.ReadLine().Trim());

                            if (quantity.GetSelection() <= count)
                            {
                                // removes the sold item from the user's cargo
                                for (int i = 0; i < quantity.GetSelection(); i++)
                                {
                                    RemoveCargo(tradingGoods[selection.GetSelection()]);
                                }
                                // Updates the user's wallet. 10% sales tax is added.
                                SetWallet(tradingGoods[selection.GetSelection()].GetPrice() * quantity.GetSelection() * GetLocation().GetMultiplier() * 1.1);
                                keepLooping = false;
                            }
                            else
                            {
                                int number = 0;
                                foreach (Goods good in GetCargo())
                                {
                                    if (good.GetName() == tradingGoods[selection.GetSelection()].GetName())
                                        number++;
                                }
                                throw new Exception($"\nYou have only {number} {tradingGoods[selection.GetSelection()].GetName()} in your cargo bay.");
                            }
                        }
                        else
                        {
                            keepLooping = false;
                            throw new Exception("\nYou don't have any of the selected goods in the cargo bay.");
                        }
                    }
                    else
                    {
                        throw new Exception("\nInvalid Entry");
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            } while (keepLooping);
        }

        // Updates user location and travel time
        public void Travel(Player myPlayer, List<PlanetarySystem> universe)
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

        // Purchase a ship
        public Ship newShip(bool keepLooping)
        {
            string model = "";
            do
            {
                try
                {
                    Console.WriteLine($"\nWallet: {this.GetWallet()} credits");

                    string[] modelNames = { "Shuttlecraft", "Freighter", "Cruise Freighter", "Starship" };
                    Console.Write($"\nSelect the type of ship you want to purchase, {this.name}:\n" +
                        $"\n1. {modelNames[0]}\t\t10,000 credits" +
                        $"\n2. {modelNames[1]}\t\t25,000 credits" +
                        $"\n3. {modelNames[2]}\t50,000 credits" +
                        $"\n4. {modelNames[3]}\t\t100,000 credits\n\n>>> ");
                    MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());
                    if (Enumerable.Range(1, 4).Contains(selection.GetSelection()))
                    {
                        model = modelNames[selection.GetSelection() - 1];
                        Ship newShip = new Ship(model);
                        if (this.GetWallet() >= newShip.GetPrice())
                        {
                            keepLooping = false;
                        }
                        else
                        {
                            Console.Clear();
                            throw new Exception("\nYou don't have enough credits to purchase the selected model.");
                        }
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
            } while (keepLooping);
            return new Ship(model);
        }

        // Allows the user to buy fuel
        public void Refuel(bool keepLooping)
        {
            // Adjusts the fuel price based on the planet the user is currently on
            double fuelPrice = 100 * this.location.GetMultiplier();

            do
            {
                try
                {
                    double tank = this.GetShip().GetTankCapacity();
                    double fuelLevel = this.GetFuel();
                    Console.WriteLine($"\nFuel Level:\t\t{fuelLevel} tons" +
                                      $"\nTank Capacity:\t\t{tank} tons" +
                                      $"\nFuel Price:\t\t{fuelPrice} credits per ton");
                    Console.Write("\nHow many tons of fuel do you wish to buy?\n\n>>> ");
                    double selection = double.Parse(Console.ReadLine());
                    if (selection >= 0 && selection <= tank - fuelLevel)
                    {
                        if (this.GetWallet() >= selection * fuelPrice)
                        {
                            SetFuel(selection);
                            keepLooping = false;
                        }
                        else
                        {
                            throw new Exception("\nYou don't have enough credits to buy that much fuel. Enter a smaller amount.");
                        }
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
            } while (keepLooping);
        }

        // Displays information about user and currentShip
        public void ShowStatus(Player myPlayer)
        {
            Console.WriteLine($"\nwallet: {myPlayer.GetWallet()}\ntravel time: {myPlayer.GetTravelTime()}\nlocation: {myPlayer.GetLocation()}\nfuel: {myPlayer.GetFuel()}");
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
    }
}
