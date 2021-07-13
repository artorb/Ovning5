using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Övning6.Menus;
using Övning6.Vehicles;

namespace Övning6.Garage
{
    public class GarageHandler
    {
        public static List<Garage<Vehicle>> garages { get; set; } = new()
        {
            new Garage<Vehicle>(10),
            new Garage<Vehicle>(10),
            new Garage<Vehicle>(10)
        };

        public GarageHandler()
        {
            garages[0].VehicleArray[0] = new Vehicle();
            garages[0].VehicleArray[1] = new Vehicle();
            garages[0].VehicleArray[2] = new Vehicle();
            garages[1].VehicleArray[0] = new Car();
            garages[1].VehicleArray[1] = new Car();
            garages[1].VehicleArray[2] = new Car();
            garages[2].VehicleArray[0] = new Vehicle();
            garages[2].VehicleArray[1] = new Vehicle();
            garages[2].VehicleArray[2] = new Vehicle();
        }

        public static int ChosenGarage { get; set; }

        public static void PrintAll()
        {
            var i = 1;
            garages.ForEach(garage =>
            {
                if (garage.VehicleArray.Length > 0)
                {
                    Console.WriteLine(
                        $"Index: {i++}. There are {garage.Vehicles.Count()} vehicles of type {garage.VehicleArray[0].GetType().Name} in N {garage.GetHashCode()} garage.");
                }
            });
            Console.WriteLine();

            Menu.GetInstance(MenuType.GARAGE).Print();
        }

        public static void Populate()
        {
            var capacity = -1;
            ValidateInput("Please specify the capacity of the garage. Write R to return", ref capacity);
            if (capacity > 0)
            {
                var garage = new Garage<Vehicle>(capacity);
                for (var x = 0; x < capacity; x++)
                    garage.VehicleArray[x] = new Vehicle();


                garages.Add(garage);
            }
            else
            {
                Console.WriteLine("Failed populating garage!");
            }

            Menu.GetInstance(MenuType.GARAGE).Print();
        }

        public static void Create()
        {
            var capacity = -1;
            ValidateInput("Please specify the capacity of your garage. Write R to return", ref capacity);
            if (capacity > 0)
            {
                /*
                Console.WriteLine("Which type of vehicles you want to store in the garage? ");
                var derivedTypes = FindDerivedTypes(typeof(Vehicle).Assembly, typeof(Vehicle));
                foreach (var type in derivedTypes)
                {
                    Console.WriteLine(type.Name);
                }
                */
                var garage = new Garage<Vehicle>(capacity) {VehicleArray = {[0] = new Vehicle()}};
                // cant be null 

                garages.Add(garage);
                Console.WriteLine($"Created garage with {capacity} capacity!");
            }
            else
            {
                Console.WriteLine("Failed creating garage!");
            }

            Menu.GetInstance(MenuType.GARAGE).Print();
        }

        public static void Remove()
        {
            Console.WriteLine();
            var index = -1;
            ValidateInput("Which garage to delete? Write down the index. Write R to return.", ref index);
            if (index > 0)
            {
                if (garages.Count >= index)
                {
                    Console.WriteLine($"Removing {garages[index - 1].GetHashCode()} garage");
                    garages.RemoveAt(index - 1);
                    Thread.Sleep(1000);
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Failed removing garage with the given index");
                }
            }
            else
            {
                Console.WriteLine("Failed removing garage with the given index");
            }

            Menu.GetInstance(MenuType.GARAGE).Print();
        }

        private static void ValidateInput(string message, ref int option)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine() ?? string.Empty;
            if (input.Equals("R"))
            {
                Menu.GetInstance(MenuType.GARAGE).Print();
                return;
            }

            if (input.Select((_, index) => input.ToCharArray()[index])
                .Any(ch => string.IsNullOrWhiteSpace(input) || !char.IsDigit(ch)))
            {
                Console.WriteLine("Invalid input: {0}", input);
            }
            else
            {
                option = Convert.ToInt32(input);
            }
        }

        private static IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
        {
            var z = assembly.GetTypes().ToList();
            return assembly.GetTypes().Where(baseType.IsAssignableFrom);
        }

        public static void Choose()
        {
            Console.WriteLine();
            var index = -1;
            ValidateInput("Which garage to choose? Write down the index, or R to return", ref index);
            if (index > 0)
            {
                Console.WriteLine($"{garages.Count} > {index}");
                if (garages.Count >= index)
                {
                    Console.WriteLine("IN HERE 0");
                    ChosenGarage = index - 1;
                    Console.WriteLine($"Chosen {garages[ChosenGarage].GetHashCode()} garage");
                    // var garage = garages[ChosenGarage];
                    Menu.GetInstance(MenuType.VEHICLE).Print();
                    // garage.
                }
                else
                {
                    Console.WriteLine("Failed picking garage with the given index");
                }
            }
            else
            {
                Console.WriteLine("Failed picking garage with the given index");
            }
        }
    }
}