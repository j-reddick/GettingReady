using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Logic.Attributes.Tests
{
    [TestClass()]
    public class PutOnShirtCommand_Test
    {
        [TestMethod()]
        public void Execute_IsCold_ClothingContainsShirt_IsTrue()
        {
            Person person = new Person();
            PutOnShirtCommand command = new PutOnShirtCommand(person, WeatherType.COLD);
            command.Execute();

            bool result = person.Clothing.Any(item => item.Name.Equals("shirt"));
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Execute_IsHot_ClothingContainsTShirt_IsTrue()
        {
            Person person = new Person();
            PutOnShirtCommand command = new PutOnShirtCommand(person, WeatherType.HOT);
            command.Execute();

            bool result = person.Clothing.Any(item => item.Name.Equals("t-shirt"));
            Assert.IsTrue(result);
        }
    }
}