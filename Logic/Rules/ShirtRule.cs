using Logic.Clothing;
using Logic.Attributes;

namespace Logic.Rules
{
    public class ShirtRule : GettingReadyRuleBase
    {
        public ShirtRule()
        {
            forCommands.Add(typeof(PutOnShirtCommand));
        }

        public override bool Evaluate(Person person, WeatherType weatherType)
        {
            return !person.IsWearing(ClothingType.Shirt);
        }
    }
}
