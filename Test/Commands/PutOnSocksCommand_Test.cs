using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Logic.Attributes.Tests
{
    [TestClass()]
    public class PutOnSocksCommand_Test
    {
        [TestMethod()]
        public void Execute_IsCold_ClothingContainsSocks_IsTrue()
        {
            Person person = new Person();
            PutOnSocksCommand command = new PutOnSocksCommand(person, WeatherType.COLD);
            command.Execute();

            bool result = person.Clothing.Any(item => item.Name.Equals("socks"));
            Assert.IsTrue(result);
        }
    }
}