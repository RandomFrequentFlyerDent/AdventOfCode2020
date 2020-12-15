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
            Dictionary<long, List<long>> turnsByNumber = GetTurnsByNumber(startingNumbers);

            var counter = startingNumbers.Count + 1;
            var lastNumber = startingNumbers.Last();
            do
            {
                var turns = turnsByNumber[lastNumber];
                if (turns.Count == 1)
                {
                    AddToTurnsByNumber(turnsByNumber, counter, 0);
                    lastNumber = 0;
                }
                else
                {
                    var number = turns[1] - turns[0];
                    AddToTurnsByNumber(turnsByNumber, counter, number);
                    lastNumber = number;
                }
                counter++;
            } while (counter <= lastSpoken);
            return lastNumber;
        }

        private void AddToTurnsByNumber(Dictionary<long, List<long>> turnsByNumber, int counter, long number)
        {
            if (turnsByNumber.ContainsKey(number))
            {
                turnsByNumber[number].Add(counter);
                if (turnsByNumber[number].Count == 3)
                    turnsByNumber[number].RemoveAt(0);
            }
            else
            {
                turnsByNumber.Add(number, new List<long> { counter });
            }
        }

        private Dictionary<long, List<long>> GetTurnsByNumber(List<long> startingNumbers)
        {
            Dictionary<long, List<long>> indexesByNumber = new Dictionary<long, List<long>>();
            for (int i = 0; i < startingNumbers.Count; i++)
            {
                indexesByNumber.Add(startingNumbers[i], new List<long> { i + 1 });
            }

            return indexesByNumber;
        }
    }
}
