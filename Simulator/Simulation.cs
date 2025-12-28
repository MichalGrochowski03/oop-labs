using Simulator.Maps;

namespace Simulator
{
    public class Simulation
    {
        public Map Map { get; }
        public List<IMappable> Objects { get; }
        public List<Point> Positions { get; }
        public string Moves { get; }
        public bool Finished { get; private set; } = false;

        private readonly Direction[] _parsedMoves;
        private int _moveIndex = 0;

        public IMappable CurrentObject
        {
            get
            {
                int index = _moveIndex % Objects.Count;
                return Objects[index];
            }
        }

        public string CurrentMoveName
        {
            get
            {
                if (_parsedMoves.Length == 0)
                    return "";

                return _parsedMoves[_moveIndex].ToString().ToLower();
            }
        }

        public Simulation(Map map, List<IMappable> objects, List<Point> positions, string moves)
        {
            if (objects == null || objects.Count == 0)
                throw new ArgumentException("Object list cannot be empty.");

            if (objects.Count != positions.Count)
                throw new ArgumentException("Number of objects must match number of starting positions.");

            Map = map;
            Objects = objects;
            Positions = positions;
            Moves = moves ?? "";

            _parsedMoves = DirectionParser.Parse(Moves);

            for (int i = 0; i < objects.Count; i++)
                objects[i].AssignMap(map, positions[i]);
        }

        public void Turn()
        {
            if (Finished)
                throw new InvalidOperationException("Simulation already finished.");

            if (_parsedMoves.Length == 0)
            {
                Finished = true;
                return;
            }

            IMappable obj = CurrentObject;
            Direction direction = _parsedMoves[_moveIndex];

            obj.Go(direction);

            _moveIndex++;

            if (_moveIndex >= _parsedMoves.Length)
                Finished = true;
        }
    }
}
