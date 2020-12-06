using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public class InputReader
    {
        public static List<string> ReadFile(string fileName)
        {
            List<string> values = new List<string>();
            string line;

            // Read the file and display it line by line.  
            StreamReader file =
                new StreamReader(Path.Combine(".", "input", fileName));
            while ((line = file.ReadLine()) != null)
            {
                values.Add(line);
            }

            return values;
        }

        public static List<List<string>> ConvertToSeperatedInput(List<string> input)
        {
            List<List<string>> seperatedInput = new List<List<string>>();
            List<string> combinedInput = new List<string>();

            for (int i = 0; i < input.Count; i++)
            {
                var line = input[i];
                if (i != 0 && string.IsNullOrEmpty(line))
                {
                    seperatedInput.Add(combinedInput);
                    combinedInput = new List<string>();
                    continue;
                }

                combinedInput.Add(line);

                if (i + 1 == input.Count)
                {
                    seperatedInput.Add(combinedInput);
                    continue;
                }
            }
            return seperatedInput;
        }
    }
}
