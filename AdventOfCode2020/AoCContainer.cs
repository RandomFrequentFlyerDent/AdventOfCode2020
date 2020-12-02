using System;

namespace AdventOfCode2020
{
    public class AoCContainer
    {
        //private readonly ExpenseReport _expenseReport;
        private readonly DatabaseChecker _databaseChecker;
        public AoCContainer()
        {
            //_expenseReport = new ExpenseReport();
            _databaseChecker = new DatabaseChecker();
        }

        public void GetAnswer()
        {
            var result = _databaseChecker.GetNumberOfValidPasswords(InputReader.ReadFile("daytwo.txt"), ValidationPolicy.TobogganCorporate);
            Console.WriteLine($"Answer: {result}");
        }
    }
}
