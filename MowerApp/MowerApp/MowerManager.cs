using System;
using System.Collections.Generic;

using MowerApp.Models;

namespace MowerApp
{
    public class MowerManager
    {
        public Configuration Configuration;
        public Surface Surface;
        public List<Mower> Mowers;

        public MowerManager(Configuration configuration)
        {
            Configuration = configuration;
            Surface = new Surface { TopRightLimit = Configuration.Surface.TopRightLimit };
            Mowers = new List<Mower>();

            foreach (var mowerConfig in Configuration.Mowers)
            {
                var mower = new Mower(mowerConfig.Location)
                {
                    Movements = mowerConfig.Movements
                };

                Mowers.Add(mower);
            }
        }

        /// <summary>
        /// Run mowers.
        /// </summary>
        public void Run()
        {
            foreach (var mower in Mowers)
            {
                RunMower(mower);
            }
        }

        public void RunMower(Mower mower)
        {
            foreach (var movement in mower.Movements)
            {
                switch (movement)
                {
                    case Movement.F:
                        var nextPosition = mower.GetNextPosition(movement);
                        if (CheckCollisions(nextPosition))
                        {
                            mower.Forward();
                        }
                        break;
                    case Movement.R:
                        mower.ToRight();
                        break;
                    case Movement.L:
                        mower.ToLeft();
                        break;
                        //TODO : add default => throw exception IllegalMovementException
                }
            }

            DisplayMowerFinalLocation(mower.Location);
        }

        public bool CheckCollisions(Position position)
        {
            if (position.X >= 0 && position.Y >= 0 && position.X <= Surface.TopRightLimit.X && position.Y <= Surface.TopRightLimit.Y)
            {
                return true;
            }

            return false;
        }

        public void DisplayMowerFinalLocation(Location location)
        {
            Console.WriteLine("{0} {1} {2}", location.Position.X, location.Position.Y, location.Orientation);
        }
    }
}