namespace AdventOfCode2020.entertainment
{
    public class JumpInstruction : IInstruction
    {
        public long Argument { get; set; }

        public int GetAccumulator(int currentAccumulator, IInstruction[] instructions)
        {
            throw new System.NotImplementedException();
        }
    }
}
