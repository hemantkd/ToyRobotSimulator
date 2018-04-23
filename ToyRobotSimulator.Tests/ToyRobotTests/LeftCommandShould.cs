using NUnit.Framework;

namespace ToyRobotSimulator.Tests.ToyRobotTests
{
    [TestFixture]
    public class LeftCommandShould
    {
        private const int X = 0, Y = 0;

        [TestCase(Direction.North, Direction.West)]
        [TestCase(Direction.West, Direction.South)]
        [TestCase(Direction.South, Direction.East)]
        [TestCase(Direction.East, Direction.North)]
        public void RotateToyToLeft(Direction currentDirection, Direction expectedDirection)
        {
            var toyRobot = new ToyRobot(X, Y, currentDirection);
            toyRobot.RotateLeft();

            Assert.That(toyRobot.Position.Facing, Is.EqualTo(expectedDirection));
            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(X));
            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(Y));
        }
    }
}