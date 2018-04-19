using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class PlaceCommand : ICommandOption
    {
        private readonly IUserInteractionService _userInteractionService;

        public string CommandName => nameof(Command.Place);

        public PlaceCommand(IUserInteractionService userInteractionService)
        {
            _userInteractionService = userInteractionService;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Place;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            int x = _userInteractionService.RequestXCoordinate();
            int y = _userInteractionService.RequestYCoordinate();
            Direction f = _userInteractionService.RequestDirectionFacing();

            toyRobot.SetPosition(x, y, f); // Perform related action on the Toy Robot

            _userInteractionService.PrintCommandExecuted(CommandName);
        }
    }
}