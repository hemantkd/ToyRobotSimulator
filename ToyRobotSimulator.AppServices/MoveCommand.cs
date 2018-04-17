using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class MoveCommand : ICommandOption
    {
        private readonly ICommandValidator _commandValidator;
        private readonly IUserInteractionService _userInteractionService;

        public string CommandName => nameof(Command.Move);

        public MoveCommand(ICommandValidator commandValidator, IUserInteractionService userInteractionService)
        {
            _commandValidator = commandValidator;
            _userInteractionService = userInteractionService;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Move;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            if (_userInteractionService.ClearScreenIfToyRobotIsDeactive(toyRobot)) return;

            var moveCommandText = CommandName;

            if (!_commandValidator.IsValid(moveCommandText)) return;

            toyRobot.Move(); // Perform related action on the Toy Robot

            _userInteractionService.PrintCommandExecuted(CommandName);
        }
    }
}