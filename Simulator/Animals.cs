using Simulator.Maps;

namespace Simulator
{
    public class Animals : IMappable
    {
        private string _description = "";
        private int _size;

        public string Description
        {
            get => _description;
            set => _description = Validator.Shortener(value, 3, 25, '#');
        }

        public int Size
        {
            get => _size;
            set => _size = Validator.Limiter(value, 1, 5000);
        }

        public Map? CurrentMap { get; protected set; }
        public Point? Position { get; protected set; }

        public Animals()
        {
            Description = "Unknown";
            Size = 3;
        }

        public virtual string Info => $"{Description} <{Size}>";

        public virtual char Symbol => 'A';

        public virtual void AssignMap(Map map, Point start)
        {
            if (CurrentMap != null)
                throw new InvalidOperationException("Animal is already assigned to a map.");

            if (!map.Exist(start))
                throw new ArgumentException("Start position is outside the map.");

            map.Add(this, start);

            CurrentMap = map;
            Position = start;
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

        public override string ToString()
            => $"{GetType().Name.ToUpper()}: {Info}";
    }
}
