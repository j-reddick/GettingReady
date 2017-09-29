using Logic.Attributes;
using System.Collections.Generic;

namespace Logic
{
    public class CommandProcessor
    {
        IEnumerable<IGettingReadyCommand> commands;
        RulesEvaluator rulesEvaluator;

        public CommandProcessor(IEnumerable<IGettingReadyCommand> commands, RulesEvaluator rulesEvaluator)
        {
            this.commands = commands;
            this.rulesEvaluator = rulesEvaluator;
        }

        public string Process()
        {
            List<string> outputs = new List<string>();

            foreach (var command in commands)
            {
                if (rulesEvaluator.CommandPassesRules(command))
                {
                    string output = command.Execute();
                    outputs.Add(output);
                }
                else
                {
                    outputs.Add("fail");
                    break;
                }
            }

            return string.Join(", ", outputs);
        }
    }
}
