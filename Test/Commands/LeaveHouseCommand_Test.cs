using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Attributes.Tests
{
    [TestClass()]
    public class LeaveHouseCommand_Test
    {
        [TestMethod()]
        public void Execute_PersonStatus_EqualsLeftHouse()
        {
            Person person = new Person();
            LeaveHouseCommand leaveHouseCommand = new LeaveHouseCommand(person, WeatherType.COLD);
            leaveHouseCommand.Execute();

            Assert.AreEqual(person.Status, "Left house");
        }
    }
}