using AdventOfCode2020.navigation.instructions;
using System.Collections.Generic;

namespace AdventOfCode2020.navigation
{
    public enum Navigation { Ferry = 1, WayPoint = 2 }

    public class FerrySteering : ILogic
    {
        public object GetAnswer(List<string> input, int part)
        {
            var navigation = (Navigation)part;
            return GetDistance(input, navigation);
        }

        private int GetDistance(List<string> input, Navigation navigation)
        {
            var instructions = GetInstructions(input);
            var ferry = new Ferry
            {
                Position = new Position { NorthSouth = 0, EastWest = 0, Facing = WindDirection.East },
                WayPoint = new Position { NorthSouth = 1, EastWest = 10, Facing = WindDirection.NA }
            };
            instructions.ForEach(i => { ferry.Move(i, navigation); });
            return ferry.GetManhattanDistance();
        }

        private List<IInstruction> GetInstructions(List<string> input)
        {
            List<IInstruction> instructions = new List<IInstruction>();
            input.ForEach(i =>
            {
                IInstruction instruction;
                var instructionPart = i[0];
                var units = int.Parse(i.Substring(1));

                if (instructionPart == 'F')
                {
                    instruction = new MoveInstruction { Direction = WindDirection.NA, Units = units };
                }
                if (instructionPart == 'L' || instructionPart == 'R')
                {
                    instruction = new SteeringInstruction { Direction = instructionPart.ReadFerryDirection(), Degrees = units };
                }
                else
                {
                    instruction = new MoveInstruction { Direction = instructionPart.ReadCompass(), Units = units };
                }
                instructions.Add(instruction);
            });
            return instructions;
        }
    }
}
