using System;
using System.ComponentModel;

namespace AdventOfCode2020.entertainment
{
    public enum Operation
    {
        [Description("Accumulator")]
        acc,
        [Description("Jump")]
        jmp,
        [Description("NoOperation")]
        nop
    }
}
