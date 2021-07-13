namespace Övning6.Menus
{
    public struct MainMenuOption
    {
        public const int SHUTDOWN = 0, GARAGE_MENU = 1, FIND_VEHICLE = 2;
    }

    public struct GarageMenuOption
    {
        public const int BACK = 0, NEW_GARAGE = 1, REMOVE_GARAGE = 2, POPULATE_GARAGE = 3, CHOOSE_EXISTING_GARAGE = 4, PICK_GARAGE = 5;
    }

    public struct VehicleMenuOption
    {
        public const int BACK = 0, NEW_VEHICLE = 1, REMOVE_VEHICLE = 2, LIST_ALL_VEHICLES = 3;
    }

    public struct Option<T>
    {
        private Option(int opt)
        {
            Value = opt;
        }

        public int Value { get; set; }

        public static implicit operator int(Option<T> x)
        {
            return x.Value;
        }

        public static implicit operator Option<T>(int x)
        {
            return new(x);
        }
    }
}