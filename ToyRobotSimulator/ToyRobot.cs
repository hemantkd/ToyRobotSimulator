﻿namespace ToyRobotSimulator
{
    public class ToyRobot
    {
        private const int XMin = 0, YMin = 0, XMax = 5, YMax = 5;

        public ToyRobot(int xCoordinate, int yCoordinate, Direction facing)
        {
            Position = new Position(xCoordinate, yCoordinate, facing);
        }

        public ToyRobot()
        { }

        public Position Position { get; set; }

        public void SetPosition(int xCoordinate, int yCoordinate, Direction facing)
        {
            Position = new Position(xCoordinate, yCoordinate, facing);
        }

        public void Move()
        {
            switch (Position.Facing)
            {
                case Direction.East: if(IsNotOnEasternBoundary()) Position.XCoordinate++;
                    break;
                case Direction.West: if(IsNotOnWesternBoundary()) Position.XCoordinate--;
                    break;
                case Direction.North: if(IsNotOnNorthernBoundary()) Position.YCoordinate++;
                    break;
                case Direction.South: if(IsNotOnSouthernBoundary()) Position.YCoordinate--;
                    break;
            }
        }

        public void RotateLeft()
        {
            Position.Facing = Position.Facing.RotateLeft();
        }

        public void RotateRight()
        {
            Position.Facing = Position.Facing.RotateRight();
        }

        private bool IsNotOnSouthernBoundary()
        {
            return Position.YCoordinate != YMin;
        }

        private bool IsNotOnNorthernBoundary()
        {
            return Position.YCoordinate != YMax;
        }

        private bool IsNotOnWesternBoundary()
        {
            return Position.XCoordinate != XMin;
        }

        private bool IsNotOnEasternBoundary()
        {
            return Position.XCoordinate != XMax;
        }

        public string Report()
        {
            return $"Output: {Position.XCoordinate},{Position.YCoordinate},{$"{Position.Facing}".ToUpperInvariant()}";
        }
    }
}