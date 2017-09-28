using Logic.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Rules.Tests
{
    [TestClass()]
    public class PajamasOffFirstRule_Test
    {
        [TestMethod()]
        public void Evaluate_PajamasStillOn_ReturnsFalse()
        {
            Person person = new Person();
            PajamasOffFirstRule rule = new PajamasOffFirstRule();
            bool result = rule.Evaluate(person, WeatherType.HOT);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Evaluate_PajamasOff_ReturnsTrue()
        {
            Person person = new Person();
            person.Clothing.Clear();
            PajamasOffFirstRule rule = new PajamasOffFirstRule();
            bool result = rule.Evaluate(person, WeatherType.HOT);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AppliesToCommand_PutOnFootwearCommand_ReturnsTrue()
        {
            PajamasOffFirstRule rule = new PajamasOffFirstRule();
            bool result = rule.AppliesToCommand(typeof(PutOnFootwearCommand));
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AppliesToCommand_PutOnHeadwearCommand_ReturnsTrue()
        {
            PajamasOffFirstRule rule = new PajamasOffFirstRule();
            bool result = rule.AppliesToCommand(typeof(PutOnHeadwearCommand));
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AppliesToCommand_PutOnSocksCommand_ReturnsTrue()
        {
            PajamasOffFirstRule rule = new PajamasOffFirstRule();
            bool result = rule.AppliesToCommand(typeof(PutOnSocksCommand));
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AppliesToCommand_PutOnShirtCommand_ReturnsTrue()
        {
            PajamasOffFirstRule rule = new PajamasOffFirstRule();
            bool result = rule.AppliesToCommand(typeof(PutOnShirtCommand));
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AppliesToCommand_PutOnJacketCommand_ReturnsTrue()
        {
            PajamasOffFirstRule rule = new PajamasOffFirstRule();
            bool result = rule.AppliesToCommand(typeof(PutOnJacketCommand));
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AppliesToCommand_PutOnPantsCommand_ReturnsTrue()
        {
            PajamasOffFirstRule rule = new PajamasOffFirstRule();
            bool result = rule.AppliesToCommand(typeof(PutOnPantsCommand));
            Assert.IsTrue(result);
        }
    }
}