namespace AdventOfCode2020.entertainment
{
    public class NoOperationInstruction : IInstruction
    {
        public int Argument { private get; set; }
        public int Position { private get; set; }
        public int NumberOfTimesProcessed { get; set; }

        public int Process()
        {
            NumberOfTimesProcessed++;
            return Position + 1;
        }
    }
}
