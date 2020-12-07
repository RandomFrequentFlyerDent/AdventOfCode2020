using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.luggage
{
    public class LuggageValidator : BaseLogic<LuggageProperty>
    {
        private List<Bag> _bags = new List<Bag>();
        private Bag _myBag;

        public override object GetAnswer(List<string> input, LuggageProperty containment)
        {
            SetBags(input);
            SetContents(input);
            _myBag = _bags.Where(b => b.Color == "shiny gold").First();

            var result = containment == LuggageProperty.Ability
                ? CanContainMyBag()
                : GetPrice();

            return result;
        }

        private int CanContainMyBag()
        {
            return _bags.Where(b => b.CanContainBag(_myBag)).ToList().Count;
        }

        private int GetPrice()
        {
            return GetPrice(_myBag) - 1; // remove price for own bag
        }

        private int GetPrice(Bag bag)
        {
            if (bag.Content.Count == 0)
                return 1;

            var price = 1;
            foreach (var innerBag in bag.Content)
            {
                price += innerBag.Value * GetPrice(innerBag.Key);
            }

            return price;
        }

        private void SetBags(List<string> input)
        {
            input.ForEach(i =>
            {
                var splitInput = i.Split(" bags contain ");
                _bags.Add(new Bag { Color = splitInput[0] });
            });
        }

        private void SetContents(List<string> input)
        {
            foreach (var line in input)
            {
                Regex regex = new Regex(@"^(?<bag>\w+ \w+) bags contain (((?<count>\d+)\s(?<innerBag>\w+ \w+) bags?(, |\.))+||contain no other bags\.)");
                MatchCollection matches = regex.Matches(line);
                Match match = matches[0];
                if (match.Groups[0].Value.Contains("contain no other bags"))
                    continue;

                var bag = _bags.Where(b => b.Color == match.Groups["bag"].Value).First();
                for (int capture = 0; capture < match.Groups["innerBag"].Captures.Count; capture++)
                {
                    var otherBag = _bags.Where(b => b.Color == match.Groups["innerBag"].Captures[capture].Value).First();
                    var count = int.Parse(match.Groups["count"].Captures[capture].Value);
                    bag.Content.Add(otherBag, count);
                }
            }
        }
    }
}
