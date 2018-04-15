using System;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    internal class ReportCommand : ICommandOption
    {
        private readonly ICommandValidator _commandValidator;

        public ReportCommand(ICommandValidator commandValidator)
        {
            _commandValidator = commandValidator;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Report;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            if (ClearScreenIfToyRobotIsAbsent(toyRobot)) return;
            if (_commandValidator.IsValid(nameof(Command.Report).ToUpperInvariant()))
                PrintText($"\n\n{toyRobot.Report()}\n");
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