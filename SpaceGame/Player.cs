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
            // enter user's name
            Console.Write("\nType your name\n\n>>> ");
            string input = Console.ReadLine().Trim();
            if (input != "")
            {this.name = input;}
            else
            {throw new Exception("Invalid Entry");}

            // enter user's gender
            Console.Write("\nSelect your gender\n1. Male\n2. Female\n\n>>> ");
            if (Console.ReadLine().Trim() == "1")
            {this.gender = "Male";}
            else if (Console.ReadLine().Trim() == "2")
            {this.gender = "Female";}
            else
            {throw new Exception("Invalid Entry");}

            // mark starting point as Earth
            double[] startingPoint = { 0.0, 0.0 };
            this.location = new Planet("Earth", startingPoint, 1);

            // give starting credits to the player
            this.wallet = 15000;

            // Set travel time to zero at the beginning of the game
            this.travelTime = 0;

            // prompt the user to purchase a ship
            this.ship = newShip();

            // Updates user's wallet.
            SetWallet(-ship.GetPrice());
            Console.Clear();

            Refuel();
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
        public Ship newShip()
        {
            string model = "";
            string[] modelNames = { "Shuttlecraft", "Freighter", "Cruise Freighter", "Starship" };
            Console.Write("Select the type of ship you want to purchase:\n1. Shuttlecraft\n2. Freighter\n3. Cruise Freighter\n4. Starship\n\n>>> ");
            model = modelNames[int.Parse(Console.ReadLine().Trim()) - 1];
            return new Ship(model);
        }

        // Allows the user to buy fuel
        public void Refuel()
        {
            Console.Write("\nHow many tons of fuel do you wish to buy?\n\n>>> ");
            SetFuel(Double.Parse(Console.ReadLine().Trim()));
        }

        // Displays information about user and currentShip
        public void ShowStatus(Player myPlayer)
        {
            Console.WriteLine($"wallet: {myPlayer.GetWallet()}");
            Console.WriteLine($"travel time: {myPlayer.GetTravelTime()}");
            Console.WriteLine($"location: {myPlayer.GetLocation()}");
            Console.WriteLine($"fuel: {myPlayer.GetFuel()}");
        }

    }
}
