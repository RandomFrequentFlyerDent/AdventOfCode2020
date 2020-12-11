namespace AdventOfCode2020.seating.ferry
{
    public class Seat : ISpace
    {
        public int Row { get; set; }
        public int Space { get; set; }
        public bool IsOccupied { get; set; }
    }
}
