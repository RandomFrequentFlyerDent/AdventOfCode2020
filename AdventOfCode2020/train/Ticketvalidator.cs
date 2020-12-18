using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.train
{
    public class TicketValidator : ILogic
    {
        private Ticket _myTicket;
        private List<Ticket> _nearbyTickets = new List<Ticket>();
        private ValidationRules _validationRules = new ValidationRules();

        public object GetAnswer(List<string> input, int part)
        {
            ExtractRulesAndTickets(input);
            var answer = part == 1
                ? GetInvalidByAnyField().Sum()
                : part == 2
                ? GetValidatedTicket("departure")
                : GetValidatedTicket("class");
            return answer;
        }

        private List<int> GetInvalidByAnyField()
        {
            return _nearbyTickets.SelectMany(t => t.Values).Where(v => !_validationRules.Rules.Any(r => r.IsValid(v))).ToList();
        }

        private int GetValidatedTicket(string field)
        {
            // wrong answers
            // 337527599
            // 305068317272992
            var validTickets = _nearbyTickets.Where(t => _validationRules.IsValid(t)).ToList();
            validTickets.Add(_myTicket);
            var unfoundRules = _validationRules.Rules.Where(r => r.Order == -1).ToList();
            var searching = true;

            while (searching)
            {
                for (int i = 0; i < _myTicket.Values.Count; i++)
                {
                    var valuesByField = validTickets.Select(t => t.Values[i]).ToList();
                    var rules = unfoundRules.Where(r => valuesByField.All(v => r.IsValid(v))).ToList();
                    if (rules.Count == 1)
                    {
                        rules[0].Order = i;
                        unfoundRules.Remove(rules[0]);
                        continue;
                    }
                }
                if (unfoundRules.Count == 0)
                    searching = false;
            }

            var fieldRules = _validationRules.Rules.Where(r => r.Field.StartsWith(field)).ToList();
            var ticket = 1;

            foreach (var rule in fieldRules)
            {
                ticket *= _myTicket.Values[rule.Order];
            }

            return ticket;
        }

        private void ExtractRulesAndTickets(List<string> input)
        {
            var state = ReadState.Rules;
            Regex ruleRx = new Regex(@"^(?<field>(\w+\s)?\w+): (?<first>\d+)-(?<second>\d+) or (?<third>\d+)-(?<fourth>\d+)");

            for (int i = 0; i < input.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(input[i]))
                    continue;
                if (input[i].Equals("your ticket:"))
                {
                    state = ReadState.OwnTicket;
                    continue;
                }
                if (input[i].Equals("nearby tickets:"))
                {
                    state = ReadState.NearbyTickets;
                    continue;
                }
                if (state == ReadState.Rules)
                {
                    Match match = ruleRx.Match(input[i]);
                    var groups = match.Groups;
                    var rule = new ValidationRule(groups["field"].Value, groups["first"].Value,
                        groups["second"].Value, groups["third"].Value, groups["fourth"].Value);
                    _validationRules.Rules.Add(rule);
                    continue;
                }
                if (state == ReadState.OwnTicket)
                {
                    _myTicket = new Ticket(input[i]);
                    continue;
                }
                if (state == ReadState.NearbyTickets)
                {
                    var ticket = new Ticket(input[i]);
                    _nearbyTickets.Add(ticket);
                    continue;
                }
            }
        }

        public enum ReadState { Rules, OwnTicket, NearbyTickets }
    }
}
