using Logic.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Logic.Factories
{
    public class CommandFactory
    {
        /// <summary>
        /// A dictionary containing an integer key to lookup some metadata 
        /// about each contained IGettingReadyCommand
        /// </summary>
        public Dictionary<int, CommandAttributes> CommandLookup { get; private set; } = new Dictionary<int, CommandAttributes>();

        public CommandFactory()
        {
            LoadAvailableCommands();
        }

        /// <summary>
        /// Returns a string value repesenting the id and descrption of all
        /// available commands in the system, separated onto individual lines
        /// </summary>
        /// <returns>The string value describing the available commands in the system.</returns>
        public string GetAvailableCommandList()
        {
            if (CommandLookup == null)
            {
                LoadAvailableCommands();
            }

            StringBuilder output = new StringBuilder();

            foreach (var commandKeyValuePair in CommandLookup.OrderBy(item => item.Key))
            {
                output.AppendLine($"{commandKeyValuePair.Key}: \t {commandKeyValuePair.Value.Description}");
            }

            return output.ToString();
        }

        /// <summary>
        /// Uses reflection on the executing assembly to find all implementations of IGettingReadyCommand and 
        /// creates a Dictionary for looking up a command specified by integer id.
        /// </summary>
        private void LoadAvailableCommands()
        {
            Type[] typesInAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInAssembly)
            {
                if (type.GetInterface("IGettingReadyCommand") != null)
                {
                    CommandAttributes attributes = type.GetCustomAttribute(typeof(CommandAttributes)) as CommandAttributes;
                    CommandLookup.Add(attributes.Id, attributes);
                }
            }
        }


        /// <summary>
        /// Creates a command using the integer id, the Person instance on which to execute, and 
        /// the WeatherType used to make weather based decisions.
        /// </summary>
        /// <param name="id">The id of the command to create.</param>
        /// <param name="person">The Person instance on which to execute the command.</param>
        /// <param name="weatherType">The WeatherType used to make weather based decisions.</param>
        /// <returns>An instance of the requested concrete IGettingReadyCommand, or null if the requested type is not found.</returns>
        public IGettingReadyCommand CreateCommand(int id, Person person, WeatherType weatherType)
        {
            if (CommandLookup.ContainsKey(id))
            {
                return Activator.CreateInstance(CommandLookup[id].Type, person, weatherType) as IGettingReadyCommand;
            }
            return null;
        }
    }
}
