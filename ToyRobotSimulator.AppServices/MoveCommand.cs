﻿using ToyRobotSimulator.AppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class MoveCommand : ICommandOption
    {
        private readonly IUserInteractionService _userInteractionService;

        public MoveCommand(IUserInteractionService userInteractionService)
        {
            _userInteractionService = userInteractionService;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Move;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            if (_userInteractionService.ClearScreenIfToyRobotIsDeactive(toyRobot)) return;

            toyRobot.Move(); // Perform related action on the Toy Robot

            _userInteractionService.PrintCommandExecuted(nameof(Command.Move));
        }
    }
}