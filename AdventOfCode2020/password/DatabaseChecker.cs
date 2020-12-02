using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.password
{
    public class DatabaseChecker : BaseLogic<ValidationPolicy>
    {
        public override object GetAnswer(List<string> input, ValidationPolicy policy)
        {
            return input
                .Select(i => GetStoredPassword(i))
                .Where(p => p.IsValid(policy))
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
