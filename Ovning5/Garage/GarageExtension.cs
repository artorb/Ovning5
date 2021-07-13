using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Övning6.Vehicles;

namespace Övning6.Garage
{
    public static class GarageExtension
    {
        public static IEnumerable<IVehicle> FilterByProperty(this IEnumerable<IVehicle> vehicles, string propName,
            Predicate<object> filterMethod)
        {
            try
            {
                var result = (from item in vehicles
                    let value = item.GetType().GetProperty(propName)?.GetValue(item)
                    where filterMethod(value)
                    select item).ToList();
                return result;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Property not found\n " + e);
                return null;
            }
        }

        public static void Find()
        {
            Console.WriteLine("Please type in the filters separated by space");
            var inputFilters = Console.ReadLine()?.Split(" ");
            if ((inputFilters ?? throw new InvalidOperationException()).Any(string.IsNullOrEmpty))
            {
                Console.WriteLine("Cannot have empty string");
                return;
            }
            
            // var found = GarageHandler.garages[GarageHandler.ChosenGarage].VehicleArray.FilterVarArg(inputFilters);
            var found = GarageHandler.garages.ToArray();
            foreach (var garage in found)
            {
                var filterVarArg = garage.VehicleArray.FilterVarArg(inputFilters);
                foreach (var f in filterVarArg)
                {
                    Console.WriteLine(f);
                }
                // Console.WriteLine(vehicle);
            }
        }

        public static IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
        {
            var z = assembly.GetTypes().ToList();
            return assembly.GetTypes().Where(t => baseType.IsAssignableFrom(t));
        }

        public static IEnumerable<IVehicle> FilterVarArg(this Vehicle[] Vehicles, params string[] filters)
        {
            var found = new List<IVehicle>();
            foreach (var par in filters)
            {
                found.AddRange(
                    Vehicles.Where(veh =>
                        veh.GetType().Name.Equals(par,
                            StringComparison.InvariantCultureIgnoreCase) ||
                        veh.Color.Equals(par, StringComparison.InvariantCultureIgnoreCase) ||
                        veh.Title.Equals(par, StringComparison.InvariantCultureIgnoreCase) ||
                        veh.Speed.ToString().Equals(par, StringComparison.InvariantCultureIgnoreCase) ||
                        veh.AmountWheels.ToString().Equals(par, StringComparison.InvariantCultureIgnoreCase) ||
                        veh.RegNumber.Equals(par, StringComparison.InvariantCultureIgnoreCase)));
            }

            foreach (var vehicle in found) yield return vehicle;
        }

        // public static IEnumerable<IVehicle> FilterVarArg(this Vehicle[] Vehicles, params object[] filters)
        // {
        //     var found = new List<IVehicle>();
        //     foreach (var par in filters)
        //     {
        //         switch (par)
        //         {
        //             case string:
        //                 found.AddRange(
        //                     Vehicles.Where(veh =>
        //                         veh.GetType().Name.Equals(par.ToString(),
        //                             StringComparison.InvariantCultureIgnoreCase) ||
        //                         veh.Color.Equals(par.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
        //                         veh.Title.Equals(par.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
        //                         veh.RegNumber.Equals(par.ToString(), StringComparison.InvariantCultureIgnoreCase)));
        //                 continue;
        //             case int:
        //                 found.AddRange(Vehicles.Where(veh => veh.Speed == (int) par || veh.AmountWheels == (int) par));
        //                 continue;
        //         }
        //     }
        //
        //     foreach (var vehicle in found) yield return vehicle;
        // }
    }
}