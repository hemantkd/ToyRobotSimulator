using NUnit.Framework;

namespace ToyRobotSimulator.Tests.ToyRobotTests
{
    [TestFixture]
    public class MoveCommandShould
    {
        [Test]
        public void MoveToyRobotFacingNorth_OneUnitForwardInNorth()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: Boundary.XMin,
                yCoordinate: Boundary.YMin,
                facing: Direction.North
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(Boundary.YMin + 1));
            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(Boundary.XMin));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.North));
        }

        [Test]
        public void MoveToyRobotFacingSouth_OneUnitForwardInSouth()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: Boundary.XMin,
                yCoordinate: Boundary.YMax,
                facing: Direction.South
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(Boundary.YMax - 1));
            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(Boundary.XMin));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.South));
        }

        [Test]
        public void MoveToyRobotFacingWest_OneUnitForwardInWest()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: Boundary.XMax,
                yCoordinate: Boundary.YMin,
                facing: Direction.West
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(Boundary.XMax - 1));
            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(Boundary.YMin));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.West));
        }

        [Test]
        public void MoveToyRobotFacingEast_OneUnitForwardInEast()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: Boundary.XMin,
                yCoordinate: Boundary.YMin,
                facing: Direction.East
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(Boundary.XMin + 1));
            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(Boundary.YMin));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.East));
        }

        [Test]
        public void NotMoveToyRobotFacingEast_IfNextStepIsOutOfBounds()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: Boundary.XMax,
                yCoordinate: Boundary.YMin,
                facing: Direction.East
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(Boundary.XMax));
            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(Boundary.YMin));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.East));
        }

        [Test]
        public void NotMoveToyRobotFacingWest_IfNextStepIsOutOfBounds()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: Boundary.XMin,
                yCoordinate: Boundary.YMin,
                facing: Direction.West
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(Boundary.XMin));
            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(Boundary.YMin));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.West));
        }

        [Test]
        public void NotMoveToyRobotFacingNorth_IfNextStepIsOutOfBounds()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: Boundary.XMin,
                yCoordinate: Boundary.YMax,
                facing: Direction.North
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(Boundary.XMin));
            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(Boundary.YMax));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.North));
        }

        [Test]
        public void NotMoveToyRobotFacingSouth_IfNextStepIsOutOfBounds()
        {
            var toyRobot = new ToyRobot(
                xCoordinate: Boundary.XMin,
                yCoordinate: Boundary.YMin,
                facing: Direction.South
            );
            toyRobot.Move();

            Assert.That(toyRobot.Position.XCoordinate, Is.EqualTo(Boundary.XMin));
            Assert.That(toyRobot.Position.YCoordinate, Is.EqualTo(Boundary.YMin));
            Assert.That(toyRobot.Position.Facing, Is.EqualTo(Direction.South));
        }
    }
}