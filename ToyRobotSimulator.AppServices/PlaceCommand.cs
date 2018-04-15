using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class PlaceCommand : ICommandOption
    {
        private readonly ICommandValidator _commandValidator;
        private int _x;
        private int _y;
        private Direction _f;

        public PlaceCommand(ICommandValidator commandValidator)
        {
            _commandValidator = commandValidator;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Place;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            RequestXCoordinate();
            RequestYCoordinate();
            RequestDirectionFacing();

            var placeCommand = $"{nameof(Command.Place).ToUpperInvariant()} {_x},{_y},{_f.ToString().ToUpperInvariant()}";

            if (_commandValidator.IsValid(placeCommand))
            {
                toyRobot.SetPosition(_x, _y, _f);
                PrintText($"\n{nameof(Command.Place).ToUpperInvariant()} Command Executed!\n");
            }
        }

        private void RequestDirectionFacing()
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
                    _f = directions[Convert.ToInt32(GetKeyFromUser()) - 1];
                    break;
                }
                catch (Exception)
                {
                    PrintText("\nInvalid selection. Please try again... => ");
                }
            }
        }

        private void RequestYCoordinate()
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
                    break;
                }
            }
        }

        private void RequestXCoordinate()
        {
            while (true)
            {
                PrintText($"\nEnter the parameter X for the PLACE command [0-5] => ");

                if (!XCoordinateIsValid())
                {
                    PrintText("\nInvalid value entered for X. Please try again...\n");
                }
                else
                {
                    break;
                }
            }
        }

        private bool XCoordinateIsValid()
        {
            return int.TryParse(GetKeyFromUser(), NumberStyles.Integer, CultureInfo.InvariantCulture, out _x)
                   && _commandValidator.XParameterIsValid(_x.ToString());
        }

        private bool YCoordinateIsValid()
        {
            return int.TryParse(GetKeyFromUser(), NumberStyles.Integer, CultureInfo.InvariantCulture, out _y)
                   && _commandValidator.YParameterIsValid(_y.ToString());
        }

        private string GetKeyFromUser()
        {
            return Console.ReadKey().KeyChar.ToString();
        }

        private void PrintText(string text)
        {
            Console.Write(text);
        }
    }
}