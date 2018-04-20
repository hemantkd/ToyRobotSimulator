using System;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    public class PlaceTextCommand : ICommandTextOption
    {
        private int _x, _y;
        private Direction _f;
        private readonly ICommandTextValidator _commandTextValidator;

        public PlaceTextCommand(ICommandTextValidator commandTextValidator)
        {
            _commandTextValidator = commandTextValidator;
        }

        public bool IsMatch(string commandText)
        {
            return commandText.StartsWith(nameof(Command.Place), StringComparison.OrdinalIgnoreCase) &&
                   _commandTextValidator.PlaceCommandIsValid(commandText: commandText, x: out _x, y: out _y, f: out _f);
        }

        public void Execute(string commandText, ToyRobot toyRobot)
        {
            toyRobot.SetPosition(xCoordinate: _x, yCoordinate: _y, facing: _f);
        }
    }
}