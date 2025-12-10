namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public int Size => SizeX;

        public SmallTorusMap(int size)
            : this(size, size)
        {
        }

        public SmallTorusMap(int sizeX, int sizeY)
            : base(sizeX, sizeY)
        {
            if (sizeX > 20)
                throw new ArgumentOutOfRangeException(nameof(sizeX));
            if (sizeY > 20)
                throw new ArgumentOutOfRangeException(nameof(sizeY));
        }

        private Point Wrap(int x, int y)
        {
            int nx = ((x % SizeX) + SizeX) % SizeX;
            int ny = ((y % SizeY) + SizeY) % SizeY;
            return new Point(nx, ny);
        }

        public override Point Next(Point p, Direction direction)
        {
            return direction switch
            {
                Direction.Up => Wrap(p.X, p.Y + 1),
                Direction.Right => Wrap(p.X + 1, p.Y),
                Direction.Down => Wrap(p.X, p.Y - 1),
                Direction.Left => Wrap(p.X - 1, p.Y),
                _ => p
            };
        }

        public override Point NextDiagonal(Point p, Direction direction)
        {
            return direction switch
            {
                Direction.Up => Wrap(p.X + 1, p.Y + 1),
                Direction.Right => Wrap(p.X + 1, p.Y - 1),
                Direction.Down => Wrap(p.X - 1, p.Y - 1),
                Direction.Left => Wrap(p.X - 1, p.Y + 1),
                _ => p
            };
        }
    }
}
