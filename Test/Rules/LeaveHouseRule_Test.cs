using Logic.Clothing;
using Logic.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Rules.Tests
{
    [TestClass()]
    public class LeaveHouseRule_Test
    {
        [TestMethod()]
        public void Evaluate_MissingSocks_IsCold_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            person.Clothing.Add(new ClothingItem("", ClothingType.Footwear));
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            person.Clothing.Add(new ClothingItem("", ClothingType.Jacket));
            person.Clothing.Add(new ClothingItem("", ClothingType.Headwear));

            LeaveHouseRule rule = new LeaveHouseRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_MissingPants_IsCold_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Socks));
            person.Clothing.Add(new ClothingItem("", ClothingType.Footwear));
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            person.Clothing.Add(new ClothingItem("", ClothingType.Jacket));
            person.Clothing.Add(new ClothingItem("", ClothingType.Headwear));

            LeaveHouseRule rule = new LeaveHouseRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_MissingFootwear_IsCold_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Socks));
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            person.Clothing.Add(new ClothingItem("", ClothingType.Jacket));
            person.Clothing.Add(new ClothingItem("", ClothingType.Headwear));

            LeaveHouseRule rule = new LeaveHouseRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_MissingShirt_IsCold_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Socks));
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            person.Clothing.Add(new ClothingItem("", ClothingType.Footwear));
            person.Clothing.Add(new ClothingItem("", ClothingType.Jacket));
            person.Clothing.Add(new ClothingItem("", ClothingType.Headwear));

            LeaveHouseRule rule = new LeaveHouseRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_MissingJacket_IsCold_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Socks));
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            person.Clothing.Add(new ClothingItem("", ClothingType.Footwear));
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            person.Clothing.Add(new ClothingItem("", ClothingType.Headwear));

            LeaveHouseRule rule = new LeaveHouseRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_MissingHeadwear_IsCold_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Socks));
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            person.Clothing.Add(new ClothingItem("", ClothingType.Footwear));
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            person.Clothing.Add(new ClothingItem("", ClothingType.Jacket));

            LeaveHouseRule rule = new LeaveHouseRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_EverythingOn_IsCold_ReturnsTrue()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Socks));
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            person.Clothing.Add(new ClothingItem("", ClothingType.Footwear));
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            person.Clothing.Add(new ClothingItem("", ClothingType.Jacket));
            person.Clothing.Add(new ClothingItem("", ClothingType.Headwear));

            LeaveHouseRule rule = new LeaveHouseRule();
            bool result = rule.Evaluate(person, WeatherType.COLD);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Evaluate_MissingPants_IsHot_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Footwear));
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            person.Clothing.Add(new ClothingItem("", ClothingType.Headwear));

            LeaveHouseRule rule = new LeaveHouseRule();
            bool result = rule.Evaluate(person, WeatherType.HOT);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_MissingFootwear_IsHot_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            person.Clothing.Add(new ClothingItem("", ClothingType.Headwear));

            LeaveHouseRule rule = new LeaveHouseRule();
            bool result = rule.Evaluate(person, WeatherType.HOT);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_MissingShirt_IsHot_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            person.Clothing.Add(new ClothingItem("", ClothingType.Footwear));
            person.Clothing.Add(new ClothingItem("", ClothingType.Headwear));

            LeaveHouseRule rule = new LeaveHouseRule();
            bool result = rule.Evaluate(person, WeatherType.HOT);

            Assert.IsFalse(result);
        }


        [TestMethod()]
        public void Evaluate_MissingHeadwear_IsHot_ReturnsFalse()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            person.Clothing.Add(new ClothingItem("", ClothingType.Footwear));
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));

            LeaveHouseRule rule = new LeaveHouseRule();
            bool result = rule.Evaluate(person, WeatherType.HOT);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_EverythingOn_IsHot_ReturnsTrue()
        {
            Person person = new Person();
            person.Clothing.Add(new ClothingItem("", ClothingType.Pants));
            person.Clothing.Add(new ClothingItem("", ClothingType.Footwear));
            person.Clothing.Add(new ClothingItem("", ClothingType.Shirt));
            person.Clothing.Add(new ClothingItem("", ClothingType.Headwear));

            LeaveHouseRule rule = new LeaveHouseRule();
            bool result = rule.Evaluate(person, WeatherType.HOT);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AppliesToCommand_LeaveHouseCommand_ReturnsTrue()
        {
            LeaveHouseRule rule = new LeaveHouseRule();
            bool result = rule.AppliesToCommand(typeof(LeaveHouseCommand));
            Assert.IsTrue(result);
        }
    }
}