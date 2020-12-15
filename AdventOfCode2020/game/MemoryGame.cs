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
            Dictionary<long, List<long>> indexesByNumber = new Dictionary<long, List<long>>();
            for (int i = 0; i < startingNumbers.Count; i++)
            {
                indexesByNumber.Add(startingNumbers[i], new List<long> { i + 1 });
            }

            var counter = startingNumbers.Count + 1;
            var lastNumber = startingNumbers.Last();
            do
            {
                var indexed = indexesByNumber[lastNumber];
                if (indexed.Count == 1)
                {
                    if (indexesByNumber.ContainsKey(0))
                    {
                        indexesByNumber[0].Add(counter);
                        if (indexesByNumber[0].Count == 3)
                            indexesByNumber[0].RemoveAt(0);
                    }
                    else
                    {
                        indexesByNumber.Add(0, new List<long> { counter });
                    }
                    lastNumber = 0;
                }
                else
                {
                    var newNumber = indexed[1] - indexed[0];
                    if (indexesByNumber.ContainsKey(newNumber))
                    {
                        indexesByNumber[newNumber].Add(counter);
                        if (indexesByNumber[newNumber].Count == 3)
                            indexesByNumber[newNumber].RemoveAt(0);
                    }
                    else
                    {
                        indexesByNumber.Add(newNumber, new List<long> { counter });
                    }
                    lastNumber = newNumber;
                }
                counter++;
            } while (counter <= lastSpoken);
            return lastNumber;
        }
    }
}
