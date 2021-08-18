using System.Collections.Generic;

namespace MowerApp.Models
{
    public class MowerConfiguration
    {
        /// <summary>
        /// Initial location.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// List of movements.
        /// </summary>
        public List<Movement> Movements { get; set; }
    }
}
