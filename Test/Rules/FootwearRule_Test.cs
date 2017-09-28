using Logic.Clothing;
using Logic.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Rules.Tests
{
    [TestClass()]
    public class FootwearRule_Test
    {
        [TestMethod()]
        public void Evaluate_SocksNotOn_PantsNotOn_IsCold_ReturnsFalse()
        {
            Person person = new Person();
            FootwearRule rule = new FootwearRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_SocksNotOn_PantsOn_IsCold_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            FootwearRule rule = new FootwearRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_SocksOn_PantsNotOn_IsCold_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Socks));
            FootwearRule rule = new FootwearRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_SocksOn_PantsOn_IsCold_ReturnsTrue()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Socks));
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            FootwearRule rule = new FootwearRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Evaluate_FootwearAlreadyOn_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Socks));
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            person.Clothing.Add(new ClothingItem("", ClothingType.Footwear));
            FootwearRule rule = new FootwearRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_SocksNotOn_PantsNotOn_IsHot_ReturnsFalse()
        {
            Person person = new Person();
            FootwearRule rule = new FootwearRule();
            bool result = rule.Evaluate(person, WeatherType.HOT);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_SocksNotOn_PantsOn_IsHot_ReturnsTrue()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            FootwearRule rule = new FootwearRule();
            bool result = rule.Evaluate(person, WeatherType.HOT);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AppliesToCommand_PutOnFootwearCommand_ReturnsTrue()
        {
            FootwearRule rule = new FootwearRule();
            bool result = rule.AppliesToCommand(typeof(PutOnFootwearCommand));
            Assert.IsTrue(result);
        }
    }
}