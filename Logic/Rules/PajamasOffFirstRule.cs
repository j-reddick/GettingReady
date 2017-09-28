using Logic.Clothing;
using Logic.Attributes;
using System;

namespace Logic.Rules
{
    public class PajamasOffFirstRule : GettingReadyRuleBase
    {
        public PajamasOffFirstRule()
        {
            forCommands.AddRange(new Type[] { typeof(PutOnFootwearCommand),
                                           typeof(PutOnHeadwearCommand),
                                           typeof(PutOnSocksCommand),
                                           typeof(PutOnShirtCommand),
                                           typeof(PutOnJacketCommand),
                                           typeof(PutOnPantsCommand)
            });
        }

        public override bool Evaluate(Person person, WeatherType weatherType)
        {
            return !person.IsWearing(ClothingType.Pajamas);
        }
    }
}
