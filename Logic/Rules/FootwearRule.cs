using Logic.Clothing;
using Logic.Attributes;

namespace Logic.Rules
{
    public class FootwearRule : GettingReadyRuleBase
    {
        public FootwearRule()
        {
            forCommands.Add(typeof(PutOnFootwearCommand));
        }

        public override bool Evaluate(Person person, WeatherType weatherType)
        {
            bool needsSocks = weatherType == WeatherType.COLD && !person.IsWearing(ClothingType.Socks);

            return person.IsWearing(ClothingType.Pants)
                && !person.IsWearing(ClothingType.Footwear)
                && !needsSocks;
        }
    }
}
