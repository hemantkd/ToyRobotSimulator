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

            commands.ForEach(command => stringBuilder.AppendLine(GetMenuOptionFormat(command)));

            stringBuilder.AppendLine("-----------------------")
                .Append("=> ");

            PrintText(stringBuilder.ToString());

            var commandKey = int.Parse(GetKeyFromUser());

            return MapKeyToEnumValue(commandKey, commands);
        }

        public Direction RequestDirectionFacing()
        {
            var stringBuilder = new StringBuilder()
                .AppendLine("\n-----------------------")
                .AppendLine("Select The Direction Facing")
                .AppendLine("-----------------------");

            var directions = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();

            directions.ForEach(direction => stringBuilder.AppendLine(GetMenuOptionFormat(direction)));

            stringBuilder.AppendLine("-----------------------")
                .Append("=> ");

            PrintText(stringBuilder.ToString());

            while (true)
            {
                try
                {
                    int directionKey = GetDirectionKeyFromUser();

                    return MapKeyToEnumValue(directionKey, directions);
                }
                catch (Exception)
                {
                    PrintInvalidSelection();
                }
            }
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

        public void PrintInvalidSelection()
        {
            PrintText("\nInvalid selection. Please try again... => ");
        }

        public void PrintCommandExecuted(string commandName)
        {
            PrintText($"\n{commandName.ToUpperInvariant()} Command Executed!\n");
        }

        private string GetMenuOptionFormat<T>(T enumValue)
        {
            return $"[{enumValue:D}] {enumValue}".ToUpperInvariant();
        }

        private T MapKeyToEnumValue<T>(int enumKey, IReadOnlyList<T> enumList)
        {
            return enumList[index: enumKey - 1];
        }

        //private Command MapKeyToCommand(int commandKey, IReadOnlyList<Command> commands)
        //{
        //    return commands[index: commandKey - 1];
        //}

        //private Direction MapKeyToDirection(int directionKey, IReadOnlyList<Direction> directions)
        //{
        //    return directions[index: directionKey - 1];
        //}

        private int GetDirectionKeyFromUser()
        {
            return int.Parse(GetKeyFromUser());
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