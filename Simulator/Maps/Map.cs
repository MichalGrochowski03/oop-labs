using Simulator;

namespace Simulator.Maps
{
    public abstract class Map
    {
        public int SizeX { get; }
        public int SizeY { get; }

        private readonly Dictionary<Point, HashSet<IMappable>> _objects =
            new Dictionary<Point, HashSet<IMappable>>();

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

        public void Add(IMappable obj, Point p)
        {
            if (!Exist(p))
                throw new ArgumentException("Point is outside the map.");

            if (!_objects.TryGetValue(p, out var set))
            {
                set = new HashSet<IMappable>();
                _objects[p] = set;
            }

            set.Add(obj);
        }

        public void Remove(IMappable obj, Point p)
        {
            if (_objects.TryGetValue(p, out var set))
            {
                set.Remove(obj);

                if (set.Count == 0)
                    _objects.Remove(p);
            }
        }

        public void Move(IMappable obj, Point from, Point to)
        {
            Remove(obj, from);
            Add(obj, to);
        }

        public IEnumerable<IMappable> At(Point p)
        {
            if (_objects.TryGetValue(p, out var set))
                return set;

            return Array.Empty<IMappable>();
        }

        public IEnumerable<IMappable> At(int x, int y)
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
