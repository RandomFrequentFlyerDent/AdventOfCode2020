using AdventOfCode2020.entertainment;
using NUnit.Framework;
using System.Collections.Generic;

namespace AoC2020Tests
{
    public class GameConsoleDebuggerTests
    {
        private GameConsoleDebugger _debugger;
        private readonly List<string> _input = new List<string>
        {
            "nop +0",
            "acc +1",
            "jmp +4",
            "acc +3",
            "jmp -3",
            "acc -99",
            "acc +1",
            "jmp -4",
            "acc +6"
        };

        [SetUp]
        public void SetUp()
        {
            _debugger = new GameConsoleDebugger();
        }

        [TestCase(DebugMode.Isolation, 5)]
        public void ShouldGetAccumulator(DebugMode debugMode, int expected)
        {
            var actual = _debugger.GetAnswer(_input, debugMode);
            Assert.AreEqual(expected, actual);
        }
    }
}
