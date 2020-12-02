using System;

namespace AdventOfCode2020
{
    public class AoCContainer
    {
        private ILogic GetLogic(int day)
        {
            return day switch
            {
                1 => new ExpenseReport(),
                2 => new DatabaseChecker(),
                _ => null,
            };
        }

        public void GetAnswer()
        {
            ILogic logic = null;

            var implementedDay = false;
            int day;
            do
            {
                Console.Write("Day: ");
                if (!int.TryParse(Console.ReadLine(), out day))
                {
                    Console.WriteLine("That's not an integer number, now is it?");
                    continue;
                }

                logic = GetLogic(day);
                if (logic == null)
                {
                    Console.WriteLine($"Day {day} has not been implemented yet");
                    continue;
                }

                implementedDay = true;
            } while (!implementedDay);

            var validatedPart = false;
            int part;
            do
            {
                Console.Write("Part: ");
                if (!int.TryParse(Console.ReadLine(), out part))
                {
                    Console.WriteLine("That's not an integer number, now is it?");
                    continue;
                }

                if (part != 1 && part != 2)
                {
                    Console.WriteLine($"Part {part} is not a valid day part, choose 1 or 2");
                    continue;
                }

                validatedPart = true;
            } while (!validatedPart);

            var result = logic.GetAnswer(InputReader.ReadFile($"day{day}.txt"), part);
            Console.WriteLine($"Answer: {result}");
        }
    }
}
