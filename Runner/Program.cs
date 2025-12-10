using Simulator;
using Simulator.Maps;

namespace Runner;
internal class Program
{
    static void Main(string[] args)
    {
        // Przykładowe testy ruchu po mapie:

        var map = new SmallSquareMap(10);
        var elf = new Elf("Alya", 3, 4);

        elf.AssignMap(map, new Point(5, 5));

        Console.WriteLine("Start:");
        Console.WriteLine($"{elf.Name} at {elf.Position}");

        elf.Go(Direction.Up);
        Console.WriteLine($"After Up:    {elf.Position}");

        elf.Go(Direction.Left);
        Console.WriteLine($"After Left:  {elf.Position}");

        elf.Go(Direction.Down);
        Console.WriteLine($"After Down:  {elf.Position}");

        elf.Go(Direction.Right);
        Console.WriteLine($"After Right: {elf.Position}");

        // Test mapy torusowej
        Console.WriteLine("\nTORUS TEST");
        var torus = new SmallTorusMap(5);
        var orc = new Orc("Gorbag", 2, 3);

        orc.AssignMap(torus, new Point(0, 0));

        Console.WriteLine($"Start: {orc.Position}");
        orc.Go(Direction.Left);   // powinno owinąć
        Console.WriteLine($"Left wrap: {orc.Position}");
        orc.Go(Direction.Up);     // powinno owinąć
        Console.WriteLine($"Up wrap:   {orc.Position}");
    }
}
