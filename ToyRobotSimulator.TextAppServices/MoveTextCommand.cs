using System;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    public class MoveTextCommand : ICommandTextOption
    {
        public bool IsMatch(string commandText)
        {
            return commandText.Equals(nameof(Command.Move), StringComparison.OrdinalIgnoreCase);
        }

        public void Execute(string commandText, ToyRobot toyRobot)
        {
            toyRobot.Move();
        }
    }
}