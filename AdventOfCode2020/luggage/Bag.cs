using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.luggage
{
    public class Bag
    {
        public string Color { get; set; }
        public Dictionary<Bag, int> Content { get; }

        public Bag()
        {
            Content = new Dictionary<Bag, int>();
        }

        public bool CanContainBag(Bag bag)
        {
            if (bag.Color == this.Color)
                return false;

            return IsInContent(bag);
        }

        private bool IsInContent(Bag bag)
        {
            if (Content.Count == 0)
                return false;
            
            if (Content.ContainsKey(bag))
                return true;

            return Content.Any(c => c.Key.CanContainBag(bag));
        }
    }
}
