namespace Simulator.Maps;

public interface IMappable
{
    string Info { get; }
    char Symbol { get; }

    Map? CurrentMap { get; }
    Point? Position { get; }

    void AssignMap(Map map, Point start);
    void Go(Direction direction);

    string ToString();
}
