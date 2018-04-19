using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class LeftCommand : ICommandOption
    {
        private readonly IUserInteractionService _userInteractionService;

        public LeftCommand(IUserInteractionService userInteractionService)
        {
            _userInteractionService = userInteractionService;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Left;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            if (_userInteractionService.ClearScreenIfToyRobotIsDeactive(toyRobot)) return;

            toyRobot.RotateLeft(); // Perform related action on the Toy Robot

            _userInteractionService.PrintCommandExecuted(commandName: nameof(Command.Left));
        }
    }
}