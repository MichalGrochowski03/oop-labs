using Simulator.Maps;

namespace Simulator;

public class SimulationLog
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<TurnLog> TurnLogs { get; } = [];

    public SimulationLog(Simulation simulation)
    {
        _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        TurnLogs.Add(new TurnLog
        {
            Mappable = "",
            Move = "",
            Symbols = SnapshotSymbols(_simulation.Map, SizeX, SizeY)
        });

        while (!_simulation.Finished)
        {
            string mappable = _simulation.CurrentObject.ToString();
            string move = _simulation.CurrentMoveName;

            _simulation.Turn();

            TurnLogs.Add(new TurnLog
            {
                Mappable = mappable,
                Move = move,
                Symbols = SnapshotSymbols(_simulation.Map, SizeX, SizeY)
            });
        }
    }

    private static Dictionary<Point, char> SnapshotSymbols(Map map, int sizeX, int sizeY)
    {
        Dictionary<Point, char> result = new();

        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                int count = 0;
                char symbol = ' ';

                foreach (var obj in map.At(x, y))
                {
                    count++;
                    if (count == 1) symbol = obj.Symbol;
                    else { symbol = 'X'; break; }
                }

                if (count > 0)
                    result[new Point(x, y)] = symbol;
            }
        }

        return result;
    }
}

public class TurnLog
{
    public required string Mappable { get; init; }
    public required string Move { get; init; }
    public required Dictionary<Point, char> Symbols { get; init; }
}
