using Logic.Attributes;
using System;
using System.Collections.Generic;

namespace Logic.Rules
{
    /// <summary>
    /// The base implementation of IGettingReadyRule on which concrete rules should be based.
    /// </summary>
    public abstract class GettingReadyRuleBase : IGettingReadyRule
    {
        protected List<Type> forCommands = new List<Type>();

        public bool AppliesToCommand(IGettingReadyCommand command)
        {
            return AppliesToCommand(command.GetType());
        }

        /// <summary>
        /// Determines whether this rule applies to the passed command type.
        /// </summary>
        /// <param name="commandType">The type on which to check rule applicability.</param>
        /// <returns>The boolean value indicating whether the rule applies to the passed type.</returns>
        public bool AppliesToCommand(Type commandType)
        {
            return forCommands.Contains(commandType);
        }

        public abstract bool Evaluate(Person person, WeatherType weatherType);
    }
}
