using System.Collections.Generic;
using System.Linq;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly List<ICommandOption> _commandOptions;

        public CommandExecutor(ICommandTextValidator commandTextValidator, IUserInteractionService userInteractionService)
        {
            _commandOptions = new List<ICommandOption>
            {
                new PlaceCommand(commandTextValidator, userInteractionService),
                new LeftCommand(commandTextValidator, userInteractionService),
                new MoveCommand(commandTextValidator, userInteractionService),
                new RightCommand(commandTextValidator, userInteractionService),
                new ReportCommand(commandTextValidator, userInteractionService),
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