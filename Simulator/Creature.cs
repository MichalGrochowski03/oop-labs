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

    // --------------- MODYFIKACJE GO() -----------------

    public string Go(Direction direction)
        => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions)
        => directions.Select(d => Go(d)).ToArray();

    public string[] Go(string directionsString)
    {
        Direction[] dirs = DirectionParser.Parse(directionsString);
        return Go(dirs);
    }

    // --------------- Greeting -----------------

    public abstract string Greeting();

    public abstract string Info { get; }

    public override string ToString()
        => $"{GetType().Name.ToUpper()}: {Info}";

    public abstract int Power { get; }
}
