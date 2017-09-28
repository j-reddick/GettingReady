using Logic.Attributes;
using Logic.Rules;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class RulesEvaluator
    {
        private IEnumerable<IGettingReadyRule> rules;
        Person person;
        WeatherType weatherType;

        public RulesEvaluator(IEnumerable<IGettingReadyRule> rules, Person person, WeatherType weatherType)
        {
            this.rules = rules;
            this.person = person;
            this.weatherType = weatherType;
        }

        public bool CommandPassesRules(IGettingReadyCommand command)
        {
            var rulesForCommand = rules.Where(rule => rule.AppliesToCommand(command));

            foreach (var rule in rulesForCommand)
            {
                if (!rule.Evaluate(person, weatherType))
                {
                    return false; // Return early because it failed to pass a rule
                }
            }

            return true;
        }
    }
}
