using AdventOfCode2020;
using NUnit.Framework;
using System.Collections.Generic;

namespace AoC2020Tests
{
    public class ExpenseReportTests
    {
        private ExpenseReport _expenseReport;
        private List<string> _input = new List<string> { "1721", "979", "366", "299", "675", "1456" };

        [SetUp]
        public void Setup()
        {
            _expenseReport = new ExpenseReport();
        }

        [Test]
        public void ShouldGetSimple()
        {
            var actual = _expenseReport.Get(_input, simple:true);
            Assert.AreEqual(514579, actual);
        }

        [Test]
        public void ShouldGet()
        {
            var actual = _expenseReport.Get(_input);
            Assert.AreEqual(241861950, actual);
        }
    }
}