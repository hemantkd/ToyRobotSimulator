using System;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.ConsoleTextUI
{
    public class TextCommandControl
    {
        private readonly ICommandTextExecutor _commandTextExecutor;
        private readonly IUserInteractionByTextService _userInteractionByTextService;
        private readonly ToyRobot _toyRobot;

        public TextCommandControl(ICommandTextExecutor commandTextExecutor, IUserInteractionByTextService userInteractionByTextService, ToyRobot toyRobot)
        {
            _commandTextExecutor = commandTextExecutor;
            _userInteractionByTextService = userInteractionByTextService;
            _toyRobot = toyRobot;
        }

        public void Start()
        {
            _userInteractionByTextService.PrintTextCommandsMenu();

            while (!_toyRobot.Deactivate)
            {
                _userInteractionByTextService.PrintText("=>");
                _commandTextExecutor.Execute(commandText: RequestCommandFromUser(), toyRobot: _toyRobot);
            }
        }

        private string RequestCommandFromUser()
        {
            try
            {
                return _userInteractionByTextService.GetTextLine();
            }
            catch (Exception)
            {
                return "Command Unknown"; //Command.Unknown;
            }
        }
    }
}