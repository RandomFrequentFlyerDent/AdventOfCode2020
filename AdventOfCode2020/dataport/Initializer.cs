using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.dataport
{
    public class Initializer : ILogic
    {
        private long[] _memory = new long[262144];

        public object GetAnswer(List<string> input, int part)
        {
            var initializerProgram = GetInitializerProgram(input);
            ReadToMemory(initializerProgram);

            var answer = part == 1
                ? _memory.Sum()
                : 2;
            return answer;
        }

        public void ReadToMemory(List<BitMaskProgram> programs)
        {
            programs.ForEach(p =>
            {
                var mask = p.Mask;
                p.Bit.ForEach(b =>
                {
                    var expand = Convert.ToString(b.Value, 2).PadLeft(36, '0').ToCharArray();
                    for (int i = 0; i < mask.Count(); i++)
                    {
                        char bit = mask[i];
                        if (bit != 'X')
                            expand[i] = bit;
                    }
                    var value = Convert.ToInt64(new string(expand), 2);
                    _memory[b.Key] = value;
                });
            });
        }

        public List<BitMaskProgram> GetInitializerProgram(List<string> input)
        {
            var initializerProgram = new List<BitMaskProgram>();
            var program = new BitMaskProgram();
            initializerProgram.Add(program);
            Regex regex = new Regex(@"^mem\[(?<memory>\d+)\] = (?<value>\d+)");

            for (int i = 0; i < input.Count; i++)
            {
                var line = input[i];
                if (line.StartsWith("mask = "))
                {
                    if (program.Mask != null)
                    {
                        program = new BitMaskProgram();
                        initializerProgram.Add(program);
                    }
                    program.Mask = line.Substring(7);
                }
                else
                {
                    Match match = regex.Matches(line)[0];
                    program.Bit.Add(new KeyValuePair<int, int>(int.Parse(match.Groups["memory"].Value), int.Parse(match.Groups["value"].Value)));
                }
            }
            return initializerProgram;
        }
    }
}
