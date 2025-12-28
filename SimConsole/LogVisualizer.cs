using Simulator;

namespace SimConsole;

internal class LogVisualizer
{
    private SimulationLog Log { get; }

    public LogVisualizer(SimulationLog log)
    {
        Log = log;
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= Log.TurnLogs.Count)
            throw new ArgumentOutOfRangeException(nameof(turnIndex));

        int width = Log.SizeX;
        int height = Log.SizeY;

        var turn = Log.TurnLogs[turnIndex];

        char[,] cells = new char[height, width];
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                cells[y, x] = ' ';

        foreach (var kv in turn.Symbols)
            cells[kv.Key.Y, kv.Key.X] = kv.Value;

        Console.Write(Box.TopLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < width - 1) Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);

        for (int y = 0; y < height; y++)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < width; x++)
            {
                Console.Write(cells[y, x]);
                if (x < width - 1) Console.Write(Box.Vertical);
            }
            Console.WriteLine(Box.Vertical);

            if (y < height - 1)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < width; x++)
                {
                    Console.Write(Box.Horizontal);
                    if (x < width - 1) Console.Write(Box.Cross);
                }
                Console.WriteLine(Box.MidRight);
            }
        }

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < width - 1) Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);
    }
}
