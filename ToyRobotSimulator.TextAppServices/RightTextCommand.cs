using System;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    public class RightTextCommand : ICommandTextOption
    {
        public bool IsMatch(string commandText)
        {
            return commandText.Equals(nameof(Command.Right), StringComparison.OrdinalIgnoreCase);
        }

        public void Execute(string commandText, ToyRobot toyRobot)
        {
            toyRobot.RotateRight();
        }
    }
}