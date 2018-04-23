using ToyRobotSimulator.AppServices;
using ToyRobotSimulator.CommonAppServices;

namespace ToyRobotSimulator.ConsoleUI
{
    class Program
    {
        static void Main()
        {
            // TODO: Use an IoC Framework to resolve the dependencies

            var commandTextValidator = new CommandTextValidator();
            var userInteractionService = new UserInteractionService(commandTextValidator);
            
            var commandControl = new CommandControl(
                commandExecutor: new CommandExecutor(userInteractionService),
                userInteractionService: userInteractionService,
                toyRobot: new ToyRobot()
            );
            
            commandControl.Start();
        }
    }
}

