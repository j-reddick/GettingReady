using Logic.Clothing;
using Logic.Attributes;

namespace Logic.Rules
{
    public class JacketRule : GettingReadyRuleBase
    {
        public JacketRule()
        {
            forCommands.Add(typeof(PutOnJacketCommand));
        }

        public override bool Evaluate(Person person, WeatherType weatherType)
        {
            return weatherType == WeatherType.COLD
                && person.IsWearing(ClothingType.Shirt)
                && !person.IsWearing(ClothingType.Jacket);
        }
    }
}