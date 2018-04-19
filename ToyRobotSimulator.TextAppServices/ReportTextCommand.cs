using ToyRobotSimulator.AppInterfaces;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    public class ReportTextCommand : ICommandTextOption
    {
        private readonly ICommandTextValidator _commandTextValidator;
        private readonly IUserInteractionByTextService _userInteractionByTextService;

        public ReportTextCommand(ICommandTextValidator commandTextValidator, IUserInteractionByTextService userInteractionByTextService)
        {
            _commandTextValidator = commandTextValidator;
            _userInteractionByTextService = userInteractionByTextService;
        }

        public bool IsMatch(string commandText)
        {
            return _commandTextValidator.IsReportCommand(commandText);
        }

        public void Execute(string commandText, ToyRobot toyRobot)
        {
            _userInteractionByTextService.PrintText($"   {toyRobot.Report()}\n");
        }
    }
}