using System;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.ConsoleTextUI
{
    public class TextCommandControl
    {
        private readonly ICommandTextExecutor _commandTextExecutor;
        private readonly IUserInteractionByTextService _userInteractionByTextService;
        private readonly ToyRobot _toyRobot;

        public TextCommandControl(
            ICommandTextExecutor commandTextExecutor,
            IUserInteractionByTextService userInteractionByTextService,
            ToyRobot toyRobot
        )
        {
            _commandTextExecutor = commandTextExecutor;
            _userInteractionByTextService = userInteractionByTextService;
            _toyRobot = toyRobot;
        }

        public void Start()
        {
            _userInteractionByTextService.PrintTextCommandsMenu();

            while (true)
            {
                _userInteractionByTextService.PrintText("=>");

                try
                {
                    _commandTextExecutor.Execute(commandText: _userInteractionByTextService.GetTextLine(), toyRobot: _toyRobot);
                }
                catch (NullReferenceException)
                {
                    // ignored
                }
            }
        }
    }
}