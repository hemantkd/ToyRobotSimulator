using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class RightCommand : ICommandOption
    {
        private readonly ICommandTextValidator _commandTextValidator;
        private readonly IUserInteractionService _userInteractionService;

        public string CommandName => nameof(Command.Report);

        public RightCommand(ICommandTextValidator commandTextValidator, IUserInteractionService userInteractionService)
        {
            _commandTextValidator = commandTextValidator;
            _userInteractionService = userInteractionService;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Right;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            if (_userInteractionService.ClearScreenIfToyRobotIsDeactive(toyRobot)) return;

            var rightCommandText = CommandName;

            if (!_commandTextValidator.IsValid(rightCommandText)) return;

            toyRobot.RotateRight(); // Perform related action on the Toy Robot

            _userInteractionService.PrintCommandExecuted(CommandName);
        }
    }
}