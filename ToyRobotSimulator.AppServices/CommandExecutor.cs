using System.Collections.Generic;
using System.Linq;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly List<ICommandOption> _commandOptions;

        public CommandExecutor(ICommandValidator commandValidator)
        {
            _commandOptions = new List<ICommandOption>
            {
                new PlaceCommand(commandValidator),
                new LeftCommand(commandValidator),
                new MoveCommand(commandValidator),
                new RightCommand(commandValidator),
                new ReportCommand(commandValidator),
                new QuitCommand(),
                new UnknownCommand()
            };
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            _commandOptions.First(co => co.IsMatch(command)).Execute(command, toyRobot);

        }
    }
}