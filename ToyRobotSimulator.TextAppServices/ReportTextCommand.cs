using System;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    public class ReportTextCommand : ICommandTextOption
    {
        private readonly IUserInteractionByTextService _userInteractionByTextService;

        public ReportTextCommand(IUserInteractionByTextService userInteractionByTextService)
        {
            _userInteractionByTextService = userInteractionByTextService;
        }

        public bool IsMatch(string commandText)
        {
            return commandText.Equals(nameof(Command.Report), StringComparison.OrdinalIgnoreCase);
        }

        public void Execute(string commandText, ToyRobot toyRobot)
        {
            _userInteractionByTextService.PrintText($"   {toyRobot.Report()}\n");
        }
    }
}