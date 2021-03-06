﻿using System.Collections.Generic;
using System.Linq;
using ToyRobotSimulator.CommonAppInterfaces;
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
                new LeftTextCommand(),
                new MoveTextCommand(),
                new RightTextCommand(),
                new ReportTextCommand(userInteractionByTextService),
                new UnknownTextCommand()
            };
        }

        public void Execute(string commandText, ToyRobot toyRobot)
        {
            _commandTextOptions.First(co => co.IsMatch(commandText)).Execute(commandText, toyRobot);
        }
    }
}