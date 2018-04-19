using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    public class MoveTextCommand : ICommandTextOption
    {
        private readonly ICommandTextValidator _commandTextValidator;

        public MoveTextCommand(ICommandTextValidator commandTextValidator)
        {
            _commandTextValidator = commandTextValidator;
        }

        public bool IsMatch(string commandText)
        {
            return _commandTextValidator.IsMoveCommand(commandText);
        }

        public void Execute(string commandText, ToyRobot toyRobot)
        {
            toyRobot.Move();
        }
    }
}