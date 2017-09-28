using Logic.Clothing;
using Logic.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Rules.Tests
{
    [TestClass()]
    public class SocksRule_Test
    {
        [TestMethod()]
        public void Evaluate_SocksNotOn_IsCold_ReturnsTrue()
        {
            Person person = new Person();
            SocksRule rule = new SocksRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Evaluate_SocksOn_IsCold_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Socks));
            SocksRule rule = new SocksRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_SocksNotOn_IsHot_ReturnsFalse()
        {
            Person person = new Person();
            SocksRule rule = new SocksRule();
            bool result = rule.Evaluate(person, WeatherType.HOT);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void AppliesToCommand_PutOnSocksCommand_ReturnsTrue()
        {
            SocksRule rule = new SocksRule();
            bool result = rule.AppliesToCommand(typeof(PutOnSocksCommand));
            Assert.IsTrue(result);
        }
    }
}