using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.train
{
    public class Ticketvalidator : ILogic
    {
        private List<int> _myTicket = new List<int>();
        private List<List<int>> _nearbyTickets = new List<List<int>>();
        private ValidationRules _validationRules = new ValidationRules();

        public object GetAnswer(List<string> input, int part)
        {
            ExtractRulesAndTickets(input);
            var answer = part == 1
                ? 1
                : 2;
            return answer;
        }

        //private List<int> GetInvalidByAnyField()
        //{
        //    var ranges = _validationRules.Rules.Values.SelectMany(d => d).ToList();
        //    _nearbyTickets.SelectMany(nt => nt).Where(t => ranges.)
        //}

        private void ExtractRulesAndTickets(List<string> input)
        {
            var counter = 0;
            var parsingRules = true;

            Regex regex = new Regex(@"^(?<field>(\w+\s)?\w+): (?<first>\d+)-(?<second>\d+) or (?<third>\d+)-(?<fourth>\d+)");
            do
            {
                Match match = regex.Match(input[counter]);
                if (match.Success)
                {
                    var groups = match.Groups;
                    _validationRules.AddToRules(groups["field"].Value, int.Parse(groups["first"].Value),
                        int.Parse(groups["second"].Value), int.Parse(groups["third"].Value), int.Parse(groups["fourth"].Value));
                    counter++;
                }
                else
                {
                    parsingRules = false;
                }
            } while (parsingRules);

            for (int i = counter; i < input.Count; i++)
            {
                if (input[i].Equals("your ticket:"))
                {
                    _myTicket = input[i + 1].Split(',').Select(i => int.Parse(i)).ToList();
                    counter = i + 1;
                    break;
                }
            }

            for (int i = counter; i < input.Count; i++)
            {
                if (!input[i].Equals("nearby tickets:"))
                {
                    var ticket = input[i].Split(',').Select(i => int.Parse(i)).ToList();
                    _nearbyTickets.Add(ticket);
                }
            }
        }
    }
}
