using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Logic.Attributes.Tests
{
    [TestClass()]
    public class PutOnHeadwearCommand_Test
    {
        [TestMethod()]
        public void Execute_IsCold_ClothingContainsHat_IsTrue()
        {
            Person person = new Person();
            PutOnHeadwearCommand command = new PutOnHeadwearCommand(person, WeatherType.COLD);
            command.Execute();

            bool result = person.Clothing.Any(item => item.Name.Equals("hat"));
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Execute_IsHot_ClothingContainsSunVisor_IsTrue()
        {
            Person person = new Person();
            PutOnHeadwearCommand command = new PutOnHeadwearCommand(person, WeatherType.HOT);
            command.Execute();

            bool result = person.Clothing.Any(item => item.Name.Equals("sun visor"));
            Assert.IsTrue(result);
        }
    }
}