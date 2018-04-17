using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class LeftCommand : ICommandOption
    {
        private readonly ICommandValidator _commandValidator;
        private readonly IUserInteractionService _userInteractionService;

        public LeftCommand(ICommandValidator commandValidator, IUserInteractionService userInteractionService)
        {
            _commandValidator = commandValidator;
            _userInteractionService = userInteractionService;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Left;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            if (_userInteractionService.ClearScreenIfToyRobotIsDeactive(toyRobot)) return;

            if (_commandValidator.IsValid(BuildLeftCommandText()))
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