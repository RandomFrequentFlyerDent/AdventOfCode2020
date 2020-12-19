using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.homework
{
    public class MathHomework : ILogic
    {
        public object GetAnswer(List<string> input, int part)
        {
            var answer = part == 1
                ? Calculate(input)
                : AdvancedCalculate(input);
            return answer;
        }

        private long Calculate(List<string> input)
        {
            return input.Select(i => new MathInput(i)).Select(m => m.Calculate()).Sum();
        }

        private long AdvancedCalculate(List<string> input)
        {
            return input.Select(i => new MathInput(i)).Select(m => m.AdvancedPerform()).Sum();
        }
    }

    public class MathInput
    {
        private List<object> _input = new List<object>();
        public MathInput(string input)
        {
            foreach (var c in input.ToList())
            {
                if (c == ' ')
                    continue;
                if (c == '(' || c == ')')
                {
                    _input.Add(c);
                    continue;
                }
                if (c == '+')
                {
                    _input.Add(Operator.Addition);
                    continue;
                }
                if (c == '*')
                {
                    _input.Add(Operator.Multiply);
                    continue;
                }
                _input.Add(long.Parse(c.ToString()));
            }
        }

        public long Calculate()
        {
            if (_input.LastIndexOf('(') != -1)
            {
                var processingParentheses = true;
                while (processingParentheses)
                {
                    var lastOpeningParentheses = _input.LastIndexOf('(');
                    if (lastOpeningParentheses != -1)
                    {
                        for (int i = lastOpeningParentheses + 1; i < lastOpeningParentheses + 2; i++)
                        {
                            PerformOperation(i + 1);
                            if (_input.IndexOf(')', lastOpeningParentheses) > lastOpeningParentheses + 2)
                            {
                                i = lastOpeningParentheses + 1;
                            }
                            else
                            {
                                _input.RemoveAt(_input.IndexOf(')', lastOpeningParentheses));
                                _input.RemoveAt(lastOpeningParentheses);
                            }
                        }
                    }
                    else
                    {
                        processingParentheses = false;
                    }
                }
            }

            for (int i = 0; i < 1; i++)
            {
                PerformOperation(i + 1);
                if (_input.Count > 1)
                    i = -1;
            }
            return (long)_input[0];
        }

        private void PerformOperation(int operatorIndex)
        {
            Operator mathOperator = (Operator)_input[operatorIndex];
            _input[operatorIndex + 1] = mathOperator.Perform((long)_input[operatorIndex - 1], (long)_input[operatorIndex + 1]);
            _input.RemoveRange(operatorIndex - 1, 2);
        }

        public long AdvancedPerform()
        {
            if (_input.LastIndexOf('(') != -1)
            {
                var processingParentheses = true;
                while (processingParentheses)
                {
                    var lastOpeningParentheses = _input.LastIndexOf('(');
                    if (lastOpeningParentheses != -1)
                    {
                        var matchingParentheses = _input.IndexOf(')', lastOpeningParentheses);
                        while (_input.IndexOf(Operator.Addition, lastOpeningParentheses, matchingParentheses - lastOpeningParentheses) != -1)
                        {
                            var addIndex = _input.IndexOf(Operator.Addition, lastOpeningParentheses, matchingParentheses - lastOpeningParentheses);
                            PerformOperation(addIndex);
                            matchingParentheses = _input.IndexOf(')', lastOpeningParentheses);
                        }
                        if (_input.IndexOf(')', lastOpeningParentheses) == lastOpeningParentheses + 2)
                        {
                            _input.RemoveAt(_input.IndexOf(')', lastOpeningParentheses));
                            _input.RemoveAt(lastOpeningParentheses);
                            continue;
                        }
                        for (int i = lastOpeningParentheses + 1; i < lastOpeningParentheses + 2; i++)
                        {

                            PerformOperation(i + 1);
                            if (_input.IndexOf(')', lastOpeningParentheses) > lastOpeningParentheses + 2)
                            {
                                i = lastOpeningParentheses + 1;
                            }
                            else
                            {
                                _input.RemoveAt(_input.IndexOf(')', lastOpeningParentheses));
                                _input.RemoveAt(lastOpeningParentheses);
                            }
                        }
                    }
                    else
                    {
                        processingParentheses = false;
                    }
                }
            }

            while (_input.IndexOf(Operator.Addition) != -1)
            {
                var addIndex = _input.IndexOf(Operator.Addition);
                PerformOperation(addIndex);
            }

            if (_input.Count > 1)
            {
                for (int i = 0; i < 1; i++)
                {
                    PerformOperation(i + 1);
                    if (_input.Count > 1)
                        i = -1;
                }
            }

            return (long)_input[0];
        }
    }

    public enum Operator { Multiply, Addition }

    public static class OperatorExtensions
    {
        public static long Perform(this Operator mathOperator, long a, long b)
        {
            if (mathOperator == Operator.Addition)
                return a + b;
            return a * b;
        }
    }
}
