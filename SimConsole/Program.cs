using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose simulation:");
            Console.WriteLine("1 - Sim1");
            Console.WriteLine("2 - Sim2");
            Console.WriteLine("3 - Sim3 (history)");
            Console.WriteLine("0 - Exit");
            Console.Write("> ");

            string? choice = Console.ReadLine();

            if (choice == "0") return;
            if (choice == "1") Sim1();
            else if (choice == "2") Sim2();
            else if (choice == "3") Sim3();
        }
    }

    static void Run(Simulation simulation)
    {
        MapVisualizer mapVisualizer = new(simulation.Map);
        int turn = 1;

        while (!simulation.Finished)
        {
            Console.Clear();

            var current = simulation.CurrentObject;
            string moveName = simulation.CurrentMoveName;

            Console.WriteLine($"Turn {turn}");

            if (current.Position is Point pos)
                Console.WriteLine($"{current} {pos} goes {moveName}:");
            else
                Console.WriteLine($"{current} goes {moveName}:");

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
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey(true);
    }

    static void Sim1()
    {
        SmallSquareMap map = new(5);

        List<IMappable> objects = new()
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

        Simulation simulation = new(map, objects, points, moves);
        Run(simulation);
    }

    static void Sim2()
    {
        SmallTorusMap map = new(8, 6);

        List<IMappable> objects = new()
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 20 },
            new Birds { Description = "Eagles", Size = 15, CanFly = true },
            new Birds { Description = "Ostriches", Size = 120, CanFly = false }
        };

        List<Point> points = new()
        {
            new Point(1, 1),
            new Point(6, 4),
            new Point(3, 2),
            new Point(5, 1),
            new Point(2, 5)
        };

        string moves = "urdlurdlurdlurdlurdl";

        Simulation simulation = new(map, objects, points, moves);
        Run(simulation);
    }

    static void Sim3()
    {
        SmallTorusMap map = new(8, 6);

        List<IMappable> objects = new()
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 20 },
            new Birds { Description = "Eagles", Size = 15, CanFly = true },
            new Birds { Description = "Ostriches", Size = 120, CanFly = false }
        };

        List<Point> points = new()
        {
            new Point(1, 1),
            new Point(6, 4),
            new Point(3, 2),
            new Point(5, 1),
            new Point(2, 5)
        };

        string moves = "urdlurdlurdlurdlurdl";

        Simulation simulation = new(map, objects, points, moves);
        SimulationLog log = new(simulation);
        LogVisualizer vis = new(log);

        int[] turns = { 5, 10, 15, 20 };

        foreach (int t in turns)
        {
            if (t < 0 || t >= log.TurnLogs.Count)
                continue;

            Console.Clear();

            var tl = log.TurnLogs[t];
            Console.WriteLine($"Turn {t}");

            if (t == 0)
                Console.WriteLine("Start");
            else
                Console.WriteLine($"{tl.Mappable} goes {tl.Move}:");

            Console.WriteLine();
            vis.Draw(t);

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        Console.Clear();
        Console.WriteLine("Done.");
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey(true);
    }
}
