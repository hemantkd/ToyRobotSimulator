using NUnit.Framework;

namespace ToyRobotSimulator.Tests
{
    [TestFixture]
    public class MoveCommandShould
    {
        private const int XMin = 0, YMin = 0, XMax = 5, YMax = 5;

        [Test]
        public void MoveToyRobotFacingNorth_OneUnitForwardInNorth()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: XMin,
                yCoordinate: YMin,
                facing: Direction.North
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(YMin + 1));
            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(XMin));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.North));
        }

        [Test]
        public void MoveToyRobotFacingSouth_OneUnitForwardInSouth()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: XMin,
                yCoordinate: YMax,
                facing: Direction.South
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(YMax - 1));
            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(XMin));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.South));
        }

        [Test]
        public void MoveToyRobotFacingWest_OneUnitForwardInWest()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: XMax,
                yCoordinate: YMin,
                facing: Direction.West
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(XMax - 1));
            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(YMin));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.West));
        }

        [Test]
        public void MoveToyRobotFacingEast_OneUnitForwardInEast()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: XMin,
                yCoordinate: YMin,
                facing: Direction.East
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(XMin + 1));
            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(YMin));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.East));
        }

        [Test]
        public void NotMoveToyRobotFacingEast_IfNextStepIsOutOfBounds()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: XMax,
                yCoordinate: YMin,
                facing: Direction.East
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(XMax));
            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(YMin));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.East));
        }

        [Test]
        public void NotMoveToyRobotFacingWest_IfNextStepIsOutOfBounds()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: XMin,
                yCoordinate: YMin,
                facing: Direction.West
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(XMin));
            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(YMin));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.West));
        }

        [Test]
        public void NotMoveToyRobotFacingNorth_IfNextStepIsOutOfBounds()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: XMin,
                yCoordinate: YMax,
                facing: Direction.North
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(XMin));
            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(YMax));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.North));
        }

        [Test]
        public void NotMoveToyRobotFacingSouth_IfNextStepIsOutOfBounds()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: XMin,
                yCoordinate: YMin,
                facing: Direction.South
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(XMin));
            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(YMin));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.South));
        }
    }
}