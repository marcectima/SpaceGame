using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Ship 
    {
        public Ship(string model)
        {
            if (model == "Shuttlecraft")
            {
                this.modelName = model;
                this.price = 10000;
                this.speed = 3.0;
                this.cargoCapacity = 100;
                this.tankCapacity = 10;
            }
            else if (model == "Freighter")
            {
                this.modelName = model;
                this.price = 25000;
                this.speed = 5.0;
                this.cargoCapacity = 300;
                this.tankCapacity = 15;
            }
            else if (model == "Cruise Freighter")
            {
                this.modelName = model;
                this.price = 50000;
                this.speed = 7.5;
                this.cargoCapacity = 700;
                this.tankCapacity = 20;
            }
            else if (model == "Starship")
            {
                this.modelName = model;
                this.price = 100000;
                this.speed = 9.9;
                this.cargoCapacity = 1000;
                this.tankCapacity = 35;
            }
        }

        private string modelName;
        private double price;
        private double speed;
        private double tankCapacity;
        private int cargoCapacity;

        public string GetModelName() => modelName;
        public double GetPrice() => price;
        public double GetSpeed() => speed;
        public double GetTankCapacity() => tankCapacity;
        public int GetCargoCapacity() => cargoCapacity;

    }
}
