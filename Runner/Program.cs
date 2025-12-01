using Simulator;
using Simulator.Maps;

namespace Runner;
internal class Program
{
    static void Main(string[] args)
    {

       // TestObjectsToString();
       // TestValidators();
       // TestMovement();

        Point p = new(10, 25);
        Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
        Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)

    }

    static void TestObjectsToString()
    {
        object[] myObjects = {
            new Animals() { Description = "dogs"},
            new Birds { Description = "  eagles ", Size = 10 },
            new Elf("e", 15, -3),
            new Orc("morgash", 6, 4)
        };

        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects)
            Console.WriteLine(o);


    }



    static void TestValidators()
    {
        Console.WriteLine("\nHUNT TEST\n");
        var o = new Orc("Gorbag", rage: 7);
        Console.WriteLine(o.Greeting());

        for (int i = 0; i < 5; i++)  
        {
            o.Hunt();
            Console.WriteLine(o.Greeting());
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        Console.WriteLine(e.Greeting());

        for (int i = 0; i < 5; i++)
        {
            e.Sing();
            Console.WriteLine(e.Greeting());
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures =
        {
            o,
            e,
            new Orc("Morgash", 3, 8),
            new Elf("Elandor", 5, 3)
        };

        foreach (Creature c in creatures)
            Console.WriteLine($"{c.Name,-15}: {c.Power}");
    }

    static void TestMovement()
    {
        Console.WriteLine("\nMOVEMENT TEST\n");

        Creature c = new Elf("Alya", 3, 4);

        // Go(Direction)
        Console.WriteLine("Single step:");
        Console.WriteLine(c.Go(Direction.Up));

        // Go(Direction[])
        Console.WriteLine("Multiple steps:");
        var result = c.Go(new[] { Direction.Left, Direction.Down, Direction.Right });
        Console.WriteLine(string.Join(", ", result));

        // Go(string)
        Console.WriteLine("String input:");
        var result2 = c.Go("udlr");
        Console.WriteLine(string.Join(", ", result2));
    }


}