using Logic.Clothing;
using Logic.Attributes;

namespace Logic.Rules
{
    public class PantsRule : GettingReadyRuleBase
    {
        public PantsRule()
        {
            forCommands.Add(typeof(PutOnPantsCommand));
        }

        public override bool Evaluate(Person person, WeatherType weatherType)
        {
            return !person.IsWearing(ClothingType.Pants);
        }
    }
}
