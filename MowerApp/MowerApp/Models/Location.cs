namespace MowerApp.Models
{
    public class Location
    {
        /// <summary>
        /// Current position.
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Current orientation.
        /// </summary>
        public Orientation Orientation { get; set; }

        /// <summary>
        /// Turn mower orientation to the right.
        /// </summary>
        public void ToRight()
        {
            switch (Orientation)
            {
                case Orientation.N:
                    Orientation = Orientation.E;
                    break;

                case Orientation.E:
                    Orientation = Orientation.S;
                    break;

                case Orientation.S:
                    Orientation = Orientation.W;
                    break;

                case Orientation.W:
                    Orientation = Orientation.N;
                    break;
            }
        }

        /// <summary>
        /// Turn mover orientation to the left.
        /// </summary>
        public void ToLeft()
        {
            switch (Orientation)
            {
                case Orientation.N:
                    Orientation = Orientation.W;
                    break;

                case Orientation.E:
                    Orientation = Orientation.N;
                    break;

                case Orientation.S:
                    Orientation = Orientation.E;
                    break;

                case Orientation.W:
                    Orientation = Orientation.S;
                    break;
            }
        }


        /// <summary>
        /// Move mover forward.
        /// </summary>
        /// <param name="move">Need to move or just returning calculated location.</param>
        /// <returns>Mower location after going forward</returns>
        public Location Forward(bool move)
        {
            int x = Position.X;
            int y = Position.Y;

            switch (Orientation)
            {
                case Orientation.N:
                    y = Position.Y + 1;
                    break;

                case Orientation.E:
                    x = Position.X + 1;
                    break;

                case Orientation.S:
                    y = Position.Y - 1;
                    break;

                case Orientation.W:
                    x = Position.X - 1;
                    break;
            }

            if(move)
            {
                Position.X = x;
                Position.Y = y;
            }

            return new Location
            {
                Orientation = Orientation,
                Position = new Position
                {
                    X = x,
                    Y = y
                }
            };
        }
    }
}
