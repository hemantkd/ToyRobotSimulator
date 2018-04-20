namespace ToyRobotSimulator
{
    public class Position
    {
        public Position(int xCoordinate, int yCoordinate, Direction facing)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Facing = facing;
        }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public Direction Facing { get; set; }
    }
}