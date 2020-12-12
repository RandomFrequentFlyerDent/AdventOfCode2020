namespace AdventOfCode2020.navigation.instructions
{
    public class MoveInstruction : IInstruction
    {
        public WindDirection Direction { get; set; }
        public int Units { get; set; }

        public Position Move(Position position)
        {
            if (Direction == WindDirection.NA)
                return position.Facing.Move(position, Units, true);
            return Direction.Move(position, Units, false);
        }
    }
}
