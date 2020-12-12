using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.trajectory
{
    public class RoutePlanner : BaseLogic<RouteType>
    {
        public override object GetAnswer(List<string> input, RouteType routeType)
        {
            var numberOfTrees = routeType == RouteType.Simple
                ? GetNumberOfTreesEncountered(GetFullMountain(input, 1, 3), 1, 3)
                : GetTreesFromMultiplePasses(input, new (int, int)[] { (1, 1), (1, 3), (1, 5), (1, 7), (2, 1) });

            return numberOfTrees;
        }

        private List<string> GetFullMountain(List<string> input, int slopeDescent, int angle)
        {
            var widthSlope = input[0].Length;
            var numberOfSlopes = input.Count / slopeDescent;
            var necessaryWidth = numberOfSlopes * angle;
            var fullMountain = input.Select(i => string.Concat(Enumerable.Repeat(i, (necessaryWidth / widthSlope) + 1))).ToList();
            return fullMountain;
        }

        private long GetNumberOfTreesEncountered(List<string> input, int slopeDescent, int angle)
        {
            var numberOfTrees = 0;
            var slidingAngle = angle;
            for (int slope = slopeDescent; slope < input.Count; slope+=slopeDescent)
            {
                var space = input[slope][slidingAngle];
                if (space == '#')
                    numberOfTrees++;
                slidingAngle += angle;
            }
            return numberOfTrees;
        }

        private long GetTreesFromMultiplePasses(List<string> input, (int slope, int angle)[] passes)
        {
            var trees = passes.Select(p => GetNumberOfTreesEncountered(GetFullMountain(input, p.slope, p.angle), p.slope, p.angle)).ToList();
            return trees.Aggregate((x, y) => x * y);
        }
    }
}
