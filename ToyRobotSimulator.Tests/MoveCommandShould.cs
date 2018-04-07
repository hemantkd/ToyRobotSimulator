using NUnit.Framework;

namespace ToyRobotSimulator.Tests
{
    [TestFixture]
    public class MoveCommandShould
    {
        const int CurrentX = 0;
        const int CurrentY = 0;

        [Test]
        public void MoveToyRobotFacingNorth_OneUnitForwardInNorth()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: CurrentX,
                yCoordinate: CurrentY,
                facing: Direction.North
            );
            toyRobot.Move();

            Assert.That(toyRobot.YCoordinate, Is.EqualTo(CurrentY + 1));
            Assert.That(toyRobot.XCoordinate, Is.EqualTo(CurrentX));
            Assert.That(toyRobot.Facing, Is.EqualTo(Direction.North));
        }

        [Test]
        public void MoveToyRobotFacingSouth_OneUnitForwardInSouth()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: CurrentX,
                yCoordinate: CurrentY,
                facing: Direction.South
            );
            toyRobot.Move();

            Assert.That(toyRobot.YCoordinate, Is.EqualTo(CurrentY - 1));
            Assert.That(toyRobot.XCoordinate, Is.EqualTo(CurrentX));
            Assert.That(toyRobot.Facing, Is.EqualTo(Direction.South));
        }

        [Test]
        public void MoveToyRobotFacingWest_OneUnitForwardInWest()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: CurrentX,
                yCoordinate: CurrentY,
                facing: Direction.West
            );
            toyRobot.Move();

            Assert.That(toyRobot.XCoordinate, Is.EqualTo(CurrentX - 1));
            Assert.That(toyRobot.YCoordinate, Is.EqualTo(CurrentY));
            Assert.That(toyRobot.Facing, Is.EqualTo(Direction.West));
        }

        [Test]
        public void MoveToyRobotFacingEast_OneUnitForwardInEast()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: CurrentX,
                yCoordinate: CurrentY,
                facing: Direction.East
            );
            toyRobot.Move();

            Assert.That(toyRobot.XCoordinate, Is.EqualTo(CurrentX + 1));
            Assert.That(toyRobot.YCoordinate, Is.EqualTo(CurrentY));
            Assert.That(toyRobot.Facing, Is.EqualTo(Direction.East));
        }
    }
}