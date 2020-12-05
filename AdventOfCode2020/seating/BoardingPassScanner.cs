using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.seating
{
    public class BoardingPassScanner : BaseLogic<BoardingPassActivity>
    {
        public override object GetAnswer(List<string> input, BoardingPassActivity modifier)
        {
            var answer = modifier == BoardingPassActivity.SanityCheck
                ? GetHighestSeatNumber(input)
                : GetSeatNumber(input);
            return answer;
        }

        private int GetHighestSeatNumber(List<string> input)
        {
            var rows = Enumerable.Range(0, 128).ToArray();
            var columns = Enumerable.Range(0, 8).ToArray();
            var seatNumbers = new List<int>();

            input.ForEach(i =>
            {
                var rowNumber = GetRowNumber(i.ToArray(), 0, rows);
                var columnNumber = GetColumnNumber(i.ToArray(), 7, columns);
                seatNumbers.Add(rowNumber * 8 + columnNumber);
            });

            return seatNumbers.Max();
        }

        private int GetSeatNumber(List<string> input)
        {
            var rows = Enumerable.Range(0, 128).ToArray();
            var columns = Enumerable.Range(0, 8).ToArray();

            var countByRow = input.Select(i => GetRowNumber(i.ToArray(), 0, rows)).GroupBy(r => r).ToDictionary(r => r.Key, r => r.Count());
            var openRow = countByRow.Where(d => d.Value == 7).First().Key;
            var countByColumn = input.Select(i => GetColumnNumber(i.ToArray(), 7, columns)).GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
            var openColumn = countByColumn.Aggregate((l, r) => l.Value < r.Value ? l : r).Key; ;

            return openRow * 8 + openColumn;
        }

        private int GetRowNumber(char[] boardingPass, int position, int[] rows)
        {
            if (rows.Length == 1)
                return rows[0];

            var size = rows.Length / 2;
            List<int> newRows = new List<int>();

            if (boardingPass[position] == 'F')
            {
                for (int i = 0; i < size; i++)
                {
                    newRows.Add(rows[i]);
                }
            }
            else
            {
                for (int i = size; i < rows.Length; i++)
                {
                    newRows.Add(rows[i]);
                }
            }

            position++;
            return GetRowNumber(boardingPass, position, newRows.ToArray());
        }

        private int GetColumnNumber(char[] boardingPass, int position, int[] columns)
        {
            if (columns.Length == 1)
                return columns[0];

            var size = columns.Length / 2;
            List<int> newRows = new List<int>();

            if (boardingPass[position] == 'L')
            {
                for (int i = 0; i < size; i++)
                {
                    newRows.Add(columns[i]);
                }
            }
            else
            {
                for (int i = size; i < columns.Length; i++)
                {
                    newRows.Add(columns[i]);
                }
            }

            position++;
            return GetColumnNumber(boardingPass, position, newRows.ToArray());
        }
    }
}
