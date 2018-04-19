namespace ToyRobotSimulator.TextAppInterfaces
{
    public interface ICommandTextValidator
    {
        bool IsValid(string commandText);
        bool TryParseXParameter(string xParameter, out int x);
        bool TryParseYParameter(string yParameter, out int y);
        bool IsPlaceCommand(string commandText);
        bool PlaceCommandIsValid(string commandText, out int x, out int y, out Direction f);
        bool IsLeftCommand(string commandText);
        bool IsMoveCommand(string commandText);
        bool IsRightCommand(string commandText);
        bool IsReportCommand(string commandText);
    }
}