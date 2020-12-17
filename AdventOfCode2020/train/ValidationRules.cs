using System;
using System.Collections.Generic;

namespace AdventOfCode2020.train
{
    public class ValidationRules
    {
        public Dictionary<string, Range[]> Rules { get; }

        public ValidationRules()
        {
            Rules = new Dictionary<string, Range[]>();
        }

        public void AddToRules(string field, int firstRangeStart, int firstRangeEnd, int secondRangeStart, int secondRangeEnd)
        {
            Rules.Add(field, new Range[] { new Range(firstRangeStart, firstRangeEnd), new Range(secondRangeStart, secondRangeEnd) });
        }
    }
}
