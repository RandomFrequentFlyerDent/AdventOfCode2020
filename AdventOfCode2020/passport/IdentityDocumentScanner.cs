﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.passport
{
    public class IdentityDocumentScanner : BaseLogic<ScanType>
    {
        public override object GetAnswer(List<string> input, ScanType modifier)
        {
            var result = modifier == ScanType.Registered
                ? GetIdentityDocuments(input).Where(id => id.Registration.IsComplete).Count()
                : GetIdentityDocuments(input).Where(id => id.IsPassport).Count();
            return result;
        }

        private List<IdentityDocument> GetIdentityDocuments(List<string> input)
        {
            return GetCollatedInput(input)
                .Select(ci => GetMatchesByVariable(ci))
                .Select(mbv => RegisterDocument(mbv))
                .ToList();
        }

        private static List<string> GetCollatedInput(List<string> input)
        {
            var collatedInput = new List<string>();
            var sb = new StringBuilder();
            
            for (int i = 0; i < input.Count; i++)
            {
                var line = input[i];
                if (string.IsNullOrEmpty(line))
                {
                    var collatedLine = sb.ToString();
                    if (!string.IsNullOrEmpty(collatedLine))
                        collatedInput.Add(collatedLine);
                    sb.Clear();
                    continue;
                }

                sb.Append(" " + line);

                if (i + 1 == input.Count)
                {
                    collatedInput.Add(sb.ToString());
                    continue;
                }
            }

            return collatedInput;
        }

        private Dictionary<string, string> GetMatchesByVariable(string line)
        {
            Regex regex = new Regex(@"\b(?<variable>\w+):(#?\w+)(\b|$)");
            MatchCollection matches = regex.Matches(line);
            var matchesByVariable = matches
                .Select(m => m.Groups)
                .GroupBy(gc => gc["variable"].Value)
                .ToDictionary(gc => gc.Key, gc => gc.ToArray()[0][1].Value);
            return matchesByVariable;
        }

        private IdentityDocument RegisterDocument(Dictionary<string, string> matchesByVariable)
        {
            var document = new IdentityDocument();
            foreach (var kv in matchesByVariable)
            {
                switch (kv.Key)
                {
                    case "byr":
                        document.Registration.BirthYear = kv.Value;
                        break;
                    case "iyr":
                        document.Registration.IssueYear = kv.Value;
                        break;
                    case "eyr":
                        document.Registration.ExpirationYear = kv.Value;
                        break;
                    case "hgt":
                        document.Registration.Heigth = kv.Value;
                        break;
                    case "hcl":
                        document.Registration.HairColor = kv.Value;
                        break;
                    case "ecl":
                        document.Registration.EyeColor = kv.Value;
                        break;
                    case "pid":
                        document.Registration.PassportId = kv.Value;
                        break;
                    case "cid":
                        document.Registration.CountryId = kv.Value;
                        break;
                    default:
                        break;
                }
            }
            return document;
        }
    }
}