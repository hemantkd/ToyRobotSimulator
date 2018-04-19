using System;
using System.Text;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    public class UserInteractionByTextService : IUserInteractionByTextService
    {
        public string GetTextLine()
        {
            return Console.ReadLine();
        }

        public void PrintTextCommandsMenu()
        {
            var stringBuilder = new StringBuilder()
                .AppendLine("\nEnter Your Command")
                .AppendLine("-----------------------")
                .AppendLine("PLACE X,Y,Direction | MOVE | LEFT | RIGHT | REPORT")
                .AppendLine("-----------------------");

            PrintText(stringBuilder.ToString());
        }

        public void PrintText(string text)
        {
            Console.Write(text);
        }
    }
}