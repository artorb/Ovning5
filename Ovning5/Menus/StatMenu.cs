using System;
using System.Collections.Generic;
using System.Linq;
using Övning6.Garage;

namespace Övning6.Menus
{
    public interface IMenuable
    {
        Dictionary<Option<int>, MenuEntity> Instant { get; }
    }

    //
    // public struct StatMenuOpt<T>
    // {
    //     private int Value { get; }
    //
    //     private StatMenuOpt(int opt)
    //     {
    //         Value = opt;
    //     }
    //
    //     public static implicit operator int(StatMenuOpt<T> opt)
    //     {
    //         return opt.Value;
    //     }
    //
    //     public static implicit operator StatMenuOpt<T>(int opt)
    //     {
    //         return new(opt);
    //     }
    // }
    //
    public class MenuHolden
    {
        private static Dictionary<int, IMenuable> Instance { get; set; }

        public MenuHolden()
        {
            Instance = new Dictionary<int, IMenuable>
            {
                {0, new MainHolden()},
                {1, new GarageHolden()}
            };
        }

        public Dictionary<int, IMenuable> GetMenus()
        {
            return Instance;
        }

        // public static Dictionary<StatMenuOpt<int>, IMenuable> Instance { get; } = new()
        // {
        //     {1, new GarageHolden()},
        //     {2, new MainHolden()}
        // };

        private class MainHolden : IMenuable
        {
            public Dictionary<Option<int>, MenuEntity> Instant { get; }

            public MainHolden()
            {
                Instant = new Dictionary<Option<int>, MenuEntity>()
                {
                    {0, new MenuEntity("Exit", () => Environment.Exit(0))},
                    {1, new MenuEntity("Garage Menu", () => Instance[1].Print())}
                };
            }
        }

        private class GarageHolden : IMenuable
        {
            public Dictionary<Option<int>, MenuEntity> Instant { get; }
        
            public GarageHolden()
            {
                Instant = new Dictionary<Option<int>, MenuEntity>
                {
                    {0, new MenuEntity("Back", () => Instance[0].Print())},
                };
            }
        }
    }

    public static class StatExt
    {
        public static void Print(this IMenuable menu)
        {
            foreach (var (key, value) in menu.Instant)
            {
                Console.WriteLine($"{key.Value}. {value.Title}");
            }

            var input = ValidateNumberInput();
            while (true)
            {
                if (input > -1)
                {
                    menu.Instant[input].Execute();
                }
                else
                {
                    break;
                }
            }
        }

        private static int ValidateNumberInput()
        {
            const string msg = "Choose your option by typing in a number: ";
            Console.WriteLine(msg);

            var input = Console.ReadLine() ?? string.Empty;

            if (!input.Select((_, index) => input.ToCharArray()[index])
                .Any(ch => string.IsNullOrWhiteSpace(input) || !char.IsDigit(ch))) return Convert.ToInt32(input);
            Console.WriteLine("Invalid input: {0}", input);

            return -1;
        }
    }
}