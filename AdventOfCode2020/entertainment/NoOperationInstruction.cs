﻿using System;

namespace AdventOfCode2020.entertainment
{
    public class NoOperationInstruction : IInstruction
    {
        public long Argument { get; set; }

        public int GetAccumulator(int currentAccumulator, IInstruction[] instructions)
        {
            throw new NotImplementedException();
        }
    }
}
