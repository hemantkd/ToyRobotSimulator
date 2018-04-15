using System;
using System.Linq;
using System.Text;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.ConsoleUI
{
    public class CommandControl
    {
        private readonly ICommandExecutor _commandExecutor;

        public CommandControl(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        public void Start()
        {
            while (!_commandExecutor.Stop)
            {
                Command command = RequestCommandFromUser();
                _commandExecutor.Execute(command);
            }
        }
        private Command RequestCommandFromUser()
        {
            var stringBuilder = new StringBuilder()
                .AppendLine($"\nSelect Your Command")
                .AppendLine("-----------------------");

            var commands = Enum.GetValues(typeof(Command)).Cast<Command>().ToList();

            commands.ForEach(command => stringBuilder.AppendLine($"[{command:D}] {command}"));

            stringBuilder.AppendLine("-----------------------")
                .Append("=> ");

            PrintText(stringBuilder.ToString());

            var menuSelection = GetKeyFromUser();

            return (Command)Convert.ToInt32(menuSelection);
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