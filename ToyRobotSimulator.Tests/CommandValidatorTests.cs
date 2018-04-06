﻿using NUnit.Framework;

namespace ToyRobotSimulator.Tests
{
    [TestFixture]
    public class CommandValidatorTests
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

        [Test]
        public void ShouldReturnTrue_ForReportCommand()
        {
            var commandValidator = new CommandValidator();

            Assert.IsTrue(commandValidator.IsValid("REPORT"));
        }

        [Test]
        public void ShouldReturnTrue_ForPlaceCommand()
        {
            var commandValidator = new CommandValidator();

            Assert.IsTrue(commandValidator.IsValid("PLACE 0,0,NORTH"));
        }

        [TestCase("PLACE 0,NORTH")]
        [TestCase("PLACE 0,0,0,NORTH")]
        [TestCase("PLACE 0,0")]
        [TestCase("PLACE 0,0,")]
        [TestCase("PLACE ,0,")]
        [TestCase("PLACE ,0,NORTH")]
        public void ShouldReturnFalse_IfPlaceCommandHasElementsMissing(string placeCommand)
        {
            var commandValidator = new CommandValidator();

            Assert.IsFalse(commandValidator.IsValid(placeCommand));
        }

        [TestCase("PLACE WEST,0,NORTH")]
        [TestCase("PLACE 0,EAST,0")]
        public void ShouldReturnFalse_IfPlaceCommandHasANonIntegerXOrYParameter(string placeCommand)
        {
            var commandValidator = new CommandValidator();

            Assert.IsFalse(commandValidator.IsValid(placeCommand));
        }
    }
}