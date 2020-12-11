using AdventOfCode2020.seating.plane;
using NUnit.Framework;
using System.Linq;

namespace AoC2020Tests
{
    public class BoardingPassScannerTests
    {
        private BoardingPassScanner _passScanner;

        [SetUp]
        public void SetUp()
        {
            _passScanner = new BoardingPassScanner();
        }

        [TestCase(BoardingPassActivity.SanityCheck, new string[] { "FBFBBFFRLR" }, 357)]
        [TestCase(BoardingPassActivity.SanityCheck, new string[] { "BFFFBBFRRR" }, 567)]
        [TestCase(BoardingPassActivity.SanityCheck, new string[] { "FFFBBBFRRR" }, 119)]
        [TestCase(BoardingPassActivity.SanityCheck, new string[] { "BBFFBBFRLL" }, 820)]
        public void ShouldGetSeat(BoardingPassActivity passType, string[] input, int expected)
        {
            var actual = _passScanner.GetAnswer(input.ToList(), passType);
            Assert.AreEqual(expected, actual);
        }
    }
}
