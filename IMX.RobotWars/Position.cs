namespace IMX.RobotWars
{
    public class Position
    {
        public Int16 X { get; set; }
        public Int16 Y { get; set; }
        public char Heading { get; set; }

        public Position(Int16 x, Int16 y, char heading)
        {
            X = x;
            Y = y;
            Heading = heading;
        }

        public override string ToString()
        {
            return $"{X} {Y} {Heading}";
        }
    }
}
