using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class RightCommand : ICommandOption
    {
        private readonly IUserInteractionService _userInteractionService;

        public RightCommand(IUserInteractionService userInteractionService)
        {
            _userInteractionService = userInteractionService;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Right;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            if (_userInteractionService.ClearScreenIfToyRobotIsDeactive(toyRobot)) return;

            toyRobot.RotateRight(); // Perform related action on the Toy Robot

            _userInteractionService.PrintCommandExecuted(commandName: nameof(Command.Report));
        }
    }
}