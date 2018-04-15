using NUnit.Framework;

namespace ToyRobotSimulator.Tests
{
    [TestFixture]
    public class ReportCommandShould
    {
        [Test]
        public void Return_StateOfTheToyRobot()
        {
            var toyRobot = new ToyRobot(0, 0, Direction.East);

            Assert.That(toyRobot.Report(), Is.EqualTo("Output: 0,0,EAST"));
        }
    }
}