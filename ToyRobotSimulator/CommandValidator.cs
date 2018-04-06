using System;
using System.Globalization;
using System.Linq;

namespace ToyRobotSimulator
{
    public class CommandValidator
    {
        public bool IsValid(string command)
        {
            return command.Equals("Move", StringComparison.OrdinalIgnoreCase) ||
                   command.Equals("left", StringComparison.OrdinalIgnoreCase) ||
                   command.Equals("Right", StringComparison.OrdinalIgnoreCase) ||
                   command.Equals("RepOrt", StringComparison.OrdinalIgnoreCase) ||
                   (command.StartsWith("place ", StringComparison.OrdinalIgnoreCase)
                    && PlaceCommandIsValid(command));
        }

        private bool PlaceCommandIsValid(string command)
        {
            string[] commandSplit = command.Split(' ');

            if (PlaceCommandHasNoParameters(commandSplit)) return false;

            string[] commandParameters = SplitIntoIndividualParameters(commandSplit);

            return PlaceCommandHasCorrectNumberOfParameters(commandParameters) &&
                AllParametersHaveValue(commandParameters) &&
                XParameterIsValid(commandParameters[0]) &&
                YParameterIsValid(commandParameters[1]);
        }

        private bool YParameterIsValid(string yParameter)
        {
            return IsAnInteger(yParameter);
        }

        private bool XParameterIsValid(string xParameter)
        {
            return IsAnInteger(xParameter);
        }

        private bool IsAnInteger(string parameter)
        {
            return int.TryParse(parameter, NumberStyles.Integer, CultureInfo.InvariantCulture, out _);
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