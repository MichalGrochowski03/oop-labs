namespace Simulator;

public class Orc : Creature
{
    private int _rage;
    private int _huntCount = 0;

    public int Rage
    {
        get => _rage;
        private set => _rage = Validator.Limiter(value, 0, 10);
    }

    public Orc() : base()
    {
        Rage = 1;
    }

    public Orc(string name = "Unknown", int level = 1, int rage = 1)
        : base(name, level)
    {
        Rage = rage;
    }

    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        _huntCount++;

        if (_huntCount % 2 == 0)
            Rage = Rage + 1;
    }

    public override void SayHi()
    {
        Console.WriteLine(
            $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}."
        );
    }

    public override int Power => 7 * Level + 3 * Rage;
}
