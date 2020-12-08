﻿using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.entertainment
{
    public class GameConsoleDebugger : BaseLogic<DebugMode>
    {
        private IInstruction[] _instructions;

        public override object GetAnswer(List<string> input, DebugMode debugMode)
        {
            SetInstructions(input);
            var answer = debugMode == DebugMode.Isolation
                ? DebugInIsolation(_instructions, out _)
                : Fix();
            return answer;
        }

        private long DebugInIsolation(IInstruction[] instructions, out bool exited)
        {
            exited = false;
            var unfinished = true;
            int position = 0;
            long accumulator = 0;
            
            do
            {
                var instruction = instructions[position];
                if (instruction.NumberOfTimesProcessed > 0)
                {
                    unfinished = false;
                    continue;
                }
                var result = instruction.Process(accumulator);
                position = result.nextPosition;
                accumulator = result.accumulator;
                if (position >= instructions.Length)
                {
                    unfinished = false;
                    exited = true;
                    continue;
                }
            } while (unfinished);

            return accumulator;
        }

        private long Fix()
        {
            List<int> changePositions = _instructions
                .Where(i => i is NoOperationInstruction || i is JumpInstruction)
                .Select(i => i.Position).ToList();

            long accumulator = 0;
            foreach (var position in changePositions)
            {
                IInstruction[] instructions = _instructions.Select(i => i.GetCleanCopy()).ToArray();
                instructions[position] = instructions[position].GetOppositeInstruction();
                accumulator = DebugInIsolation(instructions, out bool exited);
                if (exited)
                    break;
            }

            return accumulator;
        }

        private void SetInstructions(List<string> input)
        {
            var instructions = new List<IInstruction>();
            for (int i = 0; i < input.Count; i++)
            {
                instructions.Add(GetInstruction(input[i], i));
            }

            _instructions = instructions.ToArray();
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
