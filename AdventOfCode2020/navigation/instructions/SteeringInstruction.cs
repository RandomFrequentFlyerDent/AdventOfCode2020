namespace AdventOfCode2020.navigation.instructions
{
    public class SteeringInstruction : IInstruction
    {
        public RotateDirection Direction { get; set; }
        public int Degrees { get; set; }

        public Position Move(Position position)
        {
            return new Position
            {
                NorthSouth = position.NorthSouth,
                EastWest = position.EastWest,
                Facing = position.Facing.ChangeDirection(Direction, Degrees)
            };
        }
    }
}
