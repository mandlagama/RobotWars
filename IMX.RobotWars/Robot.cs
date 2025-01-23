namespace IMX.RobotWars
{
    public class Robot
    {
        private Position _currentPosition;
        private Int16 _arenaWidth;
        private Int16 _arenaHeight;

        public Robot(Arena arena, Position initialPosition)
        {
            _arenaWidth = arena.Width;
            _arenaHeight = arena.Height;
            _currentPosition = new Position(initialPosition.X, initialPosition.Y, initialPosition.Heading);
        }

        public void ProcessCommands(string instructions)
        {
            foreach (char instruction in instructions)
            {
                switch (instruction)
                {
                    case 'L':
                        SpinLeft();
                        break;
                    case 'R':
                        SpinRight();
                        break;
                    case 'M':
                        Move();
                        break;
                }
            }
        }

        private void SpinLeft()
        {
            _currentPosition.Heading = _currentPosition.Heading switch
            {
                'N' => 'W',
                'W' => 'S',
                'S' => 'E',
                'E' => 'N',
                _ => _currentPosition.Heading
            };
        }

        private void SpinRight()
        {
            _currentPosition.Heading = _currentPosition.Heading switch
            {
                'N' => 'E',
                'E' => 'S',
                'S' => 'W',
                'W' => 'N',
                _ => _currentPosition.Heading
            };
        }

        private void Move()
        {
            switch (_currentPosition.Heading)
            {
                case 'N':
                    if (_currentPosition.Y < _arenaHeight)
                        _currentPosition.Y++;
                    break;
                case 'S':
                    if (_currentPosition.Y > 0)
                        _currentPosition.Y--;
                    break;
                case 'E':
                    if (_currentPosition.X < _arenaWidth)
                        _currentPosition.X++;
                    break;
                case 'W':
                    if (_currentPosition.X > 0)
                        _currentPosition.X--;
                    break;
            }
        }

        public Position GetPosition()
        {
            return _currentPosition;
        }
    }
}
