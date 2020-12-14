using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.dataport
{
    public class Initializer : ILogic
    {
        public object GetAnswer(List<string> input, int part)
        {
            var answer = part == 1
                ? GetInitializerProgram(input).Count
                : 2;
            return answer;
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
                        initializerProgram.Add(program);
                        program = new BitMaskProgram();
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
