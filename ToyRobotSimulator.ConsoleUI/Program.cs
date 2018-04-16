using ToyRobotSimulator.AppServices;

namespace ToyRobotSimulator.ConsoleUI
{
    class Program
    {
        static void Main()
        {
            var commandControl = new CommandControl(new CommandExecutor(new CommandValidator()), new ToyRobot());
            commandControl.Start();
        }
    }
}

