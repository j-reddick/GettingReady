using Logic.Attributes;
using Logic.Rules;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class RulesEvaluator
    {
        private IEnumerable<IGettingReadyRule> rules;

        public RulesEvaluator(IEnumerable<IGettingReadyRule> rules)
        {
            this.rules = rules;
        }

        public bool CommandPassesRules(IGettingReadyCommand command)
        {
            var rulesForCommand = rules.Where(rule => rule.AppliesToCommand(command));

            foreach (var rule in rulesForCommand)
            {
                if (!rule.Evaluate(command.Person, command.WeatherType))
                {
                    return false; // Return early because it failed to pass a rule
                }
            }

            return true;
        }
    }
}
