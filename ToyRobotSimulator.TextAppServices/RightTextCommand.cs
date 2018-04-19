using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    internal class RightTextCommand : ICommandTextOption
    {
        private readonly ICommandTextValidator _commandTextValidator;

        public RightTextCommand(ICommandTextValidator commandTextValidator)
        {
            _commandTextValidator = commandTextValidator;
        }

        public bool IsMatch(string commandText)
        {
            return _commandTextValidator.IsRightCommand(commandText);
        }

        public void Execute(string commandText, ToyRobot toyRobot)
        {
            toyRobot.RotateRight();
        }
    }
}