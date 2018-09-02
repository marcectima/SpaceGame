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
            if (modelName == "Shuttlecraft")
            {
                this.modelName = model;
                this.price = 10000;
                this.speed = 3.0;
                this.cargoCapacity = 100;
                this.tankCapacity = 10;
            }
            else if (modelName == "Freighter")
            {
                this.modelName = model;
                this.price = 25000;
                this.speed = 5.0;
                this.cargoCapacity = 300;
                this.tankCapacity = 15;
            }
            else if (modelName == "Cruise Freighter")
            {
                this.modelName = model;
                this.price = 50000;
                this.speed = 7.5;
                this.cargoCapacity = 700;
                this.tankCapacity = 20;
            }
            else if (modelName == "Starship")
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
        private int cargoCapacity;
        private int tankCapacity;

        public string GetModelName() => modelName;
        public double GetPrice() => price;
        public double GetSpeed() => speed;
        public int GetCargoCapacity() => cargoCapacity;
        public int GetTankCapacity() => tankCapacity;
    }
}
