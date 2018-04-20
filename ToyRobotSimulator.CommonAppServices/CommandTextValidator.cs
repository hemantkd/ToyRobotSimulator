using System.Globalization;
using ToyRobotSimulator.TextAppInterfaces;

namespace ToyRobotSimulator.CommonAppServices
{
    public class CommandTextValidator : ICommandTextValidator
    {
        public bool TryParseXParameter(string xParameter, out int x)
        {
            return
                int.TryParse(xParameter, NumberStyles.Integer, CultureInfo.InvariantCulture, out x)
                && IsInTheRange(x);
        }

        public bool TryParseYParameter(string yParameter, out int y)
        {
            return
                int.TryParse(yParameter, NumberStyles.Integer, CultureInfo.InvariantCulture, out y)
                && IsInTheRange(y);
        }

        private bool IsInTheRange(int parameter)
        {
            return parameter >= 0 && parameter <= 5;
        }
    }
}