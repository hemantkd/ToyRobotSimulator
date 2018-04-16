using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class MoveCommand : ICommandOption
    {
        private readonly ICommandValidator _commandValidator;
        private readonly IUserInteractionService _userInteractionService;

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

            if (_commandValidator.IsValid(BuildMoveCommandText()))
            {
                toyRobot.Move(); // Perform related action on the Toy Robot

                _userInteractionService.PrintText($"\n{BuildMoveCommandText()} Command Executed!\n");
            }
        }

        private string BuildMoveCommandText()
        {
            return nameof(Command.Move).ToUpperInvariant();
        }
    }
}