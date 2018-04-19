namespace ToyRobotSimulator.TextAppInterfaces
{
    public interface ICommandTextOption
    {
        bool IsMatch(string commandText);
        void Execute(string commandText, ToyRobot toyRobot);
    }
}