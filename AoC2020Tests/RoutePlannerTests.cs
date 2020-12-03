using AdventOfCode2020.trajectory;
using NUnit.Framework;
using System.Collections.Generic;

namespace AoC2020Tests
{
    public class RoutePlannerTests
    {
        private RoutePlanner _routePlanner;
        private readonly List<string> _input = new List<string>
        {
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#"
        };

        [SetUp]
        public void SetUp()
        {
            _routePlanner = new RoutePlanner();
        }

        [TestCase(RouteType.Simple, 7)]
        [TestCase(RouteType.Advanced, 336)]
        public void ShouldEncounterTrees(RouteType routeType, int expected)
        {
            var actual = _routePlanner.GetAnswer(_input, routeType);
            Assert.AreEqual(expected, actual);
        }
    }
}
