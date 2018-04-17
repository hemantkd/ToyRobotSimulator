using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class UserInteractionService : IUserInteractionService
    {
        private readonly ICommandTextValidator _commandTextValidator;
        
        private int _x;
        private int _y;

        public UserInteractionService(ICommandTextValidator commandTextValidator)
        {
            _commandTextValidator = commandTextValidator;
        }

        public Command GetCommand()
        {
            var stringBuilder = new StringBuilder()
                .AppendLine("\nSelect Your Command")
                .AppendLine("-----------------------");

            var commands = Enum.GetValues(typeof(Command)).Cast<Command>().ToList();
            commands.Remove(Command.Unknown);

            commands.ForEach(command => stringBuilder.AppendLine($"[{command:D}] {command}"));

            stringBuilder.AppendLine("-----------------------")
                .Append("=> ");

            PrintText(stringBuilder.ToString());

            var commandKey = Convert.ToInt32(GetKeyFromUser());

            return commands[commandKey - 1];
        }

        public Direction RequestDirectionFacing()
        {
            var stringBuilder = new StringBuilder()
                .AppendLine("\n-----------------------")
                .AppendLine("Select The Direction Facing")
                .AppendLine("-----------------------");

            List<Direction> directions = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();

            directions.ForEach(direction =>
                stringBuilder.AppendLine($"[{direction:D}] {direction}".ToUpperInvariant()));

            stringBuilder.AppendLine("-----------------------")
                .Append("=> ");

            PrintText(stringBuilder.ToString());

            while (true)
            {
                try
                {
                    int directionKey = GetDirectionKeyFromUser();

                    return MapKeyToDirection(directionKey, directions);
                }
                catch (Exception)
                {
                    PrintText("\nInvalid selection. Please try again... => ");
                }
            }
        }

        private Direction MapKeyToDirection(int directionKey, IReadOnlyList<Direction> directions)
        {
            return directions[directionKey - 1];
        }

        private int GetDirectionKeyFromUser()
        {
            return Convert.ToInt32(GetKeyFromUser());
        }

        public int RequestYCoordinate()
        {
            while (true)
            {
                PrintText("\nEnter the parameter Y for the PLACE command [0-5] => ");

                if (!YCoordinateIsValid())
                {
                    PrintText("\nInvalid value entered for Y. Please try again...\n");
                }
                else
                {
                    return _y;
                }
            }
        }

        public int RequestXCoordinate()
        {
            while (true)
            {
                PrintText("\nEnter the parameter X for the PLACE command [0-5] => ");

                if (!XCoordinateIsValid())
                {
                    PrintText("\nInvalid value entered for X. Please try again...\n");
                }
                else
                {
                    return _x;
                }
            }
        }

        public string GetKeyFromUser()
        {
            return Console.ReadKey().KeyChar.ToString();
        }

        public void PrintText(string text)
        {
            Console.Write(text);
        }

        public bool ClearScreenIfToyRobotIsDeactive(ToyRobot toyRobot)
        {
            if (toyRobot != null && !toyRobot.Deactivate) return false;

            Console.Clear();
            return true;
        }

        private bool XCoordinateIsValid()
        {
            return int.TryParse(GetKeyFromUser(), NumberStyles.Integer, CultureInfo.InvariantCulture, out _x)
                   && _commandTextValidator.XParameterIsValid(_x.ToString());
        }

        private bool YCoordinateIsValid()
        {
            return int.TryParse(GetKeyFromUser(), NumberStyles.Integer, CultureInfo.InvariantCulture, out _y)
                   && _commandTextValidator.YParameterIsValid(_y.ToString());
        }
    }
}