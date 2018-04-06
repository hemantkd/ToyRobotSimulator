using NUnit.Framework;

namespace ToyRobotSimulator.Tests
{
    [TestFixture]
    public class CommandValidatorShould
    {
        [Test]
        public void ShouldReturnTrue_ForMoveCommand()
        {
            var commandValidator = new CommandValidator();

            Assert.IsTrue(commandValidator.IsValid("MOVE"));
        }

        [Test]
        public void ShouldReturnTrue_ForLeftCommand()
        {
            var commandValidator = new CommandValidator();

            Assert.IsTrue(commandValidator.IsValid("LEFT"));
        }

        [Test]
        public void ShouldReturnTrue_ForRightCommand()
        {
            var commandValidator = new CommandValidator();

            Assert.IsTrue(commandValidator.IsValid("RIGHT"));
        }
    }
}