namespace Simulator;

public abstract class Creature
{
    private string _name = "";
    private int _level;

    public string Name
    {
        get => _name;
        init => _name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => _level;
        init => _level = Validator.Limiter(value, 1, 10);
    }

    public Creature()
    {
        Name = "Unknown";
        Level = 1;
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public void Upgrade()
    {
        _level = Validator.Limiter(Level + 1, 1, 10);
    }


    public void Go(Direction direction)
    {
        string lowerDirection = direction.ToString().ToLower();

        Console.WriteLine($"{Name} goes {lowerDirection}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (Direction direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directionsString)
    {
        Direction[] directions = DirectionParser.Parse(directionsString);
        Go(directions);
    }

    public abstract void SayHi();


    public abstract string Info { get; }
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    public abstract int Power { get; }


}
