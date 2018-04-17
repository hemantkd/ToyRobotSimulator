using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class LeftCommand : ICommandOption
    {
        private readonly ICommandTextValidator _commandTextValidator;
        private readonly IUserInteractionService _userInteractionService;

        public LeftCommand(ICommandTextValidator commandTextValidator, IUserInteractionService userInteractionService)
        {
            _commandTextValidator = commandTextValidator;
            _userInteractionService = userInteractionService;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Left;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            if (_userInteractionService.ClearScreenIfToyRobotIsDeactive(toyRobot)) return;

            if (_commandTextValidator.IsValid(BuildLeftCommandText()))
            {
                toyRobot.RotateLeft(); // Perform related action on the Toy Robot

                _userInteractionService.PrintText($"\n{BuildLeftCommandText()} Command Executed!\n");
            }
        }

        private string BuildLeftCommandText()
        {
            return nameof(Command.Left).ToUpperInvariant();
        }
    }
}