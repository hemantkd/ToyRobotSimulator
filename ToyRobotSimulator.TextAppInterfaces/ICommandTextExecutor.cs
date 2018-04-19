namespace ToyRobotSimulator.TextAppInterfaces
{
    public interface ICommandTextExecutor
    {
        void Execute(string commandText, ToyRobot toyRobot);
    }
}