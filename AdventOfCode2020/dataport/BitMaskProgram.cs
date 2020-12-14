using System.Collections.Generic;

namespace AdventOfCode2020.dataport
{
    public class BitMaskProgram
    {
        public string Mask { get; set; }
        public List<KeyValuePair<int, int>> Bit { get; } = new List<KeyValuePair<int, int>>();
    }
}
