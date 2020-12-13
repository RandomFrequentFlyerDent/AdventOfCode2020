using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.bus
{
    public class BusScheduler : ILogic
    {
        public object GetAnswer(List<string> input, int part)
        {
            var answer = part == 1
                ? CatchEarliestBus(input)
                : part == 2
                ? WinContest(input, false)
                : WinContest(input, true);
            return answer;
        }

        private long CatchEarliestBus(List<string> input)
        {
            (long timestamp, List<Bus> busses) = GetSchedule(input);
            var earliestBus = busses
                .Select(b => new { Bus = b, Time = b.GetEarliestTime(timestamp) })
                .OrderBy(b => b.Time).First();
            return (earliestBus.Time - timestamp) * earliestBus.Bus.Id;
        }

        private (long, List<Bus>) GetSchedule(List<string> input)
        {
            var timestamp = int.Parse(input[0]);
            var busses = GetBusses(input[1].Split(",").ToList());
            return (timestamp, busses);
        }

        private long WinContest(List<string> input, bool testing)
        {
            (long timestamp, List<Bus> busses) schedule = GetSchedule(input);
            var notConsecutive = true;
            var orderedBusses = schedule.busses.OrderBy(bus => bus.Offset).ToList();
            long timestamp = testing ? orderedBusses[0].Id : orderedBusses[0].GetEarliestTime(100000000000000);
            do
            {
                var result = orderedBusses.Select(bus => new { consecutive = bus.IsConsecutive(timestamp), earliestTime = bus.GetEarliestTime(timestamp), offset = bus.Offset }).ToList();
                if (result.All(r => r.consecutive))
                {
                    notConsecutive = false;
                }
                else
                {
                    var max = result.OrderBy(r => r.earliestTime).ThenByDescending(r => r.offset).Last();
                    var newtstmp = orderedBusses[0].GetEarliestTime(max.earliestTime - max.offset - 1);
                    timestamp = newtstmp <= timestamp ? timestamp + orderedBusses[0].Id : newtstmp;
                }
            } while (notConsecutive);
            return timestamp;
        }

        private List<Bus> GetBusses(List<string> schedule)
        {
            var busses = new List<Bus>();
            var offset = 0;
            schedule.ForEach(s =>
            {
                if (int.TryParse(s, out int id))
                    busses.Add(new Bus(id, offset));
                offset++;
            });
            return busses;
        }
    }

    class Bus
    {
        public long Id { get; }
        public int Offset { get; }

        public Bus(int id, int offset)
        {
            Id = id;
            Offset = offset;
        }

        public long GetEarliestTime(long timestamp) => timestamp + Id - (timestamp % Id);

        public bool IsConsecutive(long timestamp) => (timestamp + Offset) % Id == 0;
    }
}
