using AdventOfCode2020;
using NUnit.Framework;
using System.Collections.Generic;

namespace AoC2020Tests
{
    public class DatabaseCheckerTests
    {
        private DatabaseChecker _databaseChecker;
        private List<string> _input = new List<string>
        {
            "1-3 a: abcde",
            "1-3 b: cdefg",
            "2-9 c: ccccccccc"
        };

        [SetUp]
        public void SetUp()
        {
            _databaseChecker = new DatabaseChecker();
        }

        [TestCase(ValidationPolicy.SledRentalPlace, 2)]
        [TestCase(ValidationPolicy.TobogganCorporate, 1)]
        public void ShouldGetNumberOfCorrectPasswords(ValidationPolicy policy, int expected)
        {
            var actual = _databaseChecker.GetNumberOfValidPasswords(_input, policy);
            Assert.AreEqual(expected, actual);
        }
    }
}
