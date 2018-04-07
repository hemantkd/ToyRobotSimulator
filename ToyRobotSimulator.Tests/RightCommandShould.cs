using NUnit.Framework;

namespace ToyRobotSimulator.Tests
{
    [TestFixture]
    public class RightCommandShould
    {
        private const int X = 0, Y = 0;

        [TestCase(Direction.North, Direction.East)]
        [TestCase(Direction.East, Direction.South)]
        [TestCase(Direction.South, Direction.West)]
        [TestCase(Direction.West, Direction.North)]
        public void RotateToyToRight(Direction currentDirection, Direction expectedDirection)
        {
            var toyRobot = new ToyRobot(X, Y, currentDirection);
            toyRobot.RotateRight();

            Assert.That(toyRobot.Facing, Is.EqualTo(expectedDirection));
            Assert.That(toyRobot.XCoordinate, Is.EqualTo(X));
            Assert.That(toyRobot.YCoordinate, Is.EqualTo(Y));
        }
    }
}