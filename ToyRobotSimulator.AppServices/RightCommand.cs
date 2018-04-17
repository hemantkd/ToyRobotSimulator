using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class RightCommand : ICommandOption
    {
        private readonly ICommandValidator _commandValidator;
        private readonly IUserInteractionService _userInteractionService;

        public RightCommand(ICommandValidator commandValidator, IUserInteractionService userInteractionService)
        {
            _commandValidator = commandValidator;
            _userInteractionService = userInteractionService;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Right;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            if (_userInteractionService.ClearScreenIfToyRobotIsDeactive(toyRobot)) return;

            if (_commandValidator.IsValid(BuildRightCommandText()))
            {
                toyRobot.RotateRight(); // Perform related action on the Toy Robot

                _userInteractionService.PrintText($"\n{BuildRightCommandText()} Command Executed!\n");
            }
        }

        private string BuildRightCommandText()
        {
            return nameof(Command.Right).ToUpperInvariant();
        }
    }
}