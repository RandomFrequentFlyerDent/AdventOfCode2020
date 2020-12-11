using AdventOfCode2020.charger;
using NUnit.Framework;
using System.Collections.Generic;

namespace AoC2020Tests
{
    public class DeviceChargerTests
    {
        private DeviceCharger _adapterChecker;
        private readonly List<string> _inputSmall = new List<string> { "16", "10", "15", "5", "1", "11", "7", "19", "6", "12", "4" };
        private readonly List<string> _input = new List<string> {"28","33","18","42","31","14","46","20","48","47","24","23",
            "49","45","19","38","39","11","1","32","25","35","8","17","7","9","4","2","34","10","3"};

        [SetUp]
        public void SetUp()
        {
            _adapterChecker = new DeviceCharger();
        }

        [TestCase(AdapterCheck.JoltsDifference, true, 35)]
        [TestCase(AdapterCheck.JoltsDifference, false, 220)]
        [TestCase(AdapterCheck.Arrangements, true, 8)]
        [TestCase(AdapterCheck.Arrangements, false, 19208)]
        public void ShouldCharge(AdapterCheck joltType, bool smallInput, int expected)
        {
            var input = smallInput ? _inputSmall : _input;
            var actual = _adapterChecker.GetAnswer(input, joltType);
            Assert.AreEqual(expected, actual);
        }
    }
}
