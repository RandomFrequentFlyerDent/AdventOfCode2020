namespace AdventOfCode2020.entertainment
{
    public interface IInstruction
    {
        int Argument { set; }
        int Position { set; }
        int NumberOfTimesProcessed { get; set; }
        int Process();
    }
}
