using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldAssignCoordinates()
    {
        var p = new Point(7, -3);
        Assert.Equal(7, p.X);
        Assert.Equal(-3, p.Y);
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 5, 4)]
    [InlineData(5, 5, Direction.Right, 6, 5)]
    [InlineData(5, 5, Direction.Down, 5, 6)]
    [InlineData(5, 5, Direction.Left, 4, 5)]
    public void Next_ShouldMoveCorrectly(int x, int y, Direction d, int ex, int ey)
    {
        var p = new Point(x, y);
        Assert.Equal(new Point(ex, ey), p.Next(d));
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 6, 4)]
    [InlineData(5, 5, Direction.Right, 6, 4)]
    [InlineData(5, 5, Direction.Down, 4, 6)]
    [InlineData(5, 5, Direction.Left, 4, 6)]
    public void NextDiagonal_ShouldMoveCorrectly(int x, int y, Direction d, int ex, int ey)
    {
        var p = new Point(x, y);
        Assert.Equal(new Point(ex, ey), p.NextDiagonal(d));
    }

    [Fact]
    public void ToString_ShouldReturnFormattedPoint()
    {
        var p = new Point(3, 9);
        Assert.Equal("(3, 9)", p.ToString());
    }
}
