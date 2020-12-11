using System.Collections.Generic;

namespace AdventOfCode2020.seating.ferry
{
    public class SeatingRow
    {
        public List<ISpace> Spaces { get; }
        public SeatingRow()
        {
            Spaces = new List<ISpace>();
        }
    }
}
