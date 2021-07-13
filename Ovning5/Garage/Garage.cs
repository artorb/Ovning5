using System.Collections;
using System.Collections.Generic;
using Övning6.Vehicles;

namespace Övning6.Garage
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        public int Capacity { get; }

        public Garage(int size)
        {
            Capacity = size;
            _vehicles = new Vehicle[size];
        }

        private Vehicle[] _vehicles;

        public IEnumerable<Vehicle> Vehicles => _vehicles;
        public Vehicle[] VehicleArray
        {
            get => _vehicles;
            set => _vehicles = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>) VehicleArray.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Vehicles.GetEnumerator();
        }
    }
}