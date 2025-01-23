namespace IMX.RobotWars
{
    public class Arena
    {
        public Int16 Width { get; private set; }
        public Int16 Height { get; private set; }

        private List<Position> AllocatedRobotPositions;//keep track of allocated robot positions

        public Arena(Int16 width, Int16 height)
        {
            Width = width;
            Height = height;
            AllocatedRobotPositions = new List<Position>();
        }

        public bool IsAvailablePosition(Position position)
        {
            return position.X >= 0 && position.X <= Width &&
                   position.Y >= 0 && position.Y <= Height &&
                   !AllocatedRobotPositions.Any(p => p.X == position.X && p.Y == position.Y);
        }

        public void PlaceRobot(Position position)
        {
            if (IsAvailablePosition(position))
            {
                AllocatedRobotPositions.Add(position);
            }
        }
    }
}
