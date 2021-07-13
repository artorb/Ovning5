using System;

namespace Övning6.Vehicles
{
    public class Boat : Vehicle
    {
        public int MaxKg { get; set; }

        public Boat(string title, string color, int amountWheels, string regNum, int speed, int maxKg) : base(title,
            color, amountWheels, regNum, speed)
        {
            MaxKg = maxKg;
        }

        public Boat(string title, string color, int amountWheels, string regNum, int speed) : base(title, color,
            amountWheels, regNum, speed)
        {
        }

        private readonly int[] KgPool = {60, 100, 200, 300, 10000};

        public Boat()
        {
            MaxKg = KgPool[new Random().Next() % 5];
        }

        public override string ToString()
        {
            return base.ToString() + $" KG: {KgPool}";
        }
    }
}