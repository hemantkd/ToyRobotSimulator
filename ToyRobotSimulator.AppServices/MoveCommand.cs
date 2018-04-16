using System;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class MoveCommand : ICommandOption
    {
        private readonly ICommandValidator _commandValidator;

        public MoveCommand(ICommandValidator commandValidator)
        {
            _commandValidator = commandValidator;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Move;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            if (ClearScreenIfToyRobotIsAbsent(toyRobot)) return;
            if (_commandValidator.IsValid(nameof(Command.Move).ToUpperInvariant()))
            {
                toyRobot.Move();
                PrintText($"\n{nameof(Command.Move).ToUpperInvariant()} Command Executed!\n");
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