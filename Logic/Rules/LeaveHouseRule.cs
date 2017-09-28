using Logic.Clothing;
using Logic.Attributes;

namespace Logic.Rules
{
    public class LeaveHouseRule : GettingReadyRuleBase
    {
        public LeaveHouseRule()
        {
            forCommands.Add(typeof(LeaveHouseCommand));
        }

        public override bool Evaluate(Person person, WeatherType weatherType)
        {
            return person.IsWearing(ClothingType.Footwear)
                && person.IsWearing(ClothingType.Pants)
                && person.IsWearing(ClothingType.Shirt)
                && person.IsWearing(ClothingType.Headwear)
                && (weatherType == WeatherType.HOT
                    || person.IsWearing(ClothingType.Socks) && person.IsWearing(ClothingType.Jacket));

        }
    }
}
