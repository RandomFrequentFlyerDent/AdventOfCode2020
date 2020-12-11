using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.charger
{
    public class DeviceCharger : BaseLogic<AdapterCheck>
    {
        private List<int> _adapterJolts;

        public override object GetAnswer(List<string> input, AdapterCheck jolt)
        {
            SetOrderedAdapterJoltsWithDeviceJolt(input);
            var result = jolt == AdapterCheck.JoltsDifference
                ? GetJoltDifference()
                : GetArrangements();
            return result;
        }

        private void SetOrderedAdapterJoltsWithDeviceJolt(List<string> input)
        {
            var adapterJolts = input.Select(i => int.Parse(i)).ToList();
            adapterJolts.AddRange(new List<int> { 0, adapterJolts.Max() + 3 });
            _adapterJolts = adapterJolts.OrderBy(a => a).ToList();
        }

        private int GetJoltDifference()
        {
            var connectorJolt = 0;
            var oneJoltCount = 0;
            var twoJoltCount = 0;
            var threeJoltCount = 0;

            _adapterJolts.ToList().ForEach(adapterJolt =>
            {
                if (CanConnect(adapterJolt, connectorJolt, out int difference))
                {
                    if (difference == 1)
                        oneJoltCount++;
                    if (difference == 2)
                        twoJoltCount++;
                    if (difference == 3)
                        threeJoltCount++;
                }
                connectorJolt = adapterJolt;
            });

            return oneJoltCount * threeJoltCount; 
        }

        private long GetArrangements()
        {
            Dictionary<long, long> arrangements = new Dictionary<long, long>();
            return GetArrangements(_adapterJolts, arrangements);
        }

        private long GetArrangements(IEnumerable<int> adapters, Dictionary<long, long> arrangements)
        {
            var length = adapters.Count();
            var currentJolt = adapters.First();
            long possibilties = 0;

            if (arrangements.ContainsKey(currentJolt))
                return arrangements[currentJolt];

            if (length >= 2 && adapters.Skip(1).First() - currentJolt <= 3)
                possibilties += GetArrangements(adapters.Skip(1), arrangements);
            if (length >= 3 && adapters.Skip(2).First() - currentJolt <= 3)
                possibilties += GetArrangements(adapters.Skip(2), arrangements);
            if (length >= 4 && adapters.Skip(3).First() - currentJolt <= 3)
                possibilties += GetArrangements(adapters.Skip(3), arrangements);
            if (length == 1)
                possibilties = 1;
            arrangements.Add(currentJolt, possibilties);
            return possibilties;
        }

        private bool CanConnect(int adapterJolt, int connectorJolt, out int joltDifference)
        {
            joltDifference = adapterJolt - connectorJolt;
            return joltDifference >= 1 && joltDifference <= 3;
        }
    }
}
