using System;
using System.Globalization;
using System.Linq;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    public class CommandTextValidator : ICommandTextValidator
    {
        public bool IsValid(string commandText)
        {
            return IsMoveCommand(commandText) ||
                   IsLeftCommand(commandText) ||
                   IsRightCommand(commandText) ||
                   IsReportCommand(commandText) ||
                   (IsPlaceCommand(commandText) && PlaceCommandIsValid(commandText, out _, out _, out _));
        }

        public bool IsReportCommand(string commandText)
        {
            return commandText.Equals(nameof(Command.Report), StringComparison.OrdinalIgnoreCase);
        }

        public bool IsRightCommand(string commandText)
        {
            return commandText.Equals(nameof(Command.Right), StringComparison.OrdinalIgnoreCase);
        }

        public bool IsMoveCommand(string commandText)
        {
            return commandText.Equals(nameof(Command.Move), StringComparison.OrdinalIgnoreCase);
        }

        public bool IsLeftCommand(string commandText)
        {
            return commandText.Equals(nameof(Command.Left), StringComparison.OrdinalIgnoreCase);
        }

        public bool PlaceCommandIsValid(string commandText, out int x, out int y, out Direction f)
        {
            try
            {
                string[] commandSplit = commandText.Split(' ');
                string[] parameters = SplitIntoIndividualParameters(commandSplit);

                if (!TryParseXParameter(parameters[0], out x) ||
                    !TryParseYParameter(parameters[1], out y) ||
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

        public bool TryParseXParameter(string xParameter, out int x)
        {
            return
                int.TryParse(xParameter, NumberStyles.Integer, CultureInfo.InvariantCulture, out x)
                && IsInTheRange(x);
        }

        public bool TryParseYParameter(string yParameter, out int y)
        {
            return
                int.TryParse(yParameter, NumberStyles.Integer, CultureInfo.InvariantCulture, out y)
                && IsInTheRange(y);
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

        public bool IsPlaceCommand(string commandText)
        {
            return commandText.StartsWith(nameof(Command.Place), StringComparison.OrdinalIgnoreCase);
        }

        private bool IsInTheRange(int parameter)
        {
            return parameter >= 0 && parameter <= 5;
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