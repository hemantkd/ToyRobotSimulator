using System;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    internal class LeftCommand : ICommandOption
    {
        private readonly ICommandValidator _commandValidator;

        public LeftCommand(ICommandValidator commandValidator)
        {
            _commandValidator = commandValidator;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Left;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            if (ClearScreenIfToyRobotIsAbsent(toyRobot)) return;
            if (_commandValidator.IsValid(nameof(Command.Left).ToUpperInvariant()))
            {
                toyRobot.RotateLeft();
                PrintText($"\n{nameof(Command.Left).ToUpperInvariant()} Command Executed!\n");
            }
        }

        private void PrintText(string text)
        {
            Console.Write(text);
        }

        private bool ClearScreenIfToyRobotIsAbsent(ToyRobot toyRobot)
        {
            if (toyRobot != null) return false;

            Console.Clear();
            return true;
        }
    }
}