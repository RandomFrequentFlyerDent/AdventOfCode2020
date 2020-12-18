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

        [TestCase(16, 3, 36, ExpectedResult = 12, TestName = "TrainTicketValidator_2")]
        [TestCase(16, 1, 35, ExpectedResult = 71, TestName = "TrainTicketValidator_1")]
        [TestCase(15, 2, 34, ExpectedResult = 362, TestName = "MemoryCard_2g")]
        [TestCase(15, 2, 33, ExpectedResult = 18, TestName = "MemoryCard_2f")]
        [TestCase(15, 2, 32, ExpectedResult = 6895259, TestName = "MemoryCard_2e")]
        [TestCase(15, 2, 31, ExpectedResult = 261214, TestName = "MemoryCard_2d")]
        [TestCase(15, 2, 30, ExpectedResult = 3544142, TestName = "MemoryCard_2c")]
        [TestCase(15, 2, 29, ExpectedResult = 2578, TestName = "MemoryCard_2b")]
        [TestCase(15, 2, 28, ExpectedResult = 175594, TestName = "MemoryCard_2a")]
        [TestCase(15, 1, 34, ExpectedResult = 1836, TestName = "MemoryCard_1g")]
        [TestCase(15, 1, 33, ExpectedResult = 438, TestName = "MemoryCard_1f")]
        [TestCase(15, 1, 32, ExpectedResult = 78, TestName = "MemoryCard_1e")]
        [TestCase(15, 1, 31, ExpectedResult = 27, TestName = "MemoryCard_1d")]
        [TestCase(15, 1, 30, ExpectedResult = 10, TestName = "MemoryCard_1c")]
        [TestCase(15, 1, 29, ExpectedResult = 1, TestName = "MemoryCard_1b")]
        [TestCase(15, 1, 28, ExpectedResult = 436, TestName = "MemoryCard_1a")]
        [TestCase(14, 2, 27, ExpectedResult = 208, TestName = "Initializer_2")]
        [TestCase(14, 1, 26, ExpectedResult = 165, TestName = "Initializer_1")]
        [TestCase(13, 2, 25, ExpectedResult = 1202161486, TestName = "BusSchedule_2f")]
        [TestCase(13, 2, 24, ExpectedResult = 1261476, TestName = "BusSchedule_2e")]
        [TestCase(13, 2, 23, ExpectedResult = 779210, TestName = "BusSchedule_2d")]
        [TestCase(13, 2, 22, ExpectedResult = 754018, TestName = "BusSchedule_2c")]
        [TestCase(13, 2, 21, ExpectedResult = 3417, TestName = "BusSchedule_2b")]
        [TestCase(13, 2, 20, ExpectedResult = 1068781, TestName = "BusSchedule_2a")]
        [TestCase(13, 1, 20, ExpectedResult = 295, TestName = "BusSchedule_1")]
        [TestCase(12, 2, 19, ExpectedResult = 286, TestName = "FerrySteering_2")]
        [TestCase(12, 1, 19, ExpectedResult = 25, TestName = "FerrySteering_1")]
        [TestCase(11, 2, 18, ExpectedResult = 26, TestName = "LayoutManager_2")]
        [TestCase(11, 1, 18, ExpectedResult = 37, TestName = "LayoutManager_1")]
        [TestCase(10, 2, 17, ExpectedResult = 19208, TestName = "DeviceCharger_2b")]
        [TestCase(10, 1, 17, ExpectedResult = 220, TestName = "DeviceCharger_1b")]
        [TestCase(10, 2, 16, ExpectedResult = 8, TestName = "DeviceCharger_2a")]
        [TestCase(10, 1, 16, ExpectedResult = 35, TestName = "DeviceCharger_1a")]
        [TestCase(9, 4, 15, ExpectedResult = 62, TestName = "Attacker_2")]
        [TestCase(9, 3, 15, ExpectedResult = 127, TestName = "Attacker_1")]
        [TestCase(8, 2, 14, ExpectedResult = 8, TestName = "ConsoleDebugger_2")]
        [TestCase(8, 1, 14, ExpectedResult = 5, TestName = "ConsoleDebugger_1")]
        [TestCase(7, 2, 13, ExpectedResult = 126, TestName = "Luggage_2b")]
        [TestCase(7, 2, 12, ExpectedResult = 32, TestName = "Luggage_2a")]
        [TestCase(7, 1, 12, ExpectedResult = 4, TestName = "Luggage_1")]
        [TestCase(6, 2, 11, ExpectedResult = 6, TestName = "DeclarationForms_2")]
        [TestCase(6, 1, 11, ExpectedResult = 11, TestName = "DeclarationForms_1")]
        [TestCase(5, 1, 10, ExpectedResult = 357, TestName = "BoardingPassScaner_1d")]
        [TestCase(5, 1, 9, ExpectedResult = 567, TestName = "BoardingPassScaner_1c")]
        [TestCase(5, 1, 8, ExpectedResult = 119, TestName = "BoardingPassScaner_1b")]
        [TestCase(5, 1, 7, ExpectedResult = 820, TestName = "BoardingPassScaner_1a")]
        [TestCase(4, 2, 6, ExpectedResult = 0, TestName = "IdentityDocumentScanner_2b")]
        [TestCase(4, 2, 5, ExpectedResult = 3, TestName = "IdentityDocumentScanner_2a")]
        [TestCase(4, 1, 4, ExpectedResult = 2, TestName = "IdentityDocumentScanner_1")]
        [TestCase(3, 2, 3, ExpectedResult = 336, TestName = "RoutePlanner_2")]
        [TestCase(3, 1, 3, ExpectedResult = 7, TestName = "RoutePlanner_1")]
        [TestCase(2, 2, 2, ExpectedResult = 1, TestName = "DatabaseChecker_2")]
        [TestCase(2, 1, 2, ExpectedResult = 2, TestName = "DatabaseChecker_1")]
        [TestCase(1, 2, 1, ExpectedResult = 241861950, TestName = "ExpenseReport_2")]
        [TestCase(1, 1, 1, ExpectedResult = 514579, TestName = "ExpenseReport_1")]
        public object Test(int day, int part, int input)
        {
            var logic = _logic[day];
            return logic.GetAnswer(_input[input], part);
        }
    }
}
