namespace ToyRobotSimulator
{
    public class ToyRobot
    {
        public ToyRobot(int xCoordinate, int yCoordinate, Direction facing)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Facing = facing;
        }

        public Direction Facing { get; private set; }

        public int YCoordinate { get; private set; }

        public int XCoordinate { get; private set; }

        public void Move()
        {
            switch (Facing)
            {
                case Direction.East: XCoordinate++;
                    break;
                case Direction.West: XCoordinate--;
                    break;
                case Direction.North: YCoordinate++;
                    break;
                case Direction.South: YCoordinate--;
                    break;
            }
        }
    }
}