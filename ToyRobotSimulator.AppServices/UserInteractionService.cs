using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyRobotSimulator.AppInterfaces;
using ToyRobotSimulator.CommonAppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class UserInteractionService : Boundary, IUserInteractionService
    {
        private readonly ICommandTextValidator _commandTextValidator;

        public UserInteractionService(ICommandTextValidator commandTextValidator)
        {
            _commandTextValidator = commandTextValidator;
        }

        public Command GetCommand()
        {
            var stringBuilder = new StringBuilder()
                .AppendLine("\n\nSelect Your Command")
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
                    PrintText("\nInvalid selection. Please try again... => ");
                }
            }
        }

        public int RequestXCoordinate()
        {
            while (true)
            {
                PrintText("\nEnter the parameter X for the PLACE command [0-5] => ");

                if (!_commandTextValidator.TryParseXParameter(GetKeyFromUser(), out int x) ||
                    !XCoordinateIsInRange(x))
                {
                    PrintText("\nInvalid value entered for X. Please try again...\n");
                }
                else
                {
                    return x;
                }
            }
        }

        public int RequestYCoordinate()
        {
            while (true)
            {
                PrintText("\nEnter the parameter Y for the PLACE command [0-5] => ");

                if (!_commandTextValidator.TryParseYParameter(GetKeyFromUser(), out int y) ||
                    !YCoordinateIsInRange(y))
                {
                    PrintText("\nInvalid value entered for Y. Please try again...\n");
                }
                else
                {
                    return y;
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
            if (toyRobot != null && Quit == false) return false;

            Console.Clear();
            return true;
        }

        public void PrintCommandExecuted(string commandName)
        {
            PrintText($"\n{commandName.ToUpperInvariant()} Command Executed!\n");
        }

        public bool Quit { get; set; }

        private string GetMenuOptionFormat<T>(T enumValue)
        {
            return $"[{enumValue:D}] {enumValue}".ToUpperInvariant();
        }

        private T MapKeyToEnumValue<T>(int enumKey, IReadOnlyList<T> enumList)
        {
            return enumList[index: enumKey - 1];
        }

        private int GetDirectionKeyFromUser()
        {
            return int.Parse(GetKeyFromUser());
        }
    }
}