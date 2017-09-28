using Logic;
using Logic.Attributes;
using Logic.Factories;
using Logic.Repositories;
using Logic.Rules;
using System;
using System.Collections.Generic;

namespace UI
{
    class Program
    {
        private static CommandFactory factory;
        private static RulesRepository rulesRepository;

        static void Main(string[] args)
        {
            factory = new CommandFactory();
            rulesRepository = new RulesRepository();
            Console.WriteLine("This is the getting ready app. Please enter a weather type and a list of commands.");
            Console.WriteLine("If you need help, enter \"help\", if you are finished, enter \"exit\"\n");

            string input;
            while ((input = Console.ReadLine()).ToLower() != "exit")
            {
                RunProgram(input);
            }
        }

        private static void RunProgram(string input)
        {
            try
            {
                if (input.ToLower() == "help")
                {
                    PrintInstructions();
                    return;
                }

                WeatherType weatherType = GetWeatherTypeFromInputString(input);

                Person person = new Person();

                List<IGettingReadyCommand> commands = ParseCommands(input, person, weatherType);
                IEnumerable<IGettingReadyRule> rules = rulesRepository.GetRules();

                // Compose the rules evaluator to run through all rules for our commands
                RulesEvaluator evaluator = new RulesEvaluator(rules, person, weatherType);

                // Compose the command processor by giving it our commands and the rules evaluator to use
                // for processing the rules on each command
                CommandProcessor commandProcessor = new CommandProcessor(commands, evaluator);

                string output = commandProcessor.Process();
                Console.WriteLine($"\n{output}\n");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("\nPlease enter a weather type and a list of commands from the following instructions.");
            Console.WriteLine("\nWeather types:");
            foreach (string weatherTypeName in Enum.GetNames(typeof(WeatherType)))
            {
                Console.WriteLine(weatherTypeName);
            }
            Console.WriteLine();
            Console.WriteLine("Available commands:");
            Console.WriteLine(factory.GetAvailableCommandList());
            Console.WriteLine("Example input: HOT 8, 6, 4, 2, 1, 7\n");
        }

        private static WeatherType GetWeatherTypeFromInputString(string input)
        {
            int spaceIndex = input.IndexOf(' ');
            if (spaceIndex > 0)
            {
                string weatherTypeString = input.Substring(0, spaceIndex).Trim();
                WeatherType weatherType = (WeatherType)Enum.Parse(typeof(WeatherType), weatherTypeString.ToUpper());
                return weatherType;
            }
            throw new ArgumentException("\nInvalid command. Please try again.\n");
        }

        private static List<IGettingReadyCommand> ParseCommands(string input, Person person, WeatherType weatherType)
        {
            try
            {
                string[] commandStrings = input.Substring(input.IndexOf(' ')).Split(',');

                List<int> commandIds = new List<int>();

                foreach (var s in commandStrings)
                {
                    commandIds.Add(int.Parse(s.Trim()));
                }

                List<IGettingReadyCommand> commands = new List<IGettingReadyCommand>();
                foreach (var commandId in commandIds)
                {
                    commands.Add(factory.CreateCommand(commandId, person, weatherType));
                }

                return commands;
            }
            catch
            {
                throw new ArgumentException("\nInvalid command. Please try again.\n");
            }
        }
    }
}
