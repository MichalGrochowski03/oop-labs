namespace Simulator;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        //TestCreatures();
        //Console.WriteLine("\n");
        //TestDirections();

        //Elf e = new() { Name = "Elandor", Level = 5 };
        //Creature e = new Orc("Elandor", 5, 7);
        //Console.WriteLine(e.GetType());
        //e.SayHi();
        //e.Upgrade();
        //Console.WriteLine(e.Info);
        //if (e is Elf elf) elf.Sing();
        //else Console.WriteLine($"{e.Name} is not an ELf");

        //e.Go(Direction.Left);

        //object o = 5;
        //Console.WriteLine(o.GetType());
        //o = e;
        //Console.WriteLine(o.GetType()); o = e;        

        object s = "I am object";
        object i = 5;
        object e = new Elf() { Name = "Legolas", Agility = 3 };

        object[] objects = { s, i, e };

        foreach (var o in objects)
        {
            Console.WriteLine(o);
        }
    }


/*
    static void TestCreatures()
    {
        Creature c = new() { Name = "   Shrek    ", Level = 20 };
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("  ", -5);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("  donkey ") { Level = 7 };
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("Puss in Boots – a clever and brave cat.");
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("a                            troll name", 5);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        var a = new Animals() { Description = "   Cats " };
        Console.WriteLine(a.Info);

        a = new() { Description = "Mice           are great", Size = 40 };
        Console.WriteLine(a.Info);
    }
    static void TestDirections()
    {
        Creature c = new("Shrek", 7);
        c.SayHi();

        Console.WriteLine("\n* Up");
        c.Go(Direction.Up);

        Console.WriteLine("\n* Right, Left, Left, Down");
        Direction[] directions = {
        Direction.Right, Direction.Left, Direction.Left, Direction.Down
    };
        c.Go(directions);

        Console.WriteLine("\n* LRL");
        c.Go("LRL");

        Console.WriteLine("\n* xxxdR lyyLTyu");
        c.Go("xxxdR lyyLTyu");
    }*/
}
