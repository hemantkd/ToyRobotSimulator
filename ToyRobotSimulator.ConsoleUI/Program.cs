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
                    commandValidator: new CommandValidator(),
                    userInteractionService: new UserInteractionService(new CommandValidator())
                ),
                userInteractionService: new UserInteractionService(new CommandValidator()),
                toyRobot: new ToyRobot()
            );
            
            commandControl.Start();
        }
    }
}

