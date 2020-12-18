using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.train
{
    public class TicketValidator : ILogic
    {
        private Ticket _myTicket;
        private readonly List<Ticket> _nearbyTickets = new List<Ticket>();
        private readonly ValidationRules _validationRules = new ValidationRules();

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

        private long GetValidatedTicket(string field)
        {
            var validTickets = _nearbyTickets.Where(t => t.IsValid(_validationRules)).ToList();
            var unfoundRules = _validationRules.Rules.Where(r => r.Position == -1).ToList();
            var searching = true;

            while (searching)
            {
                for (int i = 0; i < _myTicket.Values.Count; i++)
                {
                    var valuesByField = validTickets.Select(t => t.Values[i]).ToList();
                    var rules = unfoundRules.Where(r => r.IsMatch(valuesByField)).ToList();
                    if (rules.Count == 1)
                    {
                        rules[0].Position = i;
                        unfoundRules.Remove(rules[0]);
                        continue;
                    }
                }
                if (unfoundRules.Count == 0)
                    searching = false;
            }

            var positions = _validationRules.Rules.Where(r => r.Field.StartsWith(field)).Select(r => r.Position).ToList();
            long ticket = 1L;

            foreach (var position in positions)
                ticket *= _myTicket.Values[position];

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
