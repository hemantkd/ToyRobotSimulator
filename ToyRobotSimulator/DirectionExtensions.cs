namespace ToyRobotSimulator
{
    public static class DirectionExtensions
    {
        public static Direction RotateLeft(this Direction direction)
        {
            return direction == Direction.North ? Direction.West : direction - 1;
        }

        public static Direction RotateRight(this Direction direction)
        {
            return direction == Direction.West ? Direction.North : direction + 1;
        }
    }
}