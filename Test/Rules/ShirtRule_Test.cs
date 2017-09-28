using Logic.Clothing;
using Logic.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Rules.Tests
{
    [TestClass()]
    public class ShirtRule_Test
    {
        [TestMethod()]
        public void Evaluate_ShirtNotOn_ReturnsTrue()
        {
            Person person = new Person();
            ShirtRule rule = new ShirtRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Evaluate_ShirtAlreadyOn_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            ShirtRule rule = new ShirtRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void AppliesToCommand_PutOnShirtCommand_ReturnsTrue()
        {
            ShirtRule rule = new ShirtRule();
            bool result = rule.AppliesToCommand(typeof(PutOnShirtCommand));
            Assert.IsTrue(result);
        }
    }
}