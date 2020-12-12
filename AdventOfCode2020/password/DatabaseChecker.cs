using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.password
{
    public enum ValidationPolicy { SledRentalPlace = 1, TobogganCorporate = 2 }

    public class DatabaseChecker : ILogic
    {
        public object GetAnswer(List<string> input, int part)
        {
            return input
                .Select(i => GetStoredPassword(i))
                .Where(p => p.IsValid((ValidationPolicy)part))
                .ToList().Count();
        }

        private IStoredPassword GetStoredPassword(string input)
        {
            var parts = input.Split(new char[] { '-', ' ', ':' }, System.StringSplitOptions.RemoveEmptyEntries);
            return new StoredPassword
            {
                MinFirst = int.Parse(parts[0]),
                MaxSecond = int.Parse(parts[1]),
                Validator = parts[2][0],
                Password = parts[3]
            };
        }
    }
}
