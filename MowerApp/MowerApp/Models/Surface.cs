namespace MowerApp.Models
{
    /// <summary>
    /// Surface where mowers can move.
    /// </summary>
    public class Surface
    {
        /// <summary>
        /// Surface top right limit position.
        /// A 5x5 grid will have a top right limit position of X:5 and Y:5.
        /// </summary>
        public Position TopRightLimit { get; set; }
    }
}
