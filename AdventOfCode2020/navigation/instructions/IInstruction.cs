namespace AdventOfCode2020.navigation.instructions
{
    public interface IInstruction
    {
        Position Move(Position position);
    }
}
