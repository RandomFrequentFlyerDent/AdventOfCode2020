using System.Collections.Generic;

namespace AdventOfCode2020.entertainment
{
    public class GameConsoleDebugger : BaseLogic<DebugMode>
    {
        public override object GetAnswer(List<string> input, DebugMode debugMode)
        {
            var answer = debugMode == DebugMode.Isolation
                ? 1
                : 2;
            return answer;
        }
    }
}
