using System.Collections.Generic;
using System.Linq;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly List<ICommandOption> _commandOptions;

        public CommandExecutor(ICommandValidator commandValidator, IUserInteractionService userInteractionService)
        {
            _commandOptions = new List<ICommandOption>
            {
                new PlaceCommand(commandValidator, userInteractionService),
                new LeftCommand(commandValidator, userInteractionService),
                new MoveCommand(commandValidator, userInteractionService),
                new RightCommand(commandValidator, userInteractionService),
                new ReportCommand(commandValidator, userInteractionService),
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