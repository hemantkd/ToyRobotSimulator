using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    internal class ReportCommand : ICommandOption
    {
        private readonly IUserInteractionService _userInteractionService;

        public ReportCommand(IUserInteractionService userInteractionService)
        {
            _userInteractionService = userInteractionService;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Report;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            if (_userInteractionService.ClearScreenIfToyRobotIsDeactive(toyRobot)) return;

            string reportText = toyRobot.Report(); // Perform related action on the Toy Robot

            _userInteractionService.PrintText($"\n\n{reportText}\n");
        }
    }
}