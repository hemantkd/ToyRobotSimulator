using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class QuitCommand : ICommandOption
    {
        public bool IsMatch(Command command)
        {
            return command == Command.Quit;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            toyRobot.Deactivate = true;
        }
    }
}