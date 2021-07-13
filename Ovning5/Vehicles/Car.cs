using System;
using System.Text.Json.Serialization;

namespace Övning6.Vehicles
{
    public class Car : Vehicle

    {
        public string PetrolType { get; set; }

        public Car(string title, string color, int amountWheels, string regNum, int speed, string petrolType) : base(
            title, color, amountWheels, regNum, speed)
        {
            PetrolType = petrolType;
        }

        private readonly string[] PetrolTypePool = {"Gasoline", "Diesel"};

        public Car()
        {
            PetrolType = PetrolTypePool[new Random().Next() % 2];
        }

        public Car(string title, string color, int amountWheels, string regNum, int speed) : base(title, color,
            amountWheels, regNum, speed)
        {
        }

        public override string ToString()
        {
            return base.ToString() + $" Petrol: {PetrolType}";
        }
    }
}