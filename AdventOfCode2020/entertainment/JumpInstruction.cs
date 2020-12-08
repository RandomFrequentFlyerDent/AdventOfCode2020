namespace AdventOfCode2020.entertainment
{
    public class JumpInstruction : IInstruction
    {
        public int Argument { get; set; }
        public int Position { get; set; }
        public int NumberOfTimesProcessed { get; set; }

        public int Process()
        {
            NumberOfTimesProcessed++;
            return Position + Argument;
        }
    }
}
