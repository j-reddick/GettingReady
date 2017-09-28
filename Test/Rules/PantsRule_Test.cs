using Logic.Clothing;
using Logic.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Rules.Tests
{
    [TestClass()]
    public class PantsRule_Test
    {
        [TestMethod()]
        public void Evaluate_PantsNotOn_ReturnsTrue()
        {
            Person person = new Person();
            PantsRule rule = new PantsRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Evaluate_PantsAlreadyOn_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            PantsRule rule = new PantsRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void AppliesToCommand_PutOnPantsCommand_ReturnsTrue()
        {
            PantsRule rule = new PantsRule();
            bool result = rule.AppliesToCommand(typeof(PutOnPantsCommand));
            Assert.IsTrue(result);
        }
    }
}