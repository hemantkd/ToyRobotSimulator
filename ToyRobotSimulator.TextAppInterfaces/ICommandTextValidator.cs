namespace ToyRobotSimulator.TextAppInterfaces
{
    public interface ICommandTextValidator
    {
        bool TryParseXParameter(string xParameter, out int x);
        bool TryParseYParameter(string yParameter, out int y);
        bool PlaceCommandIsValid(string commandText, out int x, out int y, out Direction f);
    }
}