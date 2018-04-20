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

            Assert.That(toyRobot.Position.Facing, Is.EqualTo(expectedDirection));
            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(X));
            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(Y));
        }
    }
}