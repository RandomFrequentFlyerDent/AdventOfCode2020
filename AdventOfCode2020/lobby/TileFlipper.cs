using System.Collections.Generic;

namespace AdventOfCode2020.lobby
{
    public class TileFlipper : ILogic
    {
        public object GetAnswer(List<string> input, int part)
        {
            var answer = part == 1
                ? 1
                : 2;
            return answer;
        }
    }
}
