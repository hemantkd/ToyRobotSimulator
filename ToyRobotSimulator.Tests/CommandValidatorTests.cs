using NUnit.Framework;
using ToyRobotSimulator.TextAppServices;

namespace ToyRobotSimulator.Tests
{
    // TODO: Refactor code duplication
    [TestFixture]
    public class CommandValidatorTests
    {
        [Test]
        public void ShouldReturnTrue_ForMoveCommand()
        {
            var commandValidator = new CommandTextValidator();

            Assert.IsTrue(commandValidator.IsValid("MOVE"));
        }

        [Test]
        public void ShouldReturnTrue_ForLeftCommand()
        {
            var commandValidator = new CommandTextValidator();

            Assert.IsTrue(commandValidator.IsValid("LEFT"));
        }

        [Test]
        public void ShouldReturnTrue_ForRightCommand()
        {
            var commandValidator = new CommandTextValidator();

            Assert.IsTrue(commandValidator.IsValid("RIGHT"));
        }

        [Test]
        public void ShouldReturnTrue_ForReportCommand()
        {
            var commandValidator = new CommandTextValidator();

            Assert.IsTrue(commandValidator.IsValid("REPORT"));
        }

        [Test]
        public void ShouldReturnTrue_ForPlaceCommand()
        {
            var commandValidator = new CommandTextValidator();

            Assert.IsTrue(commandValidator.IsValid("PLACE 0,0,NORTH"));
        }

        [TestCase("PLACE 0,NORTH")]
        [TestCase("PLACE 0,0,0,NORTH")]
        [TestCase("PLACE 0,0")]
        [TestCase("PLACE 0,0,")]
        [TestCase("PLACE ,0,")]
        [TestCase("PLACE ,0,NORTH")]
        public void ShouldReturnFalse_IfPlaceCommandHas_ElementsMissing(string placeCommand)
        {
            var commandValidator = new CommandTextValidator();

            Assert.IsFalse(commandValidator.IsValid(placeCommand));
        }

        [TestCase("PLACE WEST,0,NORTH")]
        [TestCase("PLACE 0,EAST,0")]
        public void ShouldReturnFalse_IfPlaceCommandHas_ANonIntegerXOrYParameter(string placeCommand)
        {
            var commandValidator = new CommandTextValidator();

            Assert.IsFalse(commandValidator.IsValid(placeCommand));
        }

        [TestCase("PLACE -1,2,SOUTH")]
        [TestCase("PLACE 6,2,SOUTH")]
        [TestCase("PLACE 4,-1,SOUTH")]
        [TestCase("PLACE 3,6,SOUTH")]
        public void ShouldReturnFalse_IfPlaceCommandHas_OutOfRangeXOrYParameter(string placeCommand)
        {
            var commandValidator = new CommandTextValidator();

            Assert.IsFalse(commandValidator.IsValid(placeCommand));
        }

        [TestCase("Place 0,1,NORTH")]
        [TestCase("Place 0,1,SOUTH")]
        [TestCase("Place 0,1,West")]
        [TestCase("Place 0,1,east")]
        public void ShouldReturnTrue_IfPlaceCommandHas_ValidDirection(string placeCommand)
        {
            var commandValidator = new CommandTextValidator();

            Assert.IsTrue(commandValidator.IsValid(placeCommand));
        }

        [TestCase("Place 0,1,Up")]
        [TestCase("Place 0,1,Down")]
        public void ShouldReturnFalse_IfPlaceCommandHas_InvalidDirection(string placeCommand)
        {
            var commandValidator = new CommandTextValidator();

            Assert.IsFalse(commandValidator.IsValid(placeCommand));
        }
    }
}