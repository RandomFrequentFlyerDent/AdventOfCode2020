using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.bus
{
    public class BusScheduler : ILogic
    {
        private long _timestamp;
        private List<Bus> _busses;

        public object GetAnswer(List<string> input, int part)
        {
            (long timestamp, List<Bus> busses) = GetSchedule(input);
            _timestamp = timestamp;
            _busses = busses;

            var answer = part == 1
                ? CatchEarliestBus()
                : WinCoin();
            return answer;
        }

        private long CatchEarliestBus()
        {
            var earliestBus = _busses
                .Select(b => new { Bus = b, Time = b.GetEarliestTime(_timestamp) })
                .OrderBy(b => b.Time).First();
            return (earliestBus.Time - _timestamp) * earliestBus.Bus.Id;
        }
        private long WinCoin()
        {
            var timestamp = _busses[0].Id;
            var step = _busses[0].Id;
            for (int i = 1; i < _busses.Count; i++)
            {
                var bus = _busses[i];
                while (!bus.IsConsecutive(timestamp))
                {
                    timestamp += step;
                }
                step *= bus.Id;
            }
            return timestamp;
        }

        private (long, List<Bus>) GetSchedule(List<string> input)
        {
            var timestamp = int.Parse(input[0]);
            var busses = GetBusses(input[1].Split(",").ToList());
            return (timestamp, busses);
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
