namespace Simulator.Maps
{
    public abstract class Map
    {
        public int SizeX { get; }
        public int SizeY { get; }

        private readonly Dictionary<Point, HashSet<Creature>> _creatures =
            new Dictionary<Point, HashSet<Creature>>();


        protected Map(int sizeX, int sizeY)
        {
            if (sizeX < 5)
                throw new ArgumentOutOfRangeException(nameof(sizeX),
                    "Map width must be at least 5.");

            if (sizeY < 5)
                throw new ArgumentOutOfRangeException(nameof(sizeY),
                    "Map height must be at least 5.");

            SizeX = sizeX;
            SizeY = sizeY;
        }

        /// <summary>Sprawdza, czy punkt leży na mapie.</summary>
        public bool Exist(Point p)
            => p.X >= 0 && p.X < SizeX &&
               p.Y >= 0 && p.Y < SizeY;


        public void Add(Creature creature, Point p)
        {
            if (!Exist(p))
                throw new ArgumentException("Point is outside the map.");

            if (!_creatures.TryGetValue(p, out var set))
            {
                set = new HashSet<Creature>();
                _creatures[p] = set;
            }

            set.Add(creature);
        }

        public void Remove(Creature creature, Point p)
        {
            if (_creatures.TryGetValue(p, out var set))
            {
                set.Remove(creature);

                if (set.Count == 0)
                    _creatures.Remove(p);
            }
        }

        public void Move(Creature creature, Point from, Point to)
        {
            Remove(creature, from);
            Add(creature, to);
        }

        public IEnumerable<Creature> At(Point p)
        {
            if (_creatures.TryGetValue(p, out var set))
                return set;

            return Array.Empty<Creature>();
        }

        public IEnumerable<Creature> At(int x, int y)
            => At(new Point(x, y));


        public virtual Point Next(Point p, Direction direction)
        {
            var candidate = p.Next(direction);
            return Exist(candidate) ? candidate : p;
        }

        public virtual Point NextDiagonal(Point p, Direction direction)
        {
            var candidate = p.NextDiagonal(direction);
            return Exist(candidate) ? candidate : p;
        }
    }
}