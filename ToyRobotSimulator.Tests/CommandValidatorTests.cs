using NUnit.Framework;
using ToyRobotSimulator.TextAppServices;

namespace ToyRobotSimulator.Tests
{
    // TODO: Refactor code duplication
    [TestFixture]
    public class CommandValidatorTests
    {
        private readonly CommandTextValidator _commandTextValidator;
        private readonly PlaceTextCommand _placeTextCommand;

        public CommandValidatorTests()
        {
            _commandTextValidator = new CommandTextValidator();
            _placeTextCommand = new PlaceTextCommand(_commandTextValidator);
        }

        [Test]
        public void ShouldReturnTrue_ForMoveCommand()
        {
            var moveCommand = new MoveTextCommand(_commandTextValidator);

            Assert.IsTrue(moveCommand.IsMatch("MOVE"));
        }

        [Test]
        public void ShouldReturnTrue_ForLeftCommand()
        {
            var leftCommand = new LeftTextCommand(_commandTextValidator);

            Assert.IsTrue(leftCommand.IsMatch("LEFT"));
        }

        [Test]
        public void ShouldReturnTrue_ForRightCommand()
        {
            var rightCommand = new RightTextCommand(_commandTextValidator);

            Assert.IsTrue(rightCommand.IsMatch("RIGHT"));
        }

        [Test]
        public void ShouldReturnTrue_ForReportCommand()
        {
            var reportCommand = new ReportTextCommand(_commandTextValidator, new UserInteractionByTextService());

            Assert.IsTrue(reportCommand.IsMatch("REPORT"));
        }

        [Test]
        public void ShouldReturnTrue_ForPlaceCommand()
        {
            Assert.IsTrue(_placeTextCommand.IsMatch("PLACE 0,0,NORTH"));
        }

        [TestCase("PLACE 0,NORTH")]
        [TestCase("PLACE 0,0,0,NORTH")]
        [TestCase("PLACE 0,0")]
        [TestCase("PLACE 0,0,")]
        [TestCase("PLACE ,0,")]
        [TestCase("PLACE ,0,NORTH")]
        public void ShouldReturnFalse_IfPlaceCommandHas_ElementsMissing(string placeCommandText)
        {
            Assert.IsFalse(_placeTextCommand.IsMatch(placeCommandText));
        }

        [TestCase("PLACE WEST,0,NORTH")]
        [TestCase("PLACE 0,EAST,0")]
        public void ShouldReturnFalse_IfPlaceCommandHas_ANonIntegerXOrYParameter(string placeCommandText)
        {
            Assert.IsFalse(_placeTextCommand.IsMatch(placeCommandText));
        }

        [TestCase("PLACE -1,2,SOUTH")]
        [TestCase("PLACE 6,2,SOUTH")]
        [TestCase("PLACE 4,-1,SOUTH")]
        [TestCase("PLACE 3,6,SOUTH")]
        public void ShouldReturnFalse_IfPlaceCommandHas_OutOfRangeXOrYParameter(string placeCommandText)
        {
            Assert.IsFalse(_placeTextCommand.IsMatch(placeCommandText));
        }

        [TestCase("Place 0,1,NORTH")]
        [TestCase("Place 0,1,SOUTH")]
        [TestCase("Place 0,1,West")]
        [TestCase("Place 0,1,east")]
        public void ShouldReturnTrue_IfPlaceCommandHas_ValidDirection(string placeCommandText)
        {
            Assert.IsTrue(_placeTextCommand.IsMatch(placeCommandText));
        }

        [TestCase("Place 0,1,Up")]
        [TestCase("Place 0,1,Down")]
        public void ShouldReturnFalse_IfPlaceCommandHas_InvalidDirection(string placeCommandText)
        {
            Assert.IsFalse(_placeTextCommand.IsMatch(placeCommandText));
        }
    }
}