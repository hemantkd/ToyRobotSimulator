using ToyRobotSimulator.TextAppServices;

namespace ToyRobotSimulator.ConsoleTextUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Use an IoC Framework to resolve the dependencies
            var commandControl = new CommandControl(
                commandTextExecutor: new CommandTextExecutor(
                    commandTextValidator: new CommandTextValidator(),
                    userInteractionByTextService: new UserInteractionByTextService()
                ),
                userInteractionByTextService: new UserInteractionByTextService(),
                toyRobot: new ToyRobot()
            );

            commandControl.Start();
        }
    }
}
