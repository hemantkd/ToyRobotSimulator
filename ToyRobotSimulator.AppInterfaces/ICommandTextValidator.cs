namespace ToyRobotSimulator.AppInterfaces
{
    public interface ICommandTextValidator
    {
        bool IsValid(string command);
        bool XParameterIsValid(string xParameter);
        bool YParameterIsValid(string yParameter);
    }
}