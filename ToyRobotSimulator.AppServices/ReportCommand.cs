using ToyRobotSimulator.AppInterfaces;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    internal class ReportCommand : ICommandOption
    {
        private readonly ICommandTextValidator _commandTextValidator;
        private readonly IUserInteractionService _userInteractionService;

        public string CommandName => nameof(Command.Report);

        public ReportCommand(ICommandTextValidator commandTextValidator, IUserInteractionService userInteractionService)
        {
            _commandTextValidator = commandTextValidator;
            _userInteractionService = userInteractionService;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Report;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            if (_userInteractionService.ClearScreenIfToyRobotIsDeactive(toyRobot)) return;

            var reportCommandText = CommandName;

            if (!_commandTextValidator.IsValid(reportCommandText)) return;

            string reportText = toyRobot.Report(); // Perform related action on the Toy Robot

            _userInteractionService.PrintText($"\n\n{reportText}\n");
        }
    }
}