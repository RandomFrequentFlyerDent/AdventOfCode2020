using AdventOfCode2020.luggage;
using NUnit.Framework;
using System.Collections.Generic;

namespace AoC2020Tests
{
    public class LuggageTests
    {
        private LuggageValidator _validator;

        private readonly List<string> _input = new List<string>
        {
            "light red bags contain 1 bright white bag, 2 muted yellow bags.",
            "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
            "bright white bags contain 1 shiny gold bag.",
            "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
            "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
            "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
            "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
            "faded blue bags contain no other bags.",
            "dotted black bags contain no other bags."
        };

        private readonly List<string> _secondInput = new List<string>
        {
            "shiny gold bags contain 2 dark red bags.",
            "dark red bags contain 2 dark orange bags.",
            "dark orange bags contain 2 dark yellow bags.",
            "dark yellow bags contain 2 dark green bags.",
            "dark green bags contain 2 dark blue bags.",
            "dark blue bags contain 2 dark violet bags.",
            "dark violet bags contain no other bags."
        };

        [SetUp]
        public void SetUp()
        {
            _validator = new LuggageValidator();
        }

        [TestCase(LuggageProperty.Ability, 4)]
        [TestCase(LuggageProperty.Price, 32)]
        [TestCase(LuggageProperty.Price, 126, true)]
        public void ShouldContain(LuggageProperty property, int expected, bool secondInput = false)
        {
            var actual = _validator.GetAnswer(secondInput? _secondInput : _input, property);
            Assert.AreEqual(expected, actual);
        }
    }
}
