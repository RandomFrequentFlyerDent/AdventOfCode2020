using System.Text.RegularExpressions;

namespace AdventOfCode2020.passport
{
    public class IdentityDocument
    {
        public Registration Registration { get; set; }
        public int? BirthYear
        {
            get
            {
                if (int.TryParse(Registration.BirthYear, out int birthYear)
                    && birthYear >= 1920 && birthYear <= 2002)
                    return birthYear;
                return null;
            }
        }

        public int? IssueYear
        {
            get
            {
                if (int.TryParse(Registration.IssueYear, out int issueYear)
                    && issueYear >= 2010 && issueYear <= 2020)
                    return issueYear;
                return null;
            }
        }

        public int? ExpirationYear
        {
            get
            {
                if (int.TryParse(Registration.ExpirationYear, out int expirationYear)
                    && expirationYear >= 2020 && expirationYear <= 2030)
                    return expirationYear;
                return null;
            }
        }

        public string Heigth
        {
            get
            {
                var cmRegex = new Regex(@"^1([5-8][0-9]|9[0-3])cm$");
                var inRegex = new Regex(@"^(59|6[0-9]|7[0-6])in$");
                var heigth = Registration.Heigth;
                if (heigth != null && (cmRegex.IsMatch(heigth) || inRegex.IsMatch(heigth)))
                    return heigth;
                return null;
            }
        }

        public string HairColor
        {
            get
            {
                var regex = new Regex(@"^#[0-9a-f]{6}$");
                var haircolor = Registration.HairColor;
                if (haircolor != null && regex.IsMatch(haircolor))
                    return haircolor;
                return null;
            }
        }

        public string EyeColor
        {
            get
            {
                var eyecolor = Registration.EyeColor;
                if (eyecolor == "amb" || eyecolor == "blu" || eyecolor == "brn" || eyecolor == "gry"
                    || eyecolor == "grn" || eyecolor == "hzl" || eyecolor == "oth")
                    return eyecolor;
                return null;
            }
        }

        public string PassportId
        {
            get
            {
                if (int.TryParse(Registration.PassportId, out int id) && Registration.PassportId.Length == 9)
                    return Registration.PassportId;
                return null;
            }
        }

        public string CountryId { get { return Registration.CountryId; } }

        public IdentityDocument()
        {
            Registration = new Registration();
        }

        public bool IsPassport
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
