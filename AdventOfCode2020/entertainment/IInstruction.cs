namespace AdventOfCode2020.entertainment
{
    public interface IInstruction
    {
        long Argument { get; set; }
        int GetAccumulator(int currentAccumulator, IInstruction[] instructions);
    }
}
