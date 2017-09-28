using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Logic.Attributes.Tests
{
    [TestClass()]
    public class PutOnJacketCommand_Test
    {
        [TestMethod()]
        public void Execute_IsCold_ClothingContainsJacket_IsTrue()
        {
            Person person = new Person();
            PutOnJacketCommand command = new PutOnJacketCommand(person, WeatherType.COLD);
            command.Execute();

            bool result = person.Clothing.Any(item => item.Name.Equals("jacket"));
            Assert.IsTrue(result);
        }
    }
}