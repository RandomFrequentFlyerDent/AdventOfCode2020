namespace AdventOfCode2020.entertainment
{
    public class JumpInstruction : IInstruction
    {
        public int Argument { get; set; }
        public int Position { get; set; }
        public int NumberOfTimesProcessed { get; set; }

        public (int nextPosition, long accumulator) Process(long accumulator)
        {
            NumberOfTimesProcessed++;
            return (Position + Argument, accumulator);
        }

        public IInstruction GetCleanCopy()
        {
            return new JumpInstruction { Argument = Argument, Position = Position, NumberOfTimesProcessed = 0 };
        }

        public IInstruction GetOppositeInstruction()
        {
            return new NoOperationInstruction { Argument = Argument, Position = Position, NumberOfTimesProcessed = 0 };
        }
    }
}
