using System;
using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.ConsoleUI
{
    public class CommandControl
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IUserInteractionService _userInteractionService;
        private readonly ToyRobot _toyRobot;

        public CommandControl(ICommandExecutor commandExecutor, IUserInteractionService userInteractionService, ToyRobot toyRobot)
        {
            _commandExecutor = commandExecutor;
            _userInteractionService = userInteractionService;
            _toyRobot = toyRobot;
        }

        public void Start()
        {
            while (_userInteractionService.Quit == false)
            {
                Command command = RequestCommandFromUser();
                _commandExecutor.Execute(command, _toyRobot);
            }
        }

        private Command RequestCommandFromUser()
        {
            try
            {
                return _userInteractionService.GetCommand();
            }
            catch (Exception)
            {
                return Command.Unknown;
            }
        }
    }
}