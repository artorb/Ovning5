using System;

namespace Övning6.Vehicles
{
    public class Bus : Vehicle
    {
        public int AmountSeats { get; set; }

        public Bus(string title, string color, int amountWheels, string regNum, int speed, int amountSeats) : base(
            title, color, amountWheels, regNum, speed)
        {
            AmountSeats = amountSeats;
        }

        public Bus(string title, string color, int amountWheels, string regNum, int speed) : base(title, color,
            amountWheels, regNum, speed)
        {
        }

        private readonly int[] SeatsPool = {1, 2, 4, 20, 50};
        
        public Bus()
        {
            AmountSeats = SeatsPool[new Random().Next() % 5];
        }

        public override string ToString()
        {
            return base.ToString() + $" Seats: {AmountSeats}";
        }
    }
}