namespace AdventOfCode2020.entertainment
{
    public class AccumulatorInstruction : IInstruction
    {
        public int Argument { get; set; }
        public int Position { get; set; }
        public int NumberOfTimesProcessed { get; set; }

        public int Process()
        {
            NumberOfTimesProcessed++;
            GameConsoleDebugger.Accumulator += Argument;
            return Position + 1;
        }
    }
}
