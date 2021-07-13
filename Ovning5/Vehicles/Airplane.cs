using System;

namespace Övning6.Vehicles
{
    public class Airplane : Vehicle
    {
        public int TakeOffTime { get; set; }

        public Airplane(string title, string color, int amountWheels, string regNum, int speed, int takeOffTime) :
            base(title, color, amountWheels, regNum, speed)
        {
            TakeOffTime = takeOffTime;
        }

        public Airplane(string title, string color, int amountWheels, string regNum, int speed) : base(title, color,
            amountWheels, regNum, speed)
        {
        }

        private int[] TakeOffPool = {1, 20, 60, 100, 150};

        public override string ToString()
        {
            return base.ToString() + $" Take Off Time: {TakeOffTime}";
        }
    }
}