using System;
using System.Linq;

namespace Övning6.Menus
{
    public static class MenuExtension
    {
        public static void Print(this IMenu menu)
        {
            foreach (var (key, value) in menu.Instance)
            {
                Console.WriteLine($"{key.Value}. {value.Title}");
            }

            var input = ValidateNumberInput();
            while (true)
            {
                if (input > -1)
                {
                    menu.Instance[input].Execute();
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

        private static int ValidateStringInput()
        {
            const string msg = "Choose your option by typing in a number: ";
            Console.WriteLine(msg);

            var input = Console.ReadLine() ?? string.Empty;

            if (!input.Select((_, index) => input.ToCharArray()[index])
                .Any(ch => string.IsNullOrWhiteSpace(input) || !char.IsDigit(ch))) return Convert.ToInt32(input);
            Console.WriteLine("Invalid input: {0}", input);

            return -1;
        }

        private static void HandleUserInput()
        {
        }
    }
}