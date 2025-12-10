using Simulator.Maps;

namespace Simulator
{
    using Simulator.Maps;
    using System.Collections.Generic;

    public class Simulation
    {
        /// <summary>
        /// Simulation's map.
        /// </summary>
        public Map Map { get; }

        /// <summary>
        /// Creatures moving on the map.
        /// </summary>
        public List<Creature> Creatures { get; }

        /// <summary>
        /// Starting positions of creatures.
        /// </summary>
        public List<Point> Positions { get; }

        /// <summary>
        /// Cyclic list of creatures moves (string of chars).
        /// Bad moves are ignored – invalid chars are skipped via DirectionParser.
        /// </summary>
        public string Moves { get; }

        /// <summary>
        /// Has all moves been done?
        /// </summary>
        public bool Finished = false;

        // ---- PRIVATE FIELDS ----

        private readonly Direction[] _parsedMoves;  // moves after parsing
        private int _moveIndex = 0;                 // next index in parsed moves


        // ---- PUBLIC GETTERS ----

        /// <summary>
        /// Creature which moves in current turn.
        /// </summary>
        public Creature CurrentCreature
        {
            get
            {
                int creatureIndex = _moveIndex % Creatures.Count;
                return Creatures[creatureIndex];
            }
        }

        /// <summary>
        /// Lowercase name of direction used in current turn.
        /// </summary>
        public string CurrentMoveName
        {
            get
            {
                if (_parsedMoves.Length == 0)
                    return "";

                return _parsedMoves[_moveIndex].ToString().ToLower();
            }
        }


        // ---- CONSTRUCTOR ----

        /// <summary>
        /// Simulation constructor.
        /// Throws errors:
        /// - if creatures' list is empty,
        /// - if number of creatures differs from number of positions.
        /// </summary>
        public Simulation(Map map, List<Creature> creatures,
            List<Point> positions, string moves)
        {
            if (creatures == null || creatures.Count == 0)
                throw new System.ArgumentException("Creature list cannot be empty.");

            if (creatures.Count != positions.Count)
                throw new System.ArgumentException(
                    "Number of creatures must match number of starting positions."
                );

            Map = map;
            Creatures = creatures;
            Positions = positions;
            Moves = moves ?? "";

            // Parse directions (invalid chars are ignored)
            _parsedMoves = DirectionParser.Parse(Moves);

            // Assign all creatures to map
            for (int i = 0; i < creatures.Count; i++)
                creatures[i].AssignMap(map, positions[i]);
        }


        // ---- TURN ----

        /// <summary>
        /// Makes one move of current creature in current direction.
        /// Throws error if simulation is finished.
        /// </summary>
        public void Turn()
        {
            if (Finished)
                throw new System.InvalidOperationException("Simulation already finished.");

            if (_parsedMoves.Length == 0)
            {
                Finished = true;
                return;
            }

            // Determine which creature moves now
            Creature creature = CurrentCreature;

            // Determine direction
            Direction direction = _parsedMoves[_moveIndex];

            // Move creature
            creature.Go(direction);

            // Go to next move
            _moveIndex++;

            // Check if finished
            if (_moveIndex >= _parsedMoves.Length)
                Finished = true;
        }
    }
}
