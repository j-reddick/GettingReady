using Logic.Clothing;
using Logic.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Rules.Tests
{
    [TestClass()]
    public class JacketRule_Test
    {
        [TestMethod()]
        public void Evaluate_ShirtNotOn_IsCold_ReturnsFalse()
        {
            Person person = new Person();
            JacketRule rule = new JacketRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_ShirtOn_IsCold_ReturnsTrue()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            JacketRule rule = new JacketRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Evaluate_JacketAlreadyOn_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            person.Clothing.Add(new ClothingItem("", ClothingType.Jacket));
            JacketRule rule = new JacketRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_ShirtOn_IsHot_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            JacketRule rule = new JacketRule();
            bool result = rule.Evaluate(person, WeatherType.HOT);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void AppliesToCommand_PutOnJacketCommand_ReturnsTrue()
        {
            JacketRule rule = new JacketRule();
            bool result = rule.AppliesToCommand(typeof(PutOnJacketCommand));
            Assert.IsTrue(result);
        }
    }
}