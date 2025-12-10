using Simulator.Maps;

namespace Simulator
{
    public class Simulation
    {
        public Map Map { get; }

        public List<Creature> Creatures { get; }

        public List<Point> Positions { get; }

        public string Moves { get; }

        public bool Finished = false;

        private readonly Direction[] _parsedMoves;
        private int _moveIndex = 0;

        public Creature CurrentCreature
        {
            get
            {
                int index = _moveIndex % Creatures.Count;
                return Creatures[index];
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

        public Simulation(Map map, List<Creature> creatures,
            List<Point> positions, string moves)
        {
            if (creatures == null || creatures.Count == 0)
                throw new ArgumentException("Creature list cannot be empty.");

            if (creatures.Count != positions.Count)
                throw new ArgumentException(
                    "Number of creatures must match number of starting positions.");

            Map = map;
            Creatures = creatures;
            Positions = positions;
            Moves = moves ?? "";

            _parsedMoves = DirectionParser.Parse(Moves);

            for (int i = 0; i < creatures.Count; i++)
                creatures[i].AssignMap(map, positions[i]);
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

            Creature creature = CurrentCreature;
            Direction direction = _parsedMoves[_moveIndex];

            creature.Go(direction);

            _moveIndex++;

            if (_moveIndex >= _parsedMoves.Length)
                Finished = true;
        }
    }
}