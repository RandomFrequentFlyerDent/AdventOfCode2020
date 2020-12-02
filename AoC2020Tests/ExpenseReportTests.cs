using AdventOfCode2020.expenses;
using NUnit.Framework;
using System.Collections.Generic;

namespace AoC2020Tests
{
    public class ExpenseReportTests
    {
        private ExpenseReport _expenseReport;
        private readonly List<string> _input = new List<string> { "1721", "979", "366", "299", "675", "1456" };

        [SetUp]
        public void Setup()
        {
            _expenseReport = new ExpenseReport();
        }

        [TestCase(ExpenseDepth.Two, 514579)]
        [TestCase(ExpenseDepth.Three, 241861950)]
        public void ShouldGetCorrectExpense(ExpenseDepth depth, int expected)
        {
            var actual = _expenseReport.GetAnswer(_input, depth);
            Assert.AreEqual(expected, actual);
        }
    }
}