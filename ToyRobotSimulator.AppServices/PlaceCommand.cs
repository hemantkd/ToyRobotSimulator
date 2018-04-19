﻿using ToyRobotSimulator.AppInterfaces;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.AppServices
{
    public class PlaceCommand : ICommandOption
    {
        private readonly ICommandTextValidator _commandTextValidator;
        private readonly IUserInteractionService _userInteractionService;

        public string CommandName => nameof(Command.Place);

        public PlaceCommand(ICommandTextValidator commandTextValidator, IUserInteractionService userInteractionService)
        {
            _commandTextValidator = commandTextValidator;
            _userInteractionService = userInteractionService;
        }

        public bool IsMatch(Command command)
        {
            return command == Command.Place;
        }

        public void Execute(Command command, ToyRobot toyRobot)
        {
            int x = _userInteractionService.RequestXCoordinate();
            int y = _userInteractionService.RequestYCoordinate();
            Direction f = _userInteractionService.RequestDirectionFacing();

            var placeCommandText = BuildPlaceCommandTextWithParameters(x, y, f);

            if (!_commandTextValidator.IsValid(placeCommandText)) return;

            toyRobot.SetPosition(x, y, f); // Perform related action on the Toy Robot

            _userInteractionService.PrintCommandExecuted(CommandName);
        }

        private string BuildPlaceCommandTextWithParameters(int x, int y, Direction f)
        {
            return $"{CommandName} {x},{y},{f.ToString().ToUpperInvariant()}";
        }
    }
}