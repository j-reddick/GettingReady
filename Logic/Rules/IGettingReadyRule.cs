using Logic.Attributes;

namespace Logic.Rules
{
    public interface IGettingReadyRule
    {
        /// <summary>
        /// Evaluates the rule's criteria on the passed Person using
        /// the passed WeatherType for any decisions that depend on
        /// the weather.
        /// </summary>
        /// <param name="person">The Person instance on which to evaluate the rule.</param>
        /// <param name="weatherType">The WeatherType used to make any weather dependent decisions.</param>
        /// <returns></returns>
        bool Evaluate(Person person, WeatherType weatherType);

        /// <summary>
        /// Determines whether this rule applies to the passed command.
        /// </summary>
        /// <param name="command">The command on which to check rule applicability.</param>
        /// <returns>The boolean value indicating whether the rule applies to the passed command.</returns>
        bool AppliesToCommand(IGettingReadyCommand command);
    }
}
