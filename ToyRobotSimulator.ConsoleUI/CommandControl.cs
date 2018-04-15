using System;
using System.Linq;
using System.Text;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.ConsoleUI
{
    public class CommandControl
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly ToyRobot _toyRobot;

        public CommandControl(ICommandExecutor commandExecutor, ToyRobot toyRobot)
        {
            _commandExecutor = commandExecutor;
            _toyRobot = toyRobot;
        }

        public void Start()
        {
            while (!_toyRobot.Deactivate)
            {
                Command command = RequestCommandFromUser();
                _commandExecutor.Execute(command, _toyRobot);
            }
        }

        private Command RequestCommandFromUser()
        {
            var stringBuilder = new StringBuilder()
                .AppendLine("\nSelect Your Command")
                .AppendLine("-----------------------");

            var commands = Enum.GetValues(typeof(Command)).Cast<Command>().ToList();
            commands.Remove(Command.Unknown);

            commands.ForEach(command => stringBuilder.AppendLine($"[{command:D}] {command}"));

            stringBuilder.AppendLine("-----------------------")
                .Append("=> ");

            PrintText(stringBuilder.ToString());

            var menuSelection = GetKeyFromUser();

            try
            {
                return (Command) Convert.ToInt32(menuSelection);
            }
            catch (Exception)
            {
                return Command.Unknown;
            };
        }

        private string GetKeyFromUser()
        {
            return Console.ReadKey().KeyChar.ToString();
        }

        private void PrintText(string text)
        {
            Console.Write(text);
        }
    }
}