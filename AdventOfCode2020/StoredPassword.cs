using System.Linq;

namespace AdventOfCode2020
{
    public enum ValidationPolicy { SledRentalPlace, TobogganCorporate }

    public interface IStoredPassword
    {
        string Password { set; }
        int MinFirst { set; }
        int MaxSecond { set; }
        char Validator { set; }
        bool IsValid(ValidationPolicy policy);
    }

    public class StoredPassword : IStoredPassword
    {
        public string Password { private get; set; }
        public int MinFirst { private get; set; }
        public int MaxSecond { private get; set; }
        public char Validator { private get; set; }

        public bool IsValid(ValidationPolicy policy)
        {
            switch (policy)
            {
                case ValidationPolicy.TobogganCorporate:
                    return ((Password[MinFirst - 1] == Validator && Password[MaxSecond - 1] != Validator)
                        || (Password[MinFirst - 1] != Validator && Password[MaxSecond - 1] == Validator));
                case ValidationPolicy.SledRentalPlace:
                    var occurences = Password.Count(c => c == Validator);
                    return occurences >= MinFirst && occurences <= MaxSecond;
                default:
                    return false;
            }
        }
    }
}
