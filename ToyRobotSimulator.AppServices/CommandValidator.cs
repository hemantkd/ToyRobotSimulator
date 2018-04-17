using System;
using System.Globalization;
using System.Linq;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class CommandTextValidator : ICommandTextValidator
    {
        private const bool IsNotValid = false;

        public bool IsValid(string command)
        {
            return command.Equals(nameof(Command.Move), StringComparison.OrdinalIgnoreCase) ||
                   command.Equals(nameof(Command.Left), StringComparison.OrdinalIgnoreCase) ||
                   command.Equals(nameof(Command.Right), StringComparison.OrdinalIgnoreCase) ||
                   command.Equals(nameof(Command.Report), StringComparison.OrdinalIgnoreCase) ||
                   (command.StartsWith(nameof(Command.Place), StringComparison.OrdinalIgnoreCase)
                    && PlaceCommandIsValid(command));
        }

        private bool PlaceCommandIsValid(string command)
        {
            string[] commandSplit = command.Split(' ');

            if (PlaceCommandHasNoParameters(commandSplit)) return IsNotValid;

            string[] commandParameters = SplitIntoIndividualParameters(commandSplit);

            return PlaceCommandHasCorrectNumberOfParameters(commandParameters) &&
                AllParametersHaveValue(commandParameters) &&
                XParameterIsValid(commandParameters[0]) &&
                YParameterIsValid(commandParameters[1]) &&
                DirectionIsValid(commandParameters[2]);
        }

        private bool DirectionIsValid(string directionParameter)
        {
            return directionParameter.Equals(nameof(Direction.North), StringComparison.OrdinalIgnoreCase) ||
                   directionParameter.Equals(nameof(Direction.South), StringComparison.OrdinalIgnoreCase) ||
                   directionParameter.Equals(nameof(Direction.West), StringComparison.OrdinalIgnoreCase) ||
                   directionParameter.Equals(nameof(Direction.East), StringComparison.OrdinalIgnoreCase);
        }

        public bool XParameterIsValid(string xParameter)
        {
            if (IsNotAnInteger(xParameter)) return IsNotValid;

            var x = int.Parse(xParameter, NumberStyles.Integer);

            return IsInTheRange(x);
        }

        public bool YParameterIsValid(string yParameter)
        {
            if(IsNotAnInteger(yParameter)) return IsNotValid;
            
            var y = int.Parse(yParameter, NumberStyles.Integer);
            
            return IsInTheRange(y);
        }

        private bool IsInTheRange(int parameter)
        {
            return parameter >= 0 && parameter <= 5;
        }

        private bool IsNotAnInteger(string parameter)
        {
            return !int.TryParse(parameter, NumberStyles.Integer, CultureInfo.InvariantCulture, out _);
        }

        private bool AllParametersHaveValue(string[] commandParameters)
        {
            return commandParameters.All(cp => !string.IsNullOrEmpty(cp));
        }

        private bool PlaceCommandHasCorrectNumberOfParameters(string[] commandParameters)
        {
            return commandParameters.Length == 3;
        }

        private string[] SplitIntoIndividualParameters(string[] commandSplit)
        {
            return commandSplit[1].Split(',');
        }

        private bool PlaceCommandHasNoParameters(string[] commandSplit)
        {
            return commandSplit.Length != 2;
        }
    }
}