using System;

namespace AdventOfCode2020.entertainment
{
    public interface IInstruction
    {
        int Argument { get; set; }
        int Position { get; set; }
        int NumberOfTimesProcessed { get; set; }
        int Process();
        IInstruction GetCleanCopy();
        IInstruction GetOppositeInstruction();
    }
}
