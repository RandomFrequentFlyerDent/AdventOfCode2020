using System.Collections.Generic;

namespace AdventOfCode2020
{
    public interface ILogic
    {
        object GetAnswer(List<string> input, int modifier);
    }
}
