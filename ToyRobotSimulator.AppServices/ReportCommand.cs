using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    internal class ReportCommand : ICommandOption
    {
        private readonly ICommandValidator _commandValidator;
        private readonly IUserInteractionService _userInteractionService;

        public string CommandName => nameof(Command.Report);

        public ReportCommand(ICommandValidator commandValidator, IUserInteractionService userInteractionService)
        {
            _commandValidator = commandValidator;
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

            if (!_commandValidator.IsValid(reportCommandText)) return;

            string reportText = toyRobot.Report(); // Perform related action on the Toy Robot

            _userInteractionService.PrintText($"\n\n{reportText}\n");
        }
    }
}