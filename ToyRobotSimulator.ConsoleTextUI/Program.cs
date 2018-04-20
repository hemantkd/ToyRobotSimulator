using ToyRobotSimulator.CommonAppServices;
using ToyRobotSimulator.TextAppServices;

namespace ToyRobotSimulator.ConsoleTextUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Use an IoC Framework to resolve the dependencies
            var textCommandControl = new TextCommandControl(
                commandTextExecutor: new CommandTextExecutor(
                    commandTextValidator: new CommandTextValidator(),
                    userInteractionByTextService: new UserInteractionByTextService()
                ),
                userInteractionByTextService: new UserInteractionByTextService(),
                toyRobot: new ToyRobot()
            );

            textCommandControl.Start();
        }
    }
}
