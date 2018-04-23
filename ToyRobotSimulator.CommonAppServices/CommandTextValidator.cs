using System.Globalization;
using ToyRobotSimulator.CommonAppInterfaces;

namespace ToyRobotSimulator.CommonAppServices
{
    public class CommandTextValidator : ICommandTextValidator
    {
        public bool TryParseXParameter(string xParameter, out int x)
        {
            return
                int.TryParse(xParameter, NumberStyles.Integer, CultureInfo.InvariantCulture, out x);
        }

        public bool TryParseYParameter(string yParameter, out int y)
        {
            return
                int.TryParse(yParameter, NumberStyles.Integer, CultureInfo.InvariantCulture, out y);
        }
    }
}