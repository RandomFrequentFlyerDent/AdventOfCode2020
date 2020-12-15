using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.game
{
    public class MemoryGame : ILogic
    {
        public object GetAnswer(List<string> input, int part)
        {
            List<long> startingNumbers = input.Select(i => long.Parse(i)).ToList();
            var answer = part == 1
                ? PlayMemoryGame(startingNumbers, 2020)
                : PlayMemoryGame(startingNumbers, 30000000);
            return answer;
        }

        private long PlayMemoryGame(List<long> startingNumbers, int lastSpoken)
        {
            for (int i = startingNumbers.Count - 1; i < lastSpoken - 1; i++)
            {
                var lastNumber = startingNumbers[i];
                var occurences = startingNumbers.Select(s => s == lastNumber);
                if (startingNumbers.Where(s => s == lastNumber).Count() == 1)
                {
                    startingNumbers.Add(0);
                }
                else
                {
                    var last = startingNumbers.LastIndexOf(lastNumber);
                    var secondLast = startingNumbers.SkipLast(startingNumbers.Count - last).ToList().LastIndexOf(lastNumber);
                    startingNumbers.Add((last + 1) - (secondLast + 1));
                }
            }
            return startingNumbers.Last();
        }
    }
}
