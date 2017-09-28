using Logic.Clothing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Attributes.Tests
{
    [TestClass()]
    public class RemovePajamasCommand_Test
    {
        [TestMethod()]
        public void Execute_IsWearingPajamas_Is()
        {
            Person person = new Person();
            RemovePajamasCommand command = new RemovePajamasCommand(person, WeatherType.COLD);
            command.Execute();

            bool result = person.IsWearing(ClothingType.Pajamas);
            Assert.IsFalse(result);
        }
    }
}