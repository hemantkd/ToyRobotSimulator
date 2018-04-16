namespace ToyRobotSimulator
{
    public class ToyRobot
    {
        private const int XMin = 0, YMin = 0, XMax = 5, YMax = 5;

        public ToyRobot(int xCoordinate, int yCoordinate, Direction facing)
        {
            SetPosition(xCoordinate, yCoordinate, facing);
        }

        public ToyRobot()
        {}

        public bool Deactivate { get; set; } = false;

        public Direction Facing { get; private set; }

        public int YCoordinate { get; private set; }

        public int XCoordinate { get; private set; }

        public void SetPosition(int xCoordinate, int yCoordinate, Direction facing)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Facing = facing;
        }
        public void Move()
        {
            switch (Facing)
            {
                case Direction.East: if(IsNotOnEasternBoundary()) XCoordinate++;
                    break;
                case Direction.West: if(IsNotOnWesternBoundary()) XCoordinate--;
                    break;
                case Direction.North: if(IsNotOnNorthernBoundary()) YCoordinate++;
                    break;
                case Direction.South: if(IsNotOnSouthernBoundary()) YCoordinate--;
                    break;
            }
        }

        public void RotateLeft()
        {
            Facing = Facing.RotateLeft();
        }

        public void RotateRight()
        {
            Facing = Facing.RotateRight();
        }

        private bool IsNotOnSouthernBoundary()
        {
            return YCoordinate != YMin;
        }

        private bool IsNotOnNorthernBoundary()
        {
            return YCoordinate != YMax;
        }

        private bool IsNotOnWesternBoundary()
        {
            return XCoordinate != XMin;
        }

        private bool IsNotOnEasternBoundary()
        {
            return XCoordinate != XMax;
        }

        public string Report()
        {
            return $"Output: {XCoordinate},{YCoordinate},{Facing.ToString().ToUpperInvariant()}";
        }
    }
}