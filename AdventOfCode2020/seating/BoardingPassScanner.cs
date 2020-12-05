using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.seating
{
    public class BoardingPassScanner : BaseLogic<BoardingPassActivity>
    {
        private readonly int[] _planeRows = Enumerable.Range(0, 128).ToArray();
        private readonly int[] _planeColumns = Enumerable.Range(0, 8).ToArray();

        public override object GetAnswer(List<string> input, BoardingPassActivity modifier)
        {
            var answer = modifier == BoardingPassActivity.SanityCheck
                ? GetHighestSeatNumber(input)
                : GetSeatNumber(input);
            return answer;
        }

        private int GetHighestSeatNumber(List<string> input)
        {
            var seatNumbers = new List<int>();

            input.ForEach(i =>
            {
                var rowNumber = GetRowOrColumnNumber(i.ToArray(), 0, _planeRows);
                var columnNumber = GetRowOrColumnNumber(i.ToArray(), 7, _planeColumns);
                seatNumbers.Add(rowNumber * 8 + columnNumber);
            });

            return seatNumbers.Max();
        }

        private int GetSeatNumber(List<string> input)
        {
            var freeRow = input.Select(i => GetRowOrColumnNumber(i.ToArray(), 0, _planeRows))
                .GroupBy(r => r).ToDictionary(r => r.Key, r => r.Count())
                .Where(d => d.Value == 7).First().Key;

            var freeColumn = input.Select(i => GetRowOrColumnNumber(i.ToArray(), 7, _planeColumns))
                .GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count())
                .Aggregate((l, r) => l.Value < r.Value ? l : r).Key;

            return freeRow * 8 + freeColumn;
        }

        private int GetRowOrColumnNumber(char[] boardingPass, int position, int[] rows)
        {
            if (rows.Length == 1)
                return rows[0];

            var size = rows.Length / 2;
            int[] subset;

            if (boardingPass[position] == 'F' || boardingPass[position] == 'L')
            {
                subset = rows.Take(size).ToArray();
            }
            else
            {
                subset = rows.Skip(size).Take(size).ToArray();
            }

            position++;
            return GetRowOrColumnNumber(boardingPass, position, subset);
        }
    }
}
