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
        /// Run mowers sequentially.
        /// </summary>
        public void Run()
        {
            foreach (var mower in Mowers)
            {
                RunMower(mower);
            }
        }

        /// <summary>
        /// Run a mower individually.
        /// </summary>
        /// <param name="mower">Mower to move</param>
        public void RunMower(Mower mower)
        {
            foreach (var movement in mower.Movements)
            {
                //TODO : add default => throw exception IllegalMovementException
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
                }
            }

            DisplayMowerFinalLocation(mower);
        }

        /// <summary>
        /// Check if position is in collision with the surface (can be improved by adding a collision check between mowers)
        /// </summary>
        /// <param name="position">Position to check</param>
        /// <returns>True if no collisions, False otherwise</returns>
        public bool CheckCollisions(Position position)
        {
            if (position.X >= 0 && position.Y >= 0 && position.X <= Surface.TopRightLimit.X && position.Y <= Surface.TopRightLimit.Y)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Display a mower final location in output.
        /// </summary>
        /// <param name="mower">Mower</param>
        private void DisplayMowerFinalLocation(Mower mower)
        {
            Console.WriteLine("{0} {1} {2}", mower.Location.Position.X, mower.Location.Position.Y, mower.Location.Orientation);
        }
    }
}