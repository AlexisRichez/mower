using System;
using System.Collections.Generic;

namespace MowerApp.Models
{
    public class Mower
    {
        /// <summary>
        /// Guid.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Location (Position & Orientation)
        /// </summary>
        public Location Location { set; get; }

        /// <summary>
        /// Movements to be made by the mower.
        /// </summary>
        public List<Movement> Movements { set; get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="location">Initial location</param>
        public Mower(Location location)
        {
            Id = Guid.NewGuid();
            Location = location;
            Movements = new List<Movement>();
        }

        /// <summary>
        /// Get mower next position.
        /// </summary>
        /// <param name="movement">Movement to calculate next position</param>
        /// <returns>New position.</returns>
        public Position GetNextPosition(Movement movement)
        {
            if (movement.Equals(Movement.F))
            {
                var nextLocation = Location.Forward(false);
                return nextLocation.Position;
            }
            return Location.Position;
        }

        /// <summary>
        /// Move forward.
        /// </summary>
        public void Forward()
        {
            Location.Forward(true);
        }

        /// <summary>
        /// Move to the left.
        /// </summary>
        public void ToLeft()
        {
            Location.ToLeft();
        }

        /// <summary>
        /// Move to the right.
        /// </summary>
        public void ToRight()
        {
            Location.ToRight();
        }
    }
}
