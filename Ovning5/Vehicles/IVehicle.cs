using System;

namespace Övning6.Vehicles
{
    public interface IVehicle  

    {
        public string Title { get; set; }
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }
        public int AmountWheels { get; set; }
    }
}