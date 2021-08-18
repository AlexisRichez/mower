using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using MowerApp.Models;

namespace MowerApp
{
    class Program
    {
        static void Main()
        {
            var configuration = LoadConfiguration();

            var manager = new MowerManager(configuration);
            manager.Run();

            Console.ReadLine();
        }

        /// <summary>
        /// Load configuration.
        /// </summary>
        /// <returns>Configuration object used by MowerManager</returns>
        public static Configuration LoadConfiguration()
        {

            var lines = GetInputFileLines();

            var config = new Configuration();

            config.Surface = config.ParseSurfaceConfiguration(lines[0]);

            config.Mowers = new List<MowerConfiguration>();

            for (int i = 1; i < lines.Count; i += 2)
            {
                config.Mowers.Add(config.ParseMowerConfiguration(lines[i], lines[i + 1]));
            }

            return config;
        }

        private static List<String> GetInputFileLines()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\input.txt");
            return File.ReadLines(path).ToList();
        }
    }
}
