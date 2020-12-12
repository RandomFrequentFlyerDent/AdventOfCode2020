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
            return GetUnoccupiedSeats(ruleSet).Count;
        }

        private List<ISpace> GetUnoccupiedSeats(RuleSet ruleSet)
        {
            var changes = true;
            do
            {
                changes = PerformRound(ruleSet);
            } while (changes);
            return _rows.SelectMany(r => r.Spaces).Where(s => s is Seat && ((Seat)s).IsOccupied).ToList();
        }

        public bool PerformRound(RuleSet ruleSet)
        {
            var changes = false;
            _rows.ForEach(r =>
            {
                var row = new SeatingRow();
                r.Spaces.ForEach(s =>
                {
                    if (s is Seat && s.IsOccupied && BecomesUnoccupied(ruleSet, (Seat)s))
                    {
                        row.Spaces.Add(new Seat { Row = s.Row, Space = s.Space, IsOccupied = false });
                        changes = true;
                    }
                    else if (s is Seat && !s.IsOccupied && BecomesOccupied(ruleSet, (Seat)s))
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

        public bool BecomesOccupied(RuleSet ruleSet, Seat seat)
        {
            if (seat.IsOccupied)
                return false;
            return GetAdjacentSpaces(ruleSet, seat).Where(s => s is Seat).All(s => !s.IsOccupied);
        }

        public bool BecomesUnoccupied(RuleSet ruleSet, Seat seat)
        {
            if (!seat.IsOccupied)
                return false;
            var occupiedSeats = ruleSet == RuleSet.Simple ? 4 : 5;
            return GetAdjacentSpaces(ruleSet, seat).Where(s => s is Seat && s.IsOccupied).ToList().Count >= occupiedSeats;
        }

        public List<ISpace> GetAdjacentSpaces(RuleSet ruleSet, Seat seat)
        {
            var spaces = new List<ISpace>();
            var directions = (ViewingDirection[])Enum.GetValues(typeof(ViewingDirection));
            directions.ToList().ForEach(d =>
            {
                spaces.Add(View(ruleSet, seat, 1, d));
            });

            return spaces;
        }

        public ISpace View(RuleSet ruleSet, Seat seat, int position, ViewingDirection direction)
        {
            if (position < 0 || position >= _rows.Count)
                return null;
            var space = GetSpace(seat, position, direction);
            if (ruleSet == RuleSet.Simple)
                return space;
            if (space is Seat)
                return space;
            
            position++;
            return View(ruleSet, seat, position, direction);
        }

        public ISpace GetSpace(Seat seat, int position, ViewingDirection direction)
        {
            var aboveRow = seat.Row - position;
            var belowRow = seat.Row + position;
            ISpace space = null;

            switch (direction)
            {
                case ViewingDirection.Up: 
                    space = aboveRow < 0 ? null : _rows[seat.Row - position].Spaces.ElementAtOrDefault(seat.Space);
                    break;
                case ViewingDirection.UpLeft:
                    space = aboveRow < 0 ? null : _rows[seat.Row - position].Spaces.ElementAtOrDefault(seat.Space - position);
                    break;
                case ViewingDirection.UpRight:
                    space = aboveRow < 0 ? null : _rows[seat.Row - position].Spaces.ElementAtOrDefault(seat.Space + position);
                    break;
                case ViewingDirection.Left:
                    space = _rows[seat.Row].Spaces.ElementAtOrDefault(seat.Space - position);
                    break;
                case ViewingDirection.Right:
                    space = _rows[seat.Row].Spaces.ElementAtOrDefault(seat.Space + position);
                    break;
                case ViewingDirection.Bottom:
                    space = belowRow >= _rows.Count ? null : _rows[seat.Row + position].Spaces.ElementAtOrDefault(seat.Space);
                    break;
                case ViewingDirection.BottomLeft:
                    space = belowRow >= _rows.Count ? null : _rows[seat.Row + position].Spaces.ElementAtOrDefault(seat.Space - position);
                    break;
                case ViewingDirection.BottomRight:
                    space = belowRow >= _rows.Count ? null : _rows[seat.Row + position].Spaces.ElementAtOrDefault(seat.Space + position);
                    break;
                default:
                    break;
            }

            return space;
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
    }
}
