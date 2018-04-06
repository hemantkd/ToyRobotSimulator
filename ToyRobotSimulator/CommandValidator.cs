using System;

namespace ToyRobotSimulator
{
    public class CommandValidator
    {
        public bool IsValid(string command)
        {
            return command.Equals("Move", StringComparison.OrdinalIgnoreCase);
        }
    }
}