using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class QuitCommand : ICommandOption
    {
        private readonly IUserInteractionService _userInteractionService;

        public QuitCommand(IUserInteractionService userInteractionService)
        {
            _userInteractionService = userInteractionService;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Quit;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            _userInteractionService.Quit = true;
            _userInteractionService.PrintText("\n");
        }
    }
}