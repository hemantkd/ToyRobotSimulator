namespace ToyRobotSimulator.AppInterfaces
{
    public interface IUserInteractionService
    {
        Command GetCommand();

        int RequestXCoordinate();

        int RequestYCoordinate();

        Direction RequestDirectionFacing();

        string GetKeyFromUser();

        void PrintText(string text);

        bool ClearScreenIfToyRobotIsDeactive(ToyRobot toyRobot);
    }
}