using ToyRobotSimulator.AppServices;

namespace ToyRobotSimulator.ConsoleUI
{
    class Program
    {
        static void Main()
        {
            // TODO: Use an IoC Framework to resolve the dependencies
            var commandControl = new CommandControl(
                commandExecutor: new CommandExecutor(
                    commandTextValidator: new CommandTextValidator(),
                    userInteractionService: new UserInteractionService(new CommandTextValidator())
                ),
                userInteractionService: new UserInteractionService(new CommandTextValidator()),
                toyRobot: new ToyRobot()
            );
            
            commandControl.Start();
        }
    }
}

