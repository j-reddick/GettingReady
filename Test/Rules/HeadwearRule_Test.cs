using Logic.Clothing;
using Logic.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Rules.Tests
{
    [TestClass()]
    public class HeadwearRule_Test
    {
        [TestMethod()]
        public void Evaluate_ShirtNotOn_ReturnsFalse()
        {
            Person person = new Person();
            HeadwearRule rule = new HeadwearRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_ShirtOn_ReturnsTrue()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            HeadwearRule rule = new HeadwearRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Evaluate_HeadwearAlreadyOn_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            person.Clothing.Add(new ClothingItem("", ClothingType.Headwear));
            HeadwearRule rule = new HeadwearRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void AppliesToCommand_PutOnHeadwearCommand_ReturnsTrue()
        {
            HeadwearRule rule = new HeadwearRule();
            bool result = rule.AppliesToCommand(typeof(PutOnHeadwearCommand));
            Assert.IsTrue(result);
        }
    }
}