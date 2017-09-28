using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Logic.Attributes.Tests
{
    [TestClass()]
    public class PutOnFootwearCommand_Test
    {
        [TestMethod()]
        public void Execute_IsCold_ClothingContainsBoots_IsTrue()
        {
            Person person = new Person();
            PutOnFootwearCommand command = new PutOnFootwearCommand(person, WeatherType.COLD);
            command.Execute();

            bool result = person.Clothing.Any(item => item.Name.Equals("boots"));
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Execute_IsHot_ClothingContainsSandals_IsTrue()
        {
            Person person = new Person();
            PutOnFootwearCommand command = new PutOnFootwearCommand(person, WeatherType.HOT);
            command.Execute();

            bool result = person.Clothing.Any(item => item.Name.Equals("sandals"));
            Assert.IsTrue(result);
        }
    }
}