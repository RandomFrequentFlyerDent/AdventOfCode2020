namespace AdventOfCode2020.entertainment
{
    public class AccumulatorInstruction : IInstruction
    {
        public int Argument { get; set; }
        public int Position { get; set; }
        public int NumberOfTimesProcessed { get; set; }

        public (int nextPosition, long accumulator) Process(long accumulator)
        {
            NumberOfTimesProcessed++;
            return (Position + 1, accumulator += Argument);
        }

        public IInstruction GetCleanCopy()
        {
            return new AccumulatorInstruction { Argument = Argument, Position = Position, NumberOfTimesProcessed = 0 };
        }

        public IInstruction GetOppositeInstruction()
        {
            return null;
        }
    }
}
