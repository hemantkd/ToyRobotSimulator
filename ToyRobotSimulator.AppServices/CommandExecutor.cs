using System.Collections.Generic;
using System.Linq;
using ToyRobotSimulator.AppInterfaces;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly List<ICommandOption> _commandOptions;

        public CommandExecutor(ICommandTextValidator commandTextValidator, IUserInteractionService userInteractionService)
        {
            _commandOptions = new List<ICommandOption>
            {
                new PlaceCommand(userInteractionService),
                new LeftCommand(userInteractionService),
                new MoveCommand(commandTextValidator, userInteractionService),
                new RightCommand(userInteractionService),
                new ReportCommand(userInteractionService),
                new QuitCommand(userInteractionService),
                new UnknownCommand(userInteractionService)
            };
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            _commandOptions.First(co => co.IsMatch(command)).Execute(command, toyRobot);
        }
    }
}