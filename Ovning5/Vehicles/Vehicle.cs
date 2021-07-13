using System;
using System.Text.Json.Serialization;

namespace Övning6.Vehicles
{
    [Serializable]
    public class Vehicle : IVehicle
    {
        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("RegNumber")]
        public string RegNumber { get; set; }

        [JsonPropertyName("Color")]
        public string Color { get; set; }

        // private Type type;
        //
        // public Type Type => this.GetType();

        [JsonPropertyName("Speed")]
        public int Speed { get; set; }
        
        [JsonPropertyName("AmountWheels")]
        public int AmountWheels { get; set; }


        public Vehicle(string title, string color, int amountWheels, int speed)
        {
            Speed = speed;
            Title = title;
            RegNumber = Guid.NewGuid().ToString().Substring(0, 8);
            Color = color;
            AmountWheels = amountWheels;
        }

        public Vehicle(string title, string color, int amountWheels, string regNum, int speed)
        {
            Speed = speed;
            Title = title;
            RegNumber = regNum;
            Color = color;
            AmountWheels = amountWheels;
        }


        private readonly string[] ColorPool = {"Green", "Red", "Black", "Yellow", "Cyan", "Blue", "Orange", "White"};
        private readonly string[] TitlePool = {"Mercedes", "Toyota", "Suzuki", "Boeing", "BMW", "Jeep", "Skoda", "Volvo"};
        private readonly int[] SpeedPool = {150, 120, 100, 90, 15, 25, 40, 200, 500, 10};
        private readonly int[] WheelPool = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        public Vehicle() // pseudo-randomized vehicle for populate method
        {
            var random = new Random();
            Title = TitlePool[random.Next() % 8];
            Color = ColorPool[random.Next() % 8];
            Speed = SpeedPool[random.Next() % 10];
            AmountWheels = WheelPool[random.Next() % 10];
            RegNumber = Guid.NewGuid().ToString().Substring(0, 8);
        }

        public override string ToString()
        {
            return $"Title: {Title}, Speed: {Speed}. Wheels: {AmountWheels}, Color: {Color}, RegNumber: {RegNumber}";
        }
    }
}