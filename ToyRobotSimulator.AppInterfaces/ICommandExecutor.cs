﻿namespace ToyRobotSimulator.AppInterfaces
{
    public interface ICommandExecutor
    {
        void Execute(Command command, ToyRobot toyRobot);
    }
}