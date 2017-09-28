using Logic.Clothing;
using Logic.Attributes;

namespace Logic.Rules
{
    public class SocksRule : GettingReadyRuleBase
    {
        public SocksRule()
        {
            forCommands.Add(typeof(PutOnSocksCommand));
        }

        public override bool Evaluate(Person person, WeatherType weatherType)
        {
            return weatherType == WeatherType.COLD && !person.IsWearing(ClothingType.Socks);
        }
    }
}
