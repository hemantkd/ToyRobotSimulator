using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class LeftCommand : ICommandOption
    {
        private readonly ICommandValidator _commandValidator;
        private readonly IUserInteractionService _userInteractionService;

        public string CommandName => nameof(Command.Left);

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

            var leftCommandText = CommandName;

            if (!_commandValidator.IsValid(leftCommandText)) return;

            toyRobot.RotateLeft(); // Perform related action on the Toy Robot

            _userInteractionService.PrintCommandExecuted(CommandName);
        }
    }
}