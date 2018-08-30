using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Planet
    {
        public Planet(string name, double[] coordinates, double multiplier)
        {
            this.name = name;
            this.coordinates = coordinates;
            this.multiplier = multiplier;
        }

        private string name;
        private double[] coordinates = new double[2];
        private double multiplier;

        public string GetName() => this.name;
        public double[] GetCoordinates() => this.coordinates;
        public double GetMultiplier() => this.multiplier;
    }
}