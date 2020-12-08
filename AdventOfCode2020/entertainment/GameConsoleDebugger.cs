using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.entertainment
{
    public class GameConsoleDebugger : BaseLogic<DebugMode>
    {
        public override object GetAnswer(List<string> input, DebugMode debugMode)
        {
            var answer = debugMode == DebugMode.Isolation
                ? GetInstructions(input).Count
                : 2;
            return answer;
        }

        private List<IInstruction> GetInstructions(List<string> input)
        {
            return input.Select(i => GetInstruction(i)).ToList();
        }

        public IInstruction GetInstruction(string input)
        {
            var operation = input.Substring(0, 3);
            var argument = int.Parse(input.Substring(3));
            switch (operation)
            {
                case "acc": return new AccumulatorInstruction { Argument = argument };
                case "nop": return new NoOperationInstruction { Argument = argument };
                case "jmp": return new JumpInstruction { Argument = argument };
                default:
                    return null;
            }
        }
    }
}
