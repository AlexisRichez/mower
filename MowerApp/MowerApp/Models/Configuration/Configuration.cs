using System;
using System.Collections.Generic;

namespace MowerApp.Models
{
    public class Configuration
    {
        /// <summary>
        /// Surface configuration.
        /// </summary>
        public SurfaceConfiguration Surface { get; set; }

        /// <summary>
        /// List of mowers configuration.
        /// </summary>
        public List<MowerConfiguration> Mowers { get; set; }

        /// <summary>
        /// Parse surface configuration.
        /// </summary>
        /// <param name="configuration">Configuration</param>
        /// <returns>SurfaceConfiguration object</returns>
        public SurfaceConfiguration ParseSurfaceConfiguration(string configuration)
        {
            string[] subs = configuration.Split(' ');

            return new SurfaceConfiguration
            {
                TopRightLimit = new Position
                {
                    X = int.Parse(subs[0]),
                    Y = int.Parse(subs[1])
                }
            };
        }

        /// <summary>
        /// Parse mower configuration.
        /// </summary>
        /// <param name="location">Location</param>
        /// <param name="movements">Movements</param>
        /// <returns>MoveConfigurationObject</returns>
        public MowerConfiguration ParseMowerConfiguration(string location, string movements)
        {
            string[] loc = location.Split(' ');

            var config = new MowerConfiguration
            {
                Location = new Location
                {
                    Position = new Position
                    {
                        X = int.Parse(loc[0]),
                        Y = int.Parse(loc[1])
                    },
                    Orientation = (Orientation)Enum.Parse(typeof(Orientation), loc[2])
                },
                Movements = new List<Movement>()
            };

            char[] moves = movements.ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                config.Movements.Add((Movement)Enum.Parse(typeof(Movement), moves[i].ToString()));
            }

            return config;
        }
    }
}
