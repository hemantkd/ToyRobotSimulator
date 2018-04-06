using System;

namespace ToyRobotSimulator
{
    public class CommandValidator
    {
        public bool IsValid(string command)
        {
            return command.Equals("Move", StringComparison.OrdinalIgnoreCase) ||
                   command.Equals("left", StringComparison.OrdinalIgnoreCase) ||
                   command.Equals("Right", StringComparison.OrdinalIgnoreCase) ||
                   command.Equals("RepOrt", StringComparison.OrdinalIgnoreCase);
        }
    }
}