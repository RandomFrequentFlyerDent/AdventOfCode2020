using AdventOfCode2020;
using NUnit.Framework;

namespace AoC2020Tests
{
    public class GenericTests
    {
        private Logic _logic;
        private TestInput _input;

        [SetUp]
        public void SetUp()
        {
            _logic = new Logic();
            _input = new TestInput();
        }

        [TestCase(12, 2, 19, ExpectedResult = 286, TestName = "FerrySteering_Part2")]
        [TestCase(12, 1, 19, ExpectedResult = 25, TestName = "FerrySteering_Part1")]
        [TestCase(11, 2, 18, ExpectedResult = 26, TestName = "LayoutManager_Part2")]
        [TestCase(11, 1, 18, ExpectedResult = 37, TestName = "LayoutManager_Part1")]
        [TestCase(10, 2, 17, ExpectedResult = 19208, TestName = "DeviceCharger_Part2b")]
        [TestCase(10, 1, 17, ExpectedResult = 220, TestName = "DeviceCharger_Part1b")]
        [TestCase(10, 2, 16, ExpectedResult = 8, TestName = "DeviceCharger_Part2a")]
        [TestCase(10, 1, 16, ExpectedResult = 35, TestName = "DeviceCharger_Part1a")]
        [TestCase(9, 4, 15, ExpectedResult = 62, TestName = "Attacker_Part2")]
        [TestCase(9, 3, 15, ExpectedResult = 127, TestName = "Attacker_Part1")]
        [TestCase(8, 2, 14, ExpectedResult = 8, TestName = "ConsoleDebugger_Part2")]
        [TestCase(8, 1, 14, ExpectedResult = 5, TestName = "ConsoleDebugger_Part1")]
        [TestCase(7, 2, 13, ExpectedResult = 126, TestName = "Luggage_Part2b")]
        [TestCase(7, 2, 12, ExpectedResult = 32, TestName = "Luggage_Part2a")]
        [TestCase(7, 1, 12, ExpectedResult = 4, TestName = "Luggage_Part1")]
        [TestCase(6, 2, 11, ExpectedResult = 6, TestName = "DeclarationForms_Part2")]
        [TestCase(6, 1, 11, ExpectedResult = 11, TestName = "DeclarationForms_Part1")]
        [TestCase(5, 1, 10, ExpectedResult = 357, TestName = "BoardingPassScaner_Part1d")]
        [TestCase(5, 1, 9, ExpectedResult = 567, TestName = "BoardingPassScaner_Part1c")]
        [TestCase(5, 1, 8, ExpectedResult = 119, TestName = "BoardingPassScaner_Part1b")]
        [TestCase(5, 1, 7, ExpectedResult = 820, TestName = "BoardingPassScaner_Part1a")]
        [TestCase(4, 2, 6, ExpectedResult = 0, TestName = "IdentityDocumentScanner_Part2b")]
        [TestCase(4, 2, 5, ExpectedResult = 3, TestName = "IdentityDocumentScanner_Part2a")]
        [TestCase(4, 1, 4, ExpectedResult = 2, TestName = "IdentityDocumentScanner_Part1")]
        [TestCase(3, 2, 3, ExpectedResult = 336, TestName = "RoutePlanner_Part2")]
        [TestCase(3, 1, 3, ExpectedResult = 7, TestName = "RoutePlanner_Part1")]
        [TestCase(2, 2, 2, ExpectedResult = 1, TestName = "DatabaseChecker_Part2")]
        [TestCase(2, 1, 2, ExpectedResult = 2, TestName = "DatabaseChecker_Part1")]
        [TestCase(1, 2, 1, ExpectedResult = 241861950, TestName = "ExpenseReport_Part2")]
        [TestCase(1, 1, 1, ExpectedResult = 514579, TestName = "ExpenseReport_Part1")]
        public object Test(int day, int part, int input)
        {
            var logic = _logic[day];
            return logic.GetAnswer(_input[input], part);
        }
    }
}
