using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using Övning6.Vehicles;

namespace Övning6.IO
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class JsonHandler
    {
        private const string fileName = "\\Garage.json"; // hardcoded for demonstration purposes

        private static readonly string directory = FileExists()
            ? Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\"
            : "";

        public static List<IVehicle> Read()
        {
            try
            {
                var jsonStr = File.ReadAllText(directory + fileName);
                var vehicle = JsonSerializer.Deserialize<List<IVehicle>>(jsonStr);
                return vehicle;
            }
            catch (IOException io)
            {
                Console.WriteLine("File doesn't exist");
                var ioMessage = io.Message;
                Console.WriteLine(ioMessage);
            }
            catch (Exception e)
            {
                var eStackTrace = e.StackTrace;
                Console.WriteLine(eStackTrace);
            }

            return null;
        }

        public static async void Write(List<IVehicle> list)
        {
            Console.WriteLine("Name your file: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("File name cannot be null");
                return;
            }
            var opt = new JsonSerializerOptions {WriteIndented = true, IncludeFields = true};
            await using var fs = File.Create(directory + name + ".json");
            await JsonSerializer.SerializeAsync(fs, list, opt);
        }

        private static bool FileExists()
        {
            var dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            return File.Exists(dir + fileName);
        }

        /*
        private static bool IsWindows()
        {
            return Environment.OSVersion.Platform; ...
        }
       */
    }
}