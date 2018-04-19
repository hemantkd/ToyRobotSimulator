namespace ToyRobotSimulator.TextAppInterfaces
{
    public interface IUserInteractionByTextService
    {
        string GetTextLine();

        void PrintText(string text);

        void PrintTextCommandsMenu();
    }
}