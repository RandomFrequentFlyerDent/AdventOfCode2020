﻿using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.train
{
    public class ValidationRule
    {
        public string Field { get; private set; }
        public int Position { get; set; } = -1;
        private readonly int _min1;
        private readonly int _max1;
        private readonly int _min2;
        private readonly int _max2;

        public ValidationRule(string field, string min1, string max1, string min2, string max2)
        {
            Field = field;
            _min1 = int.Parse(min1);
            _max1 = int.Parse(max1);
            _min2 = int.Parse(min2);
            _max2 = int.Parse(max2);
        }

        public bool IsValid(int value)
        {
            return (value >= _min1 && value <= _max1) || (value >= _min2 && value <= _max2);
        }

        public bool IsMatch(List<int> values)
        {
            return values.All(v => IsValid(v));
        }
    }

    public class ValidationRules
    {
        public List<ValidationRule> Rules { get; } = new List<ValidationRule>();
    }

    public class Ticket
    {
        public List<int> Values { get; private set; }

        public Ticket(string values)
        {
            Values = values.Split(',').Select(i => int.Parse(i)).ToList();
        }

        public bool IsValid(ValidationRules rules)
        {
            var valid = true;
            Values.ForEach(v =>
            {
                if (!rules.Rules.Any(r => r.IsValid(v)))
                    valid = false;
            });
            return valid;
        }
    }
}
