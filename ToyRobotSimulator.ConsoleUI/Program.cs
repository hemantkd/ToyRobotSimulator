namespace ToyRobotSimulator.ConsoleUI
{
    class Program
    {
        static void Main()
        {
            var commandControl = new CommandControl(new CommandValidator());
            commandControl.Start();
        }
    }
}

