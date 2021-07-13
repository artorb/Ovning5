using System;
using System.Linq;
using Övning6.Garage;

namespace Övning6.Vehicles
{
    public static class VehicleExtension
    {
        public static void Remove()
        {
            Console.WriteLine("Write the attributes of a vehicle you want to delete: ");
            var inputFilters = Console.ReadLine()?.Split(" ");
            if ((inputFilters ?? throw new InvalidOperationException()).Any(string.IsNullOrEmpty))
            {
                Console.WriteLine("Cannot have empty string");
                return;
            }

            var list = GarageHandler.garages[GarageHandler.ChosenGarage].VehicleArray.ToList();

            foreach (var filter in inputFilters)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    var tmp = list[i];
                    if (tmp.Color.Equals(filter) || tmp.Speed.ToString().Equals(filter) || tmp.Title.Equals(filter) ||
                        tmp.AmountWheels.ToString().Equals(filter)
                        || tmp.RegNumber.Equals(filter))
                    {
                        list.RemoveAt(i);
                    }
                }
            }

            GarageHandler.garages[GarageHandler.ChosenGarage].VehicleArray = list.ToArray();
        }

        public static void Create()
        {
            Console.WriteLine(" <<Welcome to vehicle constructor>> ");
            Console.WriteLine("Please specify the type of vehicle ");
            var type = Console.ReadLine();
            switch (type)
            {
                case "Airplan":
                {
                    Console.WriteLine("Please specify the take off time ");
                    var takeTime = Console.ReadLine();
                }
                    break;
                case "Boat":
                {
                    Console.WriteLine("Please specify the take off time ");
                    var takeTime = Console.ReadLine();
                }
                    break;
                case "Bus":
                {
                    Console.WriteLine("Please specify the take off time ");
                    var takeTime = Console.ReadLine();
                }
                    break;
                case "Car":
                {
                    Console.WriteLine("Please specify the take off time ");
                    var takeTime = Console.ReadLine();
                }
                    break;
                case "Motorcycle":
                {
                    Console.WriteLine("Please specify the take off time ");
                    var takeTime = Console.ReadLine();
                }
                    break;
                case "Vehicle":
                {
                    var veh = new Vehicle();
                    Constructor(ref veh);
                }
                    break;
            }
        }

        private static void Constructor(ref Vehicle vehicle)
        {
        // public Vehicle(string title, string color, int amountWheels, string regNum, int speed)
            Console.WriteLine("Please specify the title of the vehicle");
            var title = Console.ReadLine();
            Console.WriteLine("Please specify the color of the vehicle");
            var color = Console.ReadLine();
            Console.WriteLine("Please specify the amount of the wheels of the vehicle");
            var wheels = Console.ReadLine();
            Console.WriteLine("Please specify the registration number of the vehicle");
            var regNum = Console.ReadLine();
            Console.WriteLine("Please specify the speed of the vehicle");
            var speed = Console.ReadLine();
            vehicle = new Vehicle(title, color, Convert.ToInt32(wheels), regNum, Convert.ToInt32(speed));
        }

        public static void PrintAll()
        {
            var enumerable = GarageHandler.garages[GarageHandler.ChosenGarage].VehicleArray;
            foreach (var x in enumerable)
            {
                Console.WriteLine(x);
            }
        }
    }
}