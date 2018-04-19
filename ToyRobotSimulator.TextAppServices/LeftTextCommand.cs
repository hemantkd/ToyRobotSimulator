using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    public class LeftTextCommand : ICommandTextOption
    {
        private readonly ICommandTextValidator _commandTextValidator;

        public LeftTextCommand(ICommandTextValidator commandTextValidator)
        {
            _commandTextValidator = commandTextValidator;
        }

        public bool IsMatch(string commandText)
        {
            return _commandTextValidator.IsLeftCommand(commandText);
        }

        public void Execute(string commandText, ToyRobot toyRobot)
        {
            toyRobot.RotateLeft();
        }
    }
}