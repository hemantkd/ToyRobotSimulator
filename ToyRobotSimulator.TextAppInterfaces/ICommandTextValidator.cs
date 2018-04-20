namespace ToyRobotSimulator.TextAppInterfaces
{
    public interface ICommandTextValidator
    {
        bool TryParseXParameter(string xParameter, out int x);
        bool TryParseYParameter(string yParameter, out int y);
    }
}