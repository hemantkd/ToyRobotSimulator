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

        public Direction Facing { get; set; }
        public int YCoordinate { get; set; }
        public int XCoordinate { get; set; }
    }
}