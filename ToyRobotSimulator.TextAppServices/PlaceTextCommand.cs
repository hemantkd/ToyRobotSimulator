using ToyRobotSimulator.AppInterfaces;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    public class PlaceTextCommand : ICommandTextOption
    {
        private readonly ICommandTextValidator _commandTextValidator;

        public PlaceTextCommand(ICommandTextValidator commandTextValidator)
        {
            _commandTextValidator = commandTextValidator;
        }

        public bool IsMatch(string commandText)
        {
            return _commandTextValidator.IsPlaceCommand(commandText);
        }

        public void Execute(string commandText, ToyRobot toyRobot)
        {
            if (!_commandTextValidator.PlaceCommandIsValid(commandText, out int x, out int y, out Direction f)) return;

            toyRobot.SetPosition(xCoordinate: x, yCoordinate: y, facing: f);
        }
    }
}