using AdventOfCode2020.navigation;
using NUnit.Framework;
using System.Collections.Generic;

namespace AoC2020Tests
{
    public class FerrySteeringTests
    {
        private FerrySteering _steering;
        private readonly List<string> _input = new List<string> { "F10", "N3", "F7", "R90", "F11" };

        [SetUp]
        public void SetUp()
        {
            _steering = new FerrySteering();
        }

        [TestCase(Navigation.Ferry, 25)]
        [TestCase(Navigation.WayPoint, 286)]
        public void ShouldMove(Navigation navigation, int expected)
        {
            var actual = _steering.GetAnswer(_input, navigation);
            Assert.AreEqual(expected, actual);
        }
    }
}
