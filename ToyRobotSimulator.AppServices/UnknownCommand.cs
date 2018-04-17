using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class UnknownCommand : ICommandOption
    {
        private readonly IUserInteractionService _userInteractionService;

        public UnknownCommand(IUserInteractionService userInteractionService)
        {
            _userInteractionService = userInteractionService;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Unknown;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            _userInteractionService.PrintInvalidSelection();
        }
    }
}