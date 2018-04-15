namespace ToyRobotSimulator.AppInterfaces
{
    public interface ICommandExecutor
    {
        bool Stop { get; }

        void Execute(Command command);
    }
}