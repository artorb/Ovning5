using System;
using System.Collections.Generic;
using Övning6.Garage;
using Övning6.Vehicles;

namespace Övning6.Menus
{
    public enum MenuType
    {
        MAIN,
        GARAGE,
        VEHICLE
    }

    public sealed class Menu : IMenu
    {
        public Dictionary<Option<int>, MenuEntity> Instance { get; }
        private int menuType;

        private static readonly Dictionary<MenuType, IMenu> instances = new()
        {
            {MenuType.MAIN, GetMain()},
            {MenuType.GARAGE, GetGarage()},
            {MenuType.VEHICLE, GetVehicle()}
        };

        private Menu(Dictionary<Option<int>, MenuEntity> instance, int menuType)
        {
            Instance = instance;
            this.menuType = menuType;
        }

        public static Menu GetInstance(MenuType type)
        {
            return instances[type] as Menu;
        }

        private static IMenu GetMain()
        {
            Dictionary<Option<int>, MenuEntity> main = new()
            {
                {MainMenuOption.SHUTDOWN, new MenuEntity("Exit", () => Environment.Exit(0))},
                {MainMenuOption.GARAGE_MENU, new MenuEntity("Garage Menu", () => GetGarage().Print())},
                {MainMenuOption.FIND_VEHICLE, new MenuEntity("Find a vehicle", GarageExtension.Find)}
            };
            return new Menu(main, (int) MenuType.MAIN);
        }

        private static IMenu GetGarage()
        {
            Dictionary<Option<int>, MenuEntity> garage = new()
            {
                {GarageMenuOption.BACK, new MenuEntity("Back", () => GetMain().Print())},
                {GarageMenuOption.NEW_GARAGE, new MenuEntity("Create garage", GarageHandler.Create)},
                {GarageMenuOption.REMOVE_GARAGE, new MenuEntity("Remove garage", GarageHandler.Remove)},
                {GarageMenuOption.POPULATE_GARAGE, new MenuEntity("Populate new garage", GarageHandler.Populate)},
                {
                    GarageMenuOption.CHOOSE_EXISTING_GARAGE,
                    new MenuEntity("List existing garages", GarageHandler.PrintAll)
                },
                {GarageMenuOption.PICK_GARAGE, new MenuEntity("Choose existing garage", GarageHandler.Choose)}
            };
            return new Menu(garage, (int) MenuType.GARAGE);
        }

        private static IMenu GetVehicle()
        {
            Dictionary<Option<int>, MenuEntity> vehicle = new()
            {
                {VehicleMenuOption.BACK, new MenuEntity("Back", () => GetGarage().Print())},
                {
                    VehicleMenuOption.LIST_ALL_VEHICLES, new MenuEntity("List all vehicles", VehicleExtension.PrintAll)
                }, 
                {VehicleMenuOption.NEW_VEHICLE, new MenuEntity("Create vehicle", VehicleExtension.Create)},
                {VehicleMenuOption.REMOVE_VEHICLE, new MenuEntity("Remove vehicle", VehicleExtension.Remove)}
            };
            return new Menu(vehicle, (int) MenuType.VEHICLE);
        }
    }
}