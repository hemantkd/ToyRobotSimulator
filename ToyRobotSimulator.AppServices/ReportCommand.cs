using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    internal class ReportCommand : ICommandOption
    {
        private readonly ICommandValidator _commandValidator;
        private readonly IUserInteractionService _userInteractionService;

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

            if (_commandValidator.IsValid(BuildReportCommandText()))
            {
                string reportText = toyRobot.Report(); // Perform related action on the Toy Robot

                _userInteractionService.PrintText($"\n\n{reportText}\n");
            }
        }

        private string BuildReportCommandText()
        {
            return nameof(Command.Report).ToUpperInvariant();
        }
    }
}