using System;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class UnknownCommand : ICommandOption
    {
        public bool IsMatch(Command command)
        {
            return command == Command.Unknown;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            PrintText("\nInvalid command selected. Please try again...\n");
        }

        private void PrintText(string text)
        {
            Console.Write(text);
        }
    }
}