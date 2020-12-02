using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public abstract class BaseLogic<T> : ILogic where T : Enum
    {
        public object GetAnswer(List<string> input, int modifier)
        {
            var enumModifier = (T)Enum.ToObject(typeof(T), modifier);
            return GetAnswer(input, enumModifier);
        }

        public abstract object GetAnswer(List<string> input, T modifier);
    }
}
