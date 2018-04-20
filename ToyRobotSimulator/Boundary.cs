namespace ToyRobotSimulator
{
    public class Boundary
    {
        public const int XMin = 0, YMin = 0, XMax = 5, YMax = 5;

        public bool XCoordinateIsInRange(int parameter)
        {
            return parameter >= XMin && parameter <= XMax;
        }

        public bool YCoordinateIsInRange(int parameter)
        {
            return parameter >= YMin && parameter <= YMax;
        }
    }
}