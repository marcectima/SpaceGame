namespace SpaceGame
{
    internal class Model
    {
        public Model(string modelName)
        {
            if (modelName == "Shuttlecraft")
            {
                this.modelName = modelName;
                this.price = 10000;
                this.speed = 3.0;
                this.cargoCapacity = 100;
                this.tankCapacity = 10;
            }
            else if (modelName == "Freighter")
            {
                this.modelName = modelName;
                this.price = 25000;
                this.speed = 5.0; 
                this.cargoCapacity = 300;
                this.tankCapacity = 25;
            }
            else if (modelName == "Cruise Freighter")
            {
                this.modelName = modelName;
                this.price = 50000;
                this.speed = 7.5;
                this.cargoCapacity = 700;
                this.tankCapacity = 60;
            }
            else if (modelName == "Starship")
            {
                this.modelName = modelName;
                this.price = 100000;
                this.speed = 9.9;
                this.cargoCapacity = 1000;
                this.tankCapacity = 100;
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