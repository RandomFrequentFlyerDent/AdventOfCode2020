namespace AdventOfCode2020.seating.ferry
{
    public class Floor : ISpace
    {
        public int Row { get; set; }
        public int Space { get; set; }
        public bool IsOccupied { get { return false; } set { throw new System.Exception("Can't sit on the floor"); } }
    }
}
