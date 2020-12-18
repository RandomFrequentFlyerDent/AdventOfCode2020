using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.train
{
    public class ValidationRules
    {
        private List<ValidationRange> _rules;

        public ValidationRules()
        {
            _rules = new List<ValidationRange>();
        }

        public void AddToRules(string field, int firstRangeStart, int firstRangeEnd, int secondRangeStart, int secondRangeEnd)
        {
            _rules.Add(new ValidationRange(field, firstRangeStart, firstRangeEnd, secondRangeStart, secondRangeEnd));
        }

        public bool IsValidForAnyField(int value)
        {
            return _rules.Any(r => r.IsValid(value));
        }

        public bool IsValid(List<int> ticket)
        {
            return ticket.All(t => _rules.Any(r => r.IsValid(t)));
        }

        public List<string> GetValidFields(List<int> values)
        {
            var validFields = new List<string>();
            var rules = _rules.Where(r => values.All(v => r.IsValid(v))).ToList();
            if (rules != null)
                validFields.AddRange(rules.Select(r => r.Field));
            return validFields;
        }
    }

    class ValidationRange
    {
        public string Field { get; private set; }
        private readonly int _firstStart;
        private readonly int _firstEnd;
        private readonly int _secondStart;
        private readonly int _secondEnd;

        public ValidationRange(string field, int start, int end, int secondStart, int secondEnd)
        {
            Field = field;
            _firstStart = start;
            _firstEnd = end;
            _secondStart = secondStart;
            _secondEnd = secondEnd;
        }

        public bool IsValid(int value)
        {
            return
                (value >= _firstStart && value <= _firstEnd)
                ||
                (value >= _secondStart && value <= _secondEnd);
        }
    }
}
