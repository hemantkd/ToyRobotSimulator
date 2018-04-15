namespace ToyRobotSimulator.AppInterfaces
{
    public interface ICommandOption
    {
        bool IsMatch(Command command);
        void Execute(Command command, ToyRobot toyRobot);
    }
}