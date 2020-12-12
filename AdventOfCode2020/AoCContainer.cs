using System;

namespace AdventOfCode2020
{
    public class AoCContainer
    {
        private readonly Logic _logic = new Logic();

        public void GetAnswer()
        {
            (ILogic logic, int day) = GetDayAndLogic();
            var part = GetPart();
            var result = logic.GetAnswer(InputReader.ReadFile($"day{day}.txt"), part);
            Console.WriteLine($"Answer: {result}");
            AskAgain();
        }

        private (ILogic, int) GetDayAndLogic()
        {
            do
            {
                Console.Write("Day: ");
                if (int.TryParse(Console.ReadLine(), out int day))
                {
                    try
                    {
                        var logic = _logic[day];
                        return (logic, day);
                    }
                    catch (NotImplementedException)
                    {
                        Console.WriteLine($"Day {day} has not been implemented yet");
                    }
                }
            } while (true);
        }

        private int GetPart()
        {
            do
            {
                Console.Write("Part: ");
                if (int.TryParse(Console.ReadLine(), out int part))
                {
                    if (part == 1 || part == 2)
                        return part;
                }
            } while (true);
        }

        private void AskAgain()
        {
            var again = false;
            var unanswered = true;
            do
            {
                Console.Write("Quit [y/n]: ");
                var read = Console.ReadLine();
                if (read == "y" || read == "n")
                {
                    again = read == "n";
                    unanswered = false;
                }
            } while (unanswered);

            if (again)
                GetAnswer();
        }
    }
}
