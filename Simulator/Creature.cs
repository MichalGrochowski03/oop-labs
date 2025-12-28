using Simulator.Maps;

namespace Simulator
{
    public abstract class Creature : IMappable
    {
        private string _name = "";
        private int _level;

        public string Name
        {
            get => _name;
            init => _name = Validator.Shortener(value, 3, 25, '#');
        }

        public int Level
        {
            get => _level;
            init => _level = Validator.Limiter(value, 1, 10);
        }

        public Map? CurrentMap { get; private set; }
        public Point? Position { get; private set; }

        protected Creature()
        {
            Name = "Unknown";
            Level = 1;
        }

        protected Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }

        public void Upgrade()
        {
            _level = Validator.Limiter(Level + 1, 1, 10);
        }

        public virtual void Go(Direction direction)
        {
            if (CurrentMap == null || Position == null)
                return;

            var from = Position.Value;
            var to = CurrentMap.Next(from, direction);

            CurrentMap.Move(this, from, to);
            Position = to;
        }

        public virtual void AssignMap(Map map, Point start)
        {
            if (CurrentMap != null)
                throw new InvalidOperationException("Creature is already assigned to a map.");

            if (!map.Exist(start))
                throw new ArgumentException("Start position is outside the map.");

            map.Add(this, start);

            CurrentMap = map;
            Position = start;
        }

        public abstract string Greeting();
        public abstract string Info { get; }

        public virtual char Symbol => '?';

        public override string ToString()
            => $"{GetType().Name.ToUpper()}: {Info}";

        public abstract int Power { get; }
    }
}
