namespace AdventOfCode2020.seating.ferry
{
    public interface ISpace
    {
        int Row { get; set; }
        int Space { get; set; }
        bool IsOccupied { get; set; }
    }
}
