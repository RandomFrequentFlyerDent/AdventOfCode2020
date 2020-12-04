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
                return BirthYear != null
                    && IssueYear != null
                    && ExpirationYear != null
                    && Heigth != null
                    && HairColor != null
                    && EyeColor != null
                    && PassportId != null;
            }
        }
    }
}
