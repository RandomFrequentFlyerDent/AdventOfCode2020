using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.passport
{
    public class Registration
    {
        public string BirthYear { set; get; }
        public string IssueYear { set; get; }
        public string ExpirationYear { set; get; }
        public string Heigth { set; get; }
        public string HairColor { set; get; }
        public string EyeColor { set; get; }
        public string PassportId { set; get; }
        public string CountryId { set; get; }
        public bool IsComplete
        {
            get
            {
                var properties = new List<string> { BirthYear, IssueYear, ExpirationYear, Heigth, HairColor, EyeColor, PassportId };
                return !properties.Any(p => p == null);
            }
        }
    }
}
