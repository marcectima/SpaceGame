using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class PlanetarySystem
    {
        public PlanetarySystem(string name, int numberOfPlanets, List<Planet> planets)
        {
            this.name = name;
            this.numberOfPlanets = numberOfPlanets;
            this.planets = planets;
        }

        private string name;
        private int numberOfPlanets;
        private List<Planet> planets;

        public string GetName() => this.name;
        public int GetNumberOfPlanets() => this.numberOfPlanets;
        public List<Planet> GetPlanets() => this.planets;
    }
}
