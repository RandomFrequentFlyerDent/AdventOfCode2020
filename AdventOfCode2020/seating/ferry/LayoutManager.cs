using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.seating.ferry
{
    public class LayoutManager : BaseLogic<RuleSet>
    {
        private List<SeatingRow> _rows;
        private List<SeatingRow> _dynamicRows;

        public override object GetAnswer(List<string> input, RuleSet ruleSet)
        {
            SetSpaces(input);

            var answer = ruleSet == RuleSet.Simple
                ? GetUnoccupiedSeats().Count
                : 2;
            return answer;
        }

        private List<ISpace> GetUnoccupiedSeats()
        {
            var changes = true;
            do
            {
                changes = PerformRound();
            } while (changes);
            // Draw();
            return _rows.SelectMany(r => r.Spaces).Where(s => s is Seat && ((Seat)s).IsOccupied).ToList();
        }

        public bool PerformRound()
        {
            var changes = false;
            _rows.ForEach(r =>
            {
                var row = new SeatingRow();
                r.Spaces.ForEach(s =>
                {
                    if (s is Seat && s.IsOccupied && BecomesUnoccupied((Seat)s))
                    {
                        row.Spaces.Add(new Seat { Row = s.Row, Space = s.Space, IsOccupied = false });
                        changes = true;
                    }
                    else if (s is Seat && !s.IsOccupied && BecomesOccupied((Seat)s))
                    {
                        row.Spaces.Add(new Seat { Row = s.Row, Space = s.Space, IsOccupied = true });
                        changes = true;
                    }
                    else
                    {
                        // add floor
                        row.Spaces.Add(s);
                    }
                });
                _dynamicRows.Add(row);
            });
            _rows = _dynamicRows;
            _dynamicRows = new List<SeatingRow>();
            return changes;
        }

        public bool BecomesOccupied(Seat seat)
        {
            if (seat.IsOccupied)
                return false;
            return GetAdjacentSpaces(seat).Where(s => s is Seat).All(s => !s.IsOccupied);
        }

        public bool BecomesUnoccupied(Seat seat)
        {
            if (!seat.IsOccupied)
                return false;
            return GetAdjacentSpaces(seat).Where(s => s is Seat && s.IsOccupied).ToList().Count > 3;
        }

        public List<ISpace> GetAdjacentSpaces(Seat seat)
        {
            var spaces = new List<ISpace>();
            if (seat.Row - 1 >= 0)
            {
                spaces.AddRange(new List<ISpace>
                {
                    _rows[seat.Row - 1].Spaces.ElementAtOrDefault(seat.Space - 1),
                    _rows[seat.Row - 1].Spaces.ElementAtOrDefault(seat.Space),
                    _rows[seat.Row - 1].Spaces.ElementAtOrDefault(seat.Space + 1)
                });
            };

            spaces.AddRange(new List<ISpace>
            {
                _rows[seat.Row].Spaces.ElementAtOrDefault(seat.Space - 1),
                _rows[seat.Row].Spaces.ElementAtOrDefault(seat.Space + 1)
            });

            if (seat.Row + 1 < _rows.Count)
            {
                spaces.AddRange(new List<ISpace>
                {
                    _rows[seat.Row + 1].Spaces.ElementAtOrDefault(seat.Space - 1),
                    _rows[seat.Row + 1].Spaces.ElementAtOrDefault(seat.Space),
                    _rows[seat.Row + 1].Spaces.ElementAtOrDefault(seat.Space + 1)
                });
            }
            return spaces;
        }

        private void SetSpaces(List<string> input)
        {
            _dynamicRows = new List<SeatingRow>();
            _rows = new List<SeatingRow>();

            for (int i = 0; i < input.Count; i++)
            {
                var row = new SeatingRow();
                for (int j = 0; j < input[i].Length; j++)
                {
                    var space = input[i][j];
                    if (space == 'L')
                    {
                        row.Spaces.Add(new Seat { Row = i, Space = j });
                        continue;
                    }
                    row.Spaces.Add(new Floor { Row = i, Space = j });
                }
                _rows.Add(row);
            }
        }

        private void Draw()
        {
            _rows.ForEach(r =>
            {
                r.Spaces.ForEach(s =>
                {
                    var space = s is Floor ? '.' : ((Seat)s).IsOccupied ? '#' : 'L';
                    Console.Write($"{space}");
                });
                Console.WriteLine();
            });
        }
    }
}
