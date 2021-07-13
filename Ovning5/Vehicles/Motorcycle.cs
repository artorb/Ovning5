using System;

namespace Övning6.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public int Cylinders { get; set; }

        public Motorcycle(string title, string color, int amountWheels, string regNum, int speed, int cylinders) : base(title, color, amountWheels, regNum, speed)
        {
            Cylinders = cylinders;
        }
        public Motorcycle(string title, string color, int amountWheels, string regNum, int speed) : base(title, color, amountWheels, regNum, speed)
        {
        }

        private readonly int[] CylinderPool = {10, 2, 50, 15, 4};
        
        public Motorcycle()
        {
            Cylinders = CylinderPool[new Random().Next() % 5];
        }

        public override string ToString()
        {
            return base.ToString() + $" Cylinders: {Cylinders}";
        }
    }
}