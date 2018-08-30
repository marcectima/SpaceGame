using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Player
    {
        public Player(string name, string gender, string location, double wallet, double travelTime)
        {
            this.name = name;
            this.gender = gender;
            this.location = location;
            this.wallet = wallet;
            this.travelTime = travelTime;
            this.fuel = 0.0;
        }

        private string name;
        private string gender;
        private string location;
        private double wallet;
        private double travelTime;
        private double fuel;
        private List<Goods> cargo;

        // private Ship ship;

        public string GetName() => this.name;
        public void SetName(string name) => this.name = name;

        public string GetGender() => this.gender;
        public void SetGender(string gender) => this.gender = gender;

        public string GetLocation() => this.location;
        public void SetLocation(string location) => this.location = location;

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


    }
}
