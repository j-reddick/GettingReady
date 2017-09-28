using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Logic.Attributes.Tests
{
    [TestClass()]
    public class PutOnPantsCommand_Test
    {
        [TestMethod()]
        public void Execute_IsCold_ClothingContainsPants_IsTrue()
        {
            Person person = new Person();
            PutOnPantsCommand command = new PutOnPantsCommand(person, WeatherType.COLD);
            command.Execute();

            bool result = person.Clothing.Any(item => item.Name.Equals("pants"));
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Execute_IsHot_ClothingContainsShorts_IsTrue()
        {
            Person person = new Person();
            PutOnPantsCommand command = new PutOnPantsCommand(person, WeatherType.HOT);
            command.Execute();

            bool result = person.Clothing.Any(item => item.Name.Equals("shorts"));
            Assert.IsTrue(result);
        }
    }
}