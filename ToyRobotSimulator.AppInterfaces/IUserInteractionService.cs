namespace ToyRobotSimulator.AppInterfaces
{
    public interface IUserInteractionService
    {
        string GetCommandSelection();
        string GetKeyFromUser();
        void PrintText(string text);
    }
}