using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.dataport
{
    public enum XMAS { Preamble = 1, EncryptionWeakness = 2, TestPreamble = 3, TestEncryptionWeakness = 4 }

    public class Attacker : ILogic
    {
        public object GetAnswer(List<string> input, int part)
        {
            var xmas = (XMAS)part;
            var data = input.Select(i => long.Parse(i)).ToList();
            var result = xmas == XMAS.Preamble
                ? GetNotContainedInPreamble(data, 25)
                : xmas == XMAS.TestPreamble
                ? GetNotContainedInPreamble(data, 5)
                : xmas == XMAS.TestEncryptionWeakness
                ? GetWeakness(data, 5)
                : GetWeakness(data, 25);
            return result;
        }

        private long GetWeakness(List<long> data, int preambleSize)
        {
            var searching = true;
            var notContained = GetNotContainedInPreamble(data, preambleSize);
            var firstPosition = 0;
            var lastPosition = 0;
            long count = 0;
            do
            {
                for (int i = firstPosition; i < data.Count; i++)
                {
                    count += data[i];
                    if (count == notContained)
                    {
                        lastPosition = i;
                        searching = false;
                        break;
                    }
                    if (count > notContained)
                    {
                        firstPosition++;
                        count = 0;
                        break;
                    }
                }
            } while (searching);
            var range = data.Skip(firstPosition).Take(lastPosition - firstPosition).ToList();
            return range.Min() + range.Max();
        }

        private long GetNotContainedInPreamble(List<long> data, int preambleSize)
        {
            var contained = true;
            var preamble = data.Take(preambleSize).ToList();
            var additions = GetAdditions(preamble);
            var position = 0;
            long dataPoint = -1;
            do
            {
                if (!additions.Contains(data[preambleSize + position]))
                {
                    dataPoint = data[preambleSize + position];
                    contained = false;
                    continue;
                }
                position++;
                preamble = data.Skip(position).Take(preambleSize).ToList();
                additions = GetAdditions(preamble);
            } while (contained);
            return dataPoint;
        }

        private List<long> GetAdditions(List<long> preamble)
        {
            var additions = new List<long>();
            for (int firstNumber = 0; firstNumber < preamble.Count - 1; firstNumber++)
            {
                for (int secondNumber = 1; secondNumber < preamble.Count; secondNumber++)
                {
                    additions.Add(preamble[firstNumber] + preamble[secondNumber]);
                }
            }
            return additions.Distinct().ToList();
        }
    }
}
