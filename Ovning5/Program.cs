using Övning6.Garage;
using Övning6.Menus;

namespace Övning6
{
    class Program
    {
        static void Main(string[] args)
        {
            var handler = new GarageHandler();
            Menu.GetInstance(MenuType.MAIN).Print();
            // var veh1 = new Vehicle(
            //     title: "BMW",
            //     color: "BLACK",
            //     amountWheels: 4,
            //     regNum: "AWER21",
            //     speed: 120);
            //
            // var veh2 = new Vehicle(
            //     title: "MERC",
            //     color: "ORANGE",
            //     amountWheels: 4,
            //     regNum: "ABCDEF",
            //     speed: 110);
            //
            // var veh3 = new Vehicle(
            //     title: "TOYOTA",
            //     color: "RED",
            //     amountWheels: 4,
            //     regNum: "ZXCF42",
            //     speed: 150);
            //
            // GarageHandler.ChosenGarage = 0;
            // Garage<Vehicle> ge = new(12);
            // ge.VehicleArray[0] = veh1;
            // ge.VehicleArray[1] = veh2;
            // ge.VehicleArray[2] = veh3;
            // GarageHandler.garages.Add(ge);
            // string[] filtes = {"BLACK", "150"};

            // var ww = ge.VehicleArray.FilterVarArg(filtes);
            // foreach (var vehicle in ww)
            // {
            //     Console.WriteLine(vehicle);
            // }
            // // GarageExtension.Find();
            //
            // var veh1 = new Vehicle(
            //     title: "BMW",
            //     color: "BLACK",
            //     amountWheels: 4, 
            //     regNum: "ABCDEF",
            //     speed: 150);
            //
            // var veh2 = new Vehicle("MERC", "WHITE", 4, "DFASDA", 110);
            // Vehicle[] tw = {veh1, veh2};
            // JsonHandler a = new JsonHandler();
            // a.Write(new List<IVehicle>(tw.ToList()));
            //
            // var deser = "{\"Title\":\"BMW\",\"RegNumber\":\"ABCDEF\",\"Color\":\"BLACK\",\"Speed\":150,\"AmountWheels\":4}";
            // var deserJSON = JsonSerializer.Deserialize<Vehicle>(deser);
            // Console.WriteLine(deserJSON);
            //
            //
            // var findByType = tw.FilterByProperty("AmountWheels", speed => (int) speed > 4);
            // foreach(var x in findByType)
            //     Console.WriteLine(x);
            //
            //
            // var json = JsonSerializer.Serialize(tw);
            // Console.WriteLine(json);

            // Menu.GetInstance(MenuType.MAIN).Print();
        }
    }
}