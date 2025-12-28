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

        List<IMappable> objects = creatures.Cast<IMappable>().ToList();

        List<Point> points = new()
        {
            new Point(2, 2),
            new Point(3, 1)
        };

        string moves = "dlrludl";

        Simulation simulation = new(map, objects, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        int turn = 1;

        while (!simulation.Finished)
        {
            Console.Clear();

            IMappable current = simulation.CurrentObject;
            string moveName = simulation.CurrentMoveName;

            Console.WriteLine($"Turn {turn}");

            if (current is Creature creature)
            {
                Point pos = creature.Position ?? new Point(0, 0);
                Console.WriteLine($"{creature} {pos} goes {moveName}:");
            }
            else
            {
                Console.WriteLine($"{current.Info} goes {moveName}:");
            }

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
