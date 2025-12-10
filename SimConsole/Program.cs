using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<Creature> creatures = new()
        {
            new Orc("Gorbag"),
            new Elf("Elandor")
        };
        List<Point> points = new()
        {
            new Point(2, 2),
            new Point(3, 1)
        };
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        int turn = 1;

        while (!simulation.Finished)
        {
            Console.Clear();

            Creature creature = simulation.CurrentCreature;
            Point pos = creature.Position ?? new Point(0, 0);
            string moveName = simulation.CurrentMoveName;

            Console.WriteLine($"Turn {turn}");
            Console.WriteLine($"{creature} {pos} goes {moveName}:");
            Console.WriteLine();

            simulation.Turn();

            mapVisualizer.Draw();

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);

            turn++;
        }

        Console.Clear();
        Console.WriteLine("Simulation finished.");
        mapVisualizer.Draw();
        Console.WriteLine();
    }
}
