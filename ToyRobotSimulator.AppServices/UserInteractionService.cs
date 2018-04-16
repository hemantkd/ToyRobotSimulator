using System;
using System.Linq;
using System.Text;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class UserInteractionService : IUserInteractionService
    {
        public string GetCommandSelection()
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

            return GetKeyFromUser();
        }

        public string GetKeyFromUser()
        {
            return Console.ReadKey().KeyChar.ToString();
        }

        public void PrintText(string text)
        {
            Console.Write(text);
        }
    }
}