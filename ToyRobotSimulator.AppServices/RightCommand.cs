using System;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class RightCommand : ICommandOption
    {
        private readonly ICommandValidator _commandValidator;

        public RightCommand(ICommandValidator commandValidator)
        {
            _commandValidator = commandValidator;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Right;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            if (ClearScreenIfToyRobotIsAbsent(toyRobot)) return;
            if (_commandValidator.IsValid(nameof(Command.Right).ToUpperInvariant()))
            {
                toyRobot.RotateRight();
                PrintText($"\n{nameof(Command.Right).ToUpperInvariant()} Command Executed!\n");
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