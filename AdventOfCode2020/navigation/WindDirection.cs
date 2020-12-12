namespace AdventOfCode2020.navigation
{
    public enum RotateDirection { Left, Right, Unknown = 999 }
    public enum WindDirection
    {
        North = 0,
        East = 90,
        South = 180,
        West = 270,
        NA = 999
    }

    public static class WindDirectionExtensions
    {
        public static Position Move(this WindDirection compass, Position position, int units, bool forwwards)
        {
            WindDirection moveOn = forwwards ? position.Facing : compass;

            var moved = new Position
            {
                NorthSouth = position.NorthSouth,
                EastWest = position.EastWest,
                Facing = forwwards ? compass : position.Facing
            };

            switch (moveOn)
            {
                case WindDirection.North:
                    moved.NorthSouth += units;
                    break;
                case WindDirection.South:
                    moved.NorthSouth -= units;
                    break;
                case WindDirection.East:
                    moved.EastWest += units;
                    break;
                case WindDirection.West:
                    moved.EastWest -= units;
                    break;
                default:
                    break;
            }
            return moved;
        }

        public static WindDirection ChangeDirection(this WindDirection compass, RotateDirection direction, int degrees)
        {
            var degree = direction == RotateDirection.Right ? (int)compass + degrees : (int)compass - degrees;
            if (degree >= 360)
                degree -= 360;
            if (degree < 0)
                degree += 360;
            return (WindDirection)degree;
        }
    }
}
