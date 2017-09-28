using Logic.Clothing;
using Logic.Attributes;

namespace Logic.Rules
{
    public class HeadwearRule : GettingReadyRuleBase
    {
        public HeadwearRule()
        {
            forCommands.Add(typeof(PutOnHeadwearCommand));
        }

        public override bool Evaluate(Person person, WeatherType weatherType)
        {
            return person.IsWearing(ClothingType.Shirt) && !person.IsWearing(ClothingType.Headwear);
        }
    }
}