using System;
using System.Linq;
using ToyRobotSimulator.CommonAppInterfaces;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    public class PlaceTextCommand : Boundary, ICommandTextOption
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
                   PlaceCommandIsValid(commandText: commandText, x: out _x, y: out _y, f: out _f);
        }
        
        public void Execute(string commandText, ToyRobot toyRobot)
        {
            toyRobot.SetPosition(xCoordinate: _x, yCoordinate: _y, facing: _f);
        }

        private bool PlaceCommandIsValid(string commandText, out int x, out int y, out Direction f)
        {
            try
            {
                string[] commandSplit = commandText.Split(' ');
                string[] parameters = SplitIntoIndividualParameters(commandSplit);

                if (!_commandTextValidator.TryParseXParameter(parameters[0], out x) ||
                    !XCoordinateIsInRange(x) ||
                    !_commandTextValidator.TryParseYParameter(parameters[1], out y) ||
                    !YCoordinateIsInRange(y) ||
                    !TryParseDirection(parameters[2], out f))
                {
                    SetDefaults(out x, out y, out f);
                    return false;
                }
            }
            catch (Exception)
            {
                SetDefaults(out x, out y, out f);
                return false;
            }

            return true;
        }

        private bool TryParseDirection(string directionParameter, out Direction f)
        {
            var directions = Enum.GetValues(typeof(Direction))
                .Cast<Direction>()
                .Select(d => $"{d}")
                .ToArray();

            var index = Array.FindIndex(directions,
                d => d.Equals(directionParameter, StringComparison.OrdinalIgnoreCase));

            if (index == -1)
            {
                f = default(Direction);
                return false;
            }

            f = (Direction)(index + 1);

            return true;
        }

        private string[] SplitIntoIndividualParameters(string[] commandSplit)
        {
            return commandSplit[1].Split(',');
        }

        private void SetDefaults(out int xParam, out int yParam, out Direction fParam)
        {
            xParam = yParam = default(int);
            fParam = default(Direction);
        }
    }
}