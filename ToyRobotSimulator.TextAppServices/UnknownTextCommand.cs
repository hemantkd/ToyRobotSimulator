using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    public class UnknownTextCommand : ICommandTextOption
    {
        public bool IsMatch(string commandText)
        {
            return true;
        }

        public void Execute(string commandText, ToyRobot toyRobot)
        {
            // Do nothing when executing this command.
        }
    }
}