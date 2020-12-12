using AdventOfCode2020.seating.ferry;
using NUnit.Framework;
using System.Collections.Generic;

namespace AoC2020Tests
{
    public class LayoutManagerTests
    {
        private LayoutManager _layoutManager;
        private readonly List<string> _input = new List<string>
        {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL"
        };

        [SetUp]
        public void SetUp()
        {
            _layoutManager = new LayoutManager();
        }

        [TestCase(RuleSet.Simple, 37)]
        [TestCase(RuleSet.Advanced, 26)]
        public void ShouldGetUnoccupiedSeats(RuleSet ruleSet, int expected)
        {
            var actual = _layoutManager.GetAnswer(_input, ruleSet);
            Assert.AreEqual(expected, actual);
        }
    }
}
