namespace ToyRobotSimulator.AppInterfaces
{
    public interface ICommandValidator
    {
        bool IsValid(string command);
        bool XParameterIsValid(string xParameter);
        bool YParameterIsValid(string yParameter);
    }
}