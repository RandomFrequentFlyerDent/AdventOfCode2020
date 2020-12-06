using AdventOfCode2020.customs;
using NUnit.Framework;
using System.Collections.Generic;

namespace AoC2020Tests
{
    public class DeclarationFormsTests
    {
        private DeclarationForms _declarationForms;
        private readonly List<string> _input = new List<string> { "abc", "", "a", "b", "c", "", "ab", "ac", "", "a", "a", "a", "a", "", "b" };

        [SetUp]
        public void SetUp()
        {
            _declarationForms = new DeclarationForms();
        }

        [TestCase(CustomsType.AnyoneYes, 11)]
        [TestCase(CustomsType.AllYes, 6)]
        public void ShouldGetAnswer(CustomsType customsType, int expected)
        {
            var actual = _declarationForms.GetAnswer(_input, customsType);
            Assert.AreEqual(expected, actual);
        }
    }
}


