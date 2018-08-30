using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Ship 
    {
        public Ship(string modelName)
        {
            this.model = new Model(modelName);
        }

        private Model model;

        public string GetModel() => model.GetModelName();
        public double GetPrice() => model.GetPrice();
        public double GetSpeed() => model.GetSpeed();
        public int GetCargoCapacity() => model.GetCargoCapacity();
        public int GetTankCapacity() => model.GetTankCapacity();

    }
}
