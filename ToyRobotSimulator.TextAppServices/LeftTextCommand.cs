using System;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    public class LeftTextCommand : ICommandTextOption
    {
        public bool IsMatch(string commandText)
        {
            return commandText.Equals(nameof(Command.Left), StringComparison.OrdinalIgnoreCase);
        }

        public void Execute(string commandText, ToyRobot toyRobot)
        {
            toyRobot.RotateLeft();
        }
    }
}