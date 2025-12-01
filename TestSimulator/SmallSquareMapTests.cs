using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    public void Constructor_ValidSize_ShouldSetSize(int size)
    {
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrow(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(0, 0, 10, true)]
    [InlineData(9, 9, 10, true)]
    [InlineData(-1, 5, 10, false)]
    [InlineData(5, 10, 10, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        var map = new SmallSquareMap(size);
        Assert.Equal(expected, map.Exist(new Point(x, y)));
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 5, 4)]
    [InlineData(5, 0, Direction.Up, 5, 0)]  // border stop
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(9, 9, Direction.Right, 9, 9)]
    public void Next_ShouldStopAtBorders(int x, int y, Direction dir, int ex, int ey)
    {
        var map = new SmallSquareMap(10);
        var p = new Point(x, y);
        var next = map.Next(p, dir);
        Assert.Equal(new Point(ex, ey), next);
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 6, 4)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    public void NextDiagonal_ShouldStopAtBorders(int x, int y, Direction dir, int ex, int ey)
    {
        var map = new SmallSquareMap(10);
        var p = new Point(x, y);
        var next = map.NextDiagonal(p, dir);
        Assert.Equal(new Point(ex, ey), next);
    }
}
