using AdventOfCode2020.navigation.instructions;
using System;

namespace AdventOfCode2020.navigation
{
    public class Ferry
    {
        public Position Position { get; set; }
        public Position WayPoint { get; set; }

        public void Move(IInstruction instruction, Navigation navigation)
        {
            if (navigation == Navigation.Ferry)
            {
                Position = instruction.Move(Position);
            }
            else
            {
                MoveWithWayPoint(instruction);
            }
        }

        private void MoveWithWayPoint(IInstruction instruction)
        {
            if (instruction is MoveInstruction && ((MoveInstruction)instruction).Direction == WindDirection.NA)
            {
                Position.EastWest = Position.EastWest + (WayPoint.EastWest * ((MoveInstruction)instruction).Units);
                Position.NorthSouth = Position.NorthSouth + (WayPoint.NorthSouth * ((MoveInstruction)instruction).Units);
            }
            else if (instruction is MoveInstruction)
            {
                WayPoint = instruction.Move(WayPoint);

            }
            else if (instruction is SteeringInstruction)
            {
                RotateWayPoint((SteeringInstruction)instruction);
            }
        }

        private void RotateWayPoint(SteeringInstruction steering)
        {
            var originalNorthSouth = WayPoint.NorthSouth;
            var originalEastWest = WayPoint.EastWest;
            var counterNorthSouth = WayPoint.NorthSouth * -1;
            var counterEastWest = WayPoint.EastWest * -1;

            if (steering.Degrees == 180)
            {
                WayPoint.EastWest = counterEastWest;
                WayPoint.NorthSouth = counterNorthSouth;
            }
            else if (steering.Degrees == 90)
            {
                if (steering.Direction == RotateDirection.Right)
                {
                    WayPoint.EastWest = originalNorthSouth;
                    WayPoint.NorthSouth = counterEastWest;
                }
                else
                {
                    WayPoint.EastWest = counterNorthSouth;
                    WayPoint.NorthSouth = originalEastWest;
                }
            }
            else
            {
                if (steering.Direction == RotateDirection.Right)
                {
                    WayPoint.EastWest = counterNorthSouth;
                    WayPoint.NorthSouth = originalEastWest;
                }
                else
                {
                    WayPoint.EastWest = originalNorthSouth;
                    WayPoint.NorthSouth = counterEastWest;
                }
            }
        }

        public int GetManhattanDistance()
        {
            return Math.Abs(Position.EastWest) + Math.Abs(Position.NorthSouth);
        }
    }
}
