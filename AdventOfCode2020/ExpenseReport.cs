using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class ExpenseReport
    {
        public int? Get(List<string> input, bool simple = false)
        {
            var expenses = input.Select(i => int.Parse(i)).ToList();
            var correctExpense = simple
                ? GetSimpleCorrectExpense(expenses)
                : GetCorrectExpenses(expenses);

            return correctExpense;
        }

        private int? GetSimpleCorrectExpense(List<int> expenses)
        {
            for (int firstExpense = 0; firstExpense < expenses.Count - 1; firstExpense++)
            {
                for (int secondExpense = 1; secondExpense < expenses.Count; secondExpense++)
                {
                    if (expenses[firstExpense] + expenses[secondExpense] == 2020)
                        return expenses[firstExpense] * expenses[secondExpense];
                }
            }
            return null;
        }

        private int? GetCorrectExpenses(List<int> expenses)
        {
            for (int firstExpense = 0; firstExpense < expenses.Count - 2; firstExpense++)
            {
                for (int secondExpense = 1; secondExpense < expenses.Count - 1; secondExpense++)
                {
                    for (int thirdExpense = 2; thirdExpense < expenses.Count; thirdExpense++)
                    {
                        if (expenses[firstExpense] + expenses[secondExpense] + expenses[thirdExpense] == 2020)
                            return expenses[firstExpense] * expenses[secondExpense] * expenses[thirdExpense];
                    }
                }
            }
            return null;
        }
    }
}
