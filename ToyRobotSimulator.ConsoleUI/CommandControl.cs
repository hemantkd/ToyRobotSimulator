using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ToyRobotSimulator.ConsoleUI
{
    internal class CommandControl
    {
        private ToyRobot _toyRobot;
        private Command _command;
        private int _x;
        private int _y;
        private Direction _f;
        private readonly CommandValidator _commandValidator;

        public CommandControl(CommandValidator commandValidator)
        {
            _commandValidator = commandValidator;
        }

        public void Start()
        {
            while (true)
            {
                _command = RequestCommandFromUser();

                switch (_command)
                {
                    case Command.Quit:
                        PrintText("\nQuitting...\n");
                        return;

                    case Command.Place:
                        RequestXCoordinate();
                        RequestYCoordinate();
                        RequestDirectionFacing();

                        var placeCommand = $"{nameof(Command.Place).ToUpperInvariant()} {_x},{_y},{_f.ToString().ToUpperInvariant()}";

                        if (_commandValidator.IsValid(placeCommand))
                        {
                            _toyRobot = new ToyRobot(_x, _y, _f);
                            PrintText($"\n{nameof(Command.Place).ToUpperInvariant()} Command Executed!\n");
                        }
                        break;

                    case Command.Move:
                        if (ClearScreenIfToyRobotIsAbsent()) break;
                        if (_commandValidator.IsValid(nameof(Command.Move).ToUpperInvariant()))
                        {
                            _toyRobot.Move();
                            PrintText($"\n{nameof(Command.Move).ToUpperInvariant()} Command Executed!\n");
                        }
                        break;

                    case Command.Left:
                        if (ClearScreenIfToyRobotIsAbsent()) break;
                        if (_commandValidator.IsValid(nameof(Command.Left).ToUpperInvariant()))
                        {
                            _toyRobot.RotateLeft();
                            PrintText($"\n{nameof(Command.Left).ToUpperInvariant()} Command Executed!\n");
                        }
                        break;

                    case Command.Right:
                        if (ClearScreenIfToyRobotIsAbsent()) break;
                        if (_commandValidator.IsValid(nameof(Command.Right).ToUpperInvariant()))
                        {
                            _toyRobot.RotateRight();
                            PrintText($"\n{nameof(Command.Right).ToUpperInvariant()} Command Executed!\n");
                        }
                        break;

                    case Command.Report:
                        if (ClearScreenIfToyRobotIsAbsent()) break;
                        if (_commandValidator.IsValid(nameof(Command.Report).ToUpperInvariant()))
                            PrintText($"\n\n{_toyRobot.Report()}\n");
                        break;

                    default:
                        PrintText("Invalid option selected. Please try again...\n");
                        break;
                }
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

        private bool ClearScreenIfToyRobotIsAbsent()
        {
            if (_toyRobot != null) return false;

            Console.Clear();
            return true;
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

        private Command RequestCommandFromUser()
        {
            var stringBuilder = new StringBuilder()
                .AppendLine($"\nSelect Your {(_toyRobot != null ? "Next " : string.Empty)}Command")
                .AppendLine("-----------------------");

            var commands = Enum.GetValues(typeof(Command)).Cast<Command>().ToList();

            commands.ForEach(command => stringBuilder.AppendLine($"[{command:D}] {command}"));

            stringBuilder.AppendLine("-----------------------")
                .Append("=> ");

            PrintText(stringBuilder.ToString());

            var menuSelection = GetKeyFromUser();

            return (Command)Convert.ToInt32(menuSelection);
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