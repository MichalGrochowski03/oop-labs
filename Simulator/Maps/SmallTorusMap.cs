namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public int Size { get; }

        public SmallTorusMap(int size)
        {
            if (size < 5 || size > 20)
                throw new ArgumentOutOfRangeException(nameof(size),
                    "Size must be between 5 and 20.");

            Size = size;
        }

        public override bool Exist(Point p)
        {
            return
                p.X >= 0 && p.X < Size &&
                p.Y >= 0 && p.Y < Size;
        }

        public override Point Next(Point p, Direction d)
        {
            int x = p.X;
            int y = p.Y;

            switch (d)
            {
                case Direction.Up:
                    y += 1;
                    break;

                case Direction.Down:
                    y -= 1;
                    break;

                case Direction.Left:
                    x -= 1;
                    break;

                case Direction.Right:
                    x += 1;
                    break;
            }

            x = (x + Size) % Size;
            y = (y + Size) % Size;

            return new Point(x, y);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            int x = p.X;
            int y = p.Y;

            switch (d)
            {
                case Direction.Up:
                    x += 1;
                    y += 1;
                    break;

                case Direction.Down:
                    x -= 1;
                    y -= 1;
                    break;

                case Direction.Left:
                    x -= 1;
                    y += 1;
                    break;

                case Direction.Right:
                    x += 1;
                    y -= 1;
                    break;
            }

            x = (x + Size) % Size;
            y = (y + Size) % Size;

            return new Point(x, y);
        }
    }
}
