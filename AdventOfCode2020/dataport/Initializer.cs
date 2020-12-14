using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.dataport
{
    public class Initializer : ILogic
    {
        private long[] _memory = new long[262144];
        private Dictionary<long, long> _memories = new Dictionary<long, long>();

        public object GetAnswer(List<string> input, int part)
        {
            var initializerProgram = GetInitializerProgram(input);

            if (part == 1)
            {
                ReadToMemory(initializerProgram);
                return _memory.Sum();
            }
            else
            {
                ReadToMemoryDecoded(initializerProgram);
                return _memories.Values.Sum();
            }
        }

        private void ReadToMemory(List<BitMaskProgram> programs)
        {
            programs.ForEach(p =>
            {
                var mask = p.Mask;
                p.Bit.ForEach(b =>
                {
                    _memory[b.Key] = ApplyMaskToValue(b.Value, mask);
                });
            });
        }

        private long ApplyMaskToValue(int value, string mask)
        {
            var expand = Convert.ToString(value, 2).PadLeft(36, '0').ToCharArray();
            for (int i = 0; i < mask.Count(); i++)
            {
                char bit = mask[i];
                if (bit != 'X')
                    expand[i] = bit;
            }
            return Convert.ToInt64(new string(expand), 2);
        }

        private void ReadToMemoryDecoded(List<BitMaskProgram> programs)
        {
            programs.ForEach(p =>
            {
                var mask = p.Mask;
                p.Bit.ForEach(b =>
                {
                    var index = ApplyMaskToIndex(b.Key, mask);
                    var indexes = ExpandIndex(new List<string> { index });
                    indexes.ForEach(i =>
                    {
                        var key = Convert.ToInt64(i, 2);
                        if (_memories.ContainsKey(key))
                        {
                            _memories[key] = b.Value;
                        }
                        else
                        {
                            _memories.Add(key, b.Value);
                        }
                    });
                });
            });
        }

        private string ApplyMaskToIndex(int value, string mask)
        {
            var expand = Convert.ToString(value, 2).PadLeft(36, '0').ToCharArray();
            for (int i = 0; i < mask.Count(); i++)
            {
                char bit = mask[i];
                if (bit == 'X')
                    expand[i] = bit;
                if (bit == '1')
                    expand[i] = '1';
            }
            return new string(expand);
        }

        private List<string> ExpandIndex(List<string> indexes)
        {
            if (!indexes.Any(i => i.Contains('X')))
            {
                return indexes;
            }

            var newIndexes = new List<string>();
            indexes.ForEach(i =>
            {
                var last = i.LastIndexOf('X');
                var zero = i.ToCharArray();
                zero[last] = '0';
                newIndexes.Add(new string(zero));
                var one = i.ToCharArray();
                one[last] = '1';
                newIndexes.Add(new string(one));
            });
            return ExpandIndex(newIndexes);
        }

        private List<BitMaskProgram> GetInitializerProgram(List<string> input)
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
