using Logic.Rules;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Logic.Repositories
{
    /// <summary>
    /// This implementation uses reflection on the executing assembly to locate
    /// all concrete implementations of IGettingReadyRule and activate and instance
    /// of each rule that is found.
    /// </summary>
    public class RulesRepository
    {
        /// <summary>
        /// Gets an IEnumerable<IGettingReadyRule> representing all rules in the system.
        /// </summary>
        /// <returns>IEnumerable<IGettingReadyRule> containing all rules in the system.</returns>
        public IEnumerable<IGettingReadyRule> GetRules()
        {
            List<IGettingReadyRule> rules = new List<IGettingReadyRule>();

            Type[] typesInAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInAssembly)
            {
                if (type.GetInterface("IGettingReadyRule") != null && !type.IsAbstract)
                {
                    rules.Add(Activator.CreateInstance(type) as IGettingReadyRule);
                }
            }

            return rules;
        }
    }
}
