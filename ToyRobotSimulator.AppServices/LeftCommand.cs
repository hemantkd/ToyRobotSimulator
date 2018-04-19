using ToyRobotSimulator.AppInterfaces;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class LeftCommand : ICommandOption
    {
        private readonly ICommandTextValidator _commandTextValidator;
        private readonly IUserInteractionService _userInteractionService;

        public string CommandName => nameof(Command.Left);

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

            var leftCommandText = CommandName;

            if (!_commandTextValidator.IsValid(leftCommandText)) return;

            toyRobot.RotateLeft(); // Perform related action on the Toy Robot

            _userInteractionService.PrintCommandExecuted(CommandName);
        }
    }
}