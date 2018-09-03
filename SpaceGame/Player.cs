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
                    Console.Write($"\nSelect your gender, {this.name}:\n1. {genderArray[0]}\n2. {genderArray[1]}\n\n>>> ");
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
        private List<Goods> cargo;
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

    }
}
