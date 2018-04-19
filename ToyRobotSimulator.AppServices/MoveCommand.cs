using ToyRobotSimulator.AppInterfaces;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class MoveCommand : ICommandOption
    {
        private readonly ICommandTextValidator _commandTextValidator;
        private readonly IUserInteractionService _userInteractionService;

        public string CommandName => nameof(Command.Move);

        public MoveCommand(ICommandTextValidator commandTextValidator, IUserInteractionService userInteractionService)
        {
            _commandTextValidator = commandTextValidator;
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

            if (!_commandTextValidator.IsValid(moveCommandText)) return;

            toyRobot.Move(); // Perform related action on the Toy Robot

            _userInteractionService.PrintCommandExecuted(CommandName);
        }
    }
}