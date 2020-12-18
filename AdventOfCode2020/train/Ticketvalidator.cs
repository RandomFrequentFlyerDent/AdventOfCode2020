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
                ? GetInvalidByAnyField().Sum()
                : part == 2
                ? GetValidatedTicket("departure")
                : GetValidatedTicket("class");
            return answer;
        }

        private List<int> GetInvalidByAnyField()
        {
            return _nearbyTickets.SelectMany(t => t).Where(t => !_validationRules.IsValidForAnyField(t)).ToList();
        }

        private int GetValidatedTicket(string field)
        {
            // wrong answers
            // 337527599
            // 305068317272992
            var validTickets = _nearbyTickets.Where(t => _validationRules.IsValid(t)).ToList();
            var determinedFields = new List<string>();
            var determining = true;
            var ticket = 1;

            do
            {
                for (int i = 0; i < validTickets[0].Count; i++)
                {
                    var ticketsByField = validTickets.Select(t => t[i]).ToList();
                    var validFields = _validationRules.GetValidFields(ticketsByField);
                    if (validFields.All(f => determinedFields.Contains(f)))
                    {
                        continue;
                    }
                    else if (validFields.Count == 1)
                    {
                        determinedFields.Add(validFields[0]);
                        if (validFields[0].StartsWith(field))
                            ticket *= _myTicket[i];
                    }
                    else
                    {
                        var leftOverFields = validFields.Where(f => !determinedFields.Contains(f)).ToList();
                        if (leftOverFields.Count == 1)
                        {
                            determinedFields.Add(leftOverFields[0]);
                            if (leftOverFields[0].StartsWith(field))
                                ticket *= _myTicket[i];
                        }
                    }
                }
                if (determinedFields.Count == validTickets[0].Count)
                    determining = false;
            } while (determining);

            return ticket;
        }

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
                    counter = i + 2;
                    break;
                }
            }

            for (int i = counter; i < input.Count; i++)
            {
                if (!input[i].Equals("nearby tickets:") && !input[i].Equals(""))
                {
                    var ticket = input[i].Split(',').Select(i => int.Parse(i)).ToList();
                    _nearbyTickets.Add(ticket);
                }
            }
        }
    }
}
