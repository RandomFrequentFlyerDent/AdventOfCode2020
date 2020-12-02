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
    }
}
