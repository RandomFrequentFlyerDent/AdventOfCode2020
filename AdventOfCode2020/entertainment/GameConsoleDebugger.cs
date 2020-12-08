using System.Collections.Generic;

namespace AdventOfCode2020.entertainment
{
    public class GameConsoleDebugger : BaseLogic<DebugMode>
    {
        public static IInstruction[] Instructions { get; private set; }
        public static long Accumulator { get; set; }

        public override object GetAnswer(List<string> input, DebugMode debugMode)
        {
            SetInstructions(input);
            var answer = debugMode == DebugMode.Isolation
                ? DebugInIsolation()
                : 2;
            return answer;
        }

        private long DebugInIsolation()
        {
            var unfinished = true;
            var counter = 0;
            do
            {
                var instruction = Instructions[counter];
                if (instruction.NumberOfTimesProcessed > 0)
                {
                    unfinished = false;
                    continue;
                }
                counter = instruction.Process();
            } while (unfinished);

            return Accumulator;
        }

        private void SetInstructions(List<string> input)
        {
            var instructions = new List<IInstruction>();
            for (int i = 0; i < input.Count; i++)
            {
                instructions.Add(GetInstruction(input[i], i));
            }

            Instructions = instructions.ToArray();
        }

        public IInstruction GetInstruction(string input, int position)
        {
            var operation = input.Substring(0, 3);
            var argument = int.Parse(input.Substring(3));
            return operation switch
            {
                "acc" => new AccumulatorInstruction { Argument = argument, Position = position, NumberOfTimesProcessed = 0 },
                "nop" => new NoOperationInstruction { Argument = argument, Position = position, NumberOfTimesProcessed = 0 },
                "jmp" => new JumpInstruction { Argument = argument, Position = position, NumberOfTimesProcessed = 0 },
                _ => null,
            };
        }
    }
}
