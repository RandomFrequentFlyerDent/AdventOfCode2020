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
                : 2;
            return answer;
        }

        private long Calculate(List<string> input)
        {
            return input.Select(i => new MathInput(i)).Select(m => m.Calculate()).Sum();
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
            var processingParentheses = true;
            if (_input.LastIndexOf('(') != -1)
            {
                while (processingParentheses)
                {
                    var lastOpeningParentheses = _input.LastIndexOf('(');
                    if (lastOpeningParentheses != -1)
                    {
                        for (int i = lastOpeningParentheses + 1; i < lastOpeningParentheses + 2; i++)
                        {
                            var mathOperator = (Operator)_input[i + 1];
                            _input[i + 2] = mathOperator.Perform((long)_input[i], (long)_input[i + 2]);
                            _input.RemoveRange(i, 2);
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
                Operator mathOperator = (Operator)_input[i + 1];
                _input[i + 2] = mathOperator.Perform((long)_input[i], (long)_input[i + 2]);
                _input.RemoveRange(i, 2);
                if (_input.Count > 1)
                    i = -1;
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
