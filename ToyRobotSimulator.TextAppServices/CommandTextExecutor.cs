using System.Collections.Generic;
using System.Linq;
using ToyRobotSimulator.AppInterfaces;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.TextAppServices
{
    public class CommandTextExecutor : ICommandTextExecutor
    {
        private readonly List<ICommandTextOption> _commandTextOptions;

        public CommandTextExecutor(ICommandTextValidator commandTextValidator, IUserInteractionByTextService userInteractionByTextService)
        {
            _commandTextOptions = new List<ICommandTextOption>
            {
                new PlaceTextCommand(commandTextValidator),
                new LeftTextCommand(commandTextValidator),
                new MoveTextCommand(commandTextValidator),
                new RightTextCommand(commandTextValidator),
                new ReportTextCommand(commandTextValidator, userInteractionByTextService),
                new UnknownTextCommand()
            };
        }

        public void Execute(string commandText, ToyRobot toyRobot)
        {
            _commandTextOptions.First(co => co.IsMatch(commandText)).Execute(commandText, toyRobot);
        }
    }
}