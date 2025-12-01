using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldRejectFlatRectangle()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(3, 4, 3, 10));
        Assert.Throws<ArgumentException>(() => new Rectangle(3, 4, 10, 4));
    }

    [Fact]
    public void Constructor_ShouldSwapCoordinates_IfReverse()
    {
        var r = new Rectangle(10, 9, 3, 1);

        Assert.Equal(3, r.X1);
        Assert.Equal(1, r.Y1);
        Assert.Equal(10, r.X2);
        Assert.Equal(9, r.Y2);
    }

    [Theory]
    [InlineData(1, 2, 5, 6, 3, 4, true)]
    [InlineData(1, 2, 5, 6, 1, 2, true)]
    [InlineData(1, 2, 5, 6, 5, 6, true)]
    [InlineData(1, 2, 5, 6, 0, 3, false)]
    [InlineData(1, 2, 5, 6, 7, 3, false)]
    public void Contains_ShouldReturnCorrectResult(
        int x1, int y1, int x2, int y2,
        int px, int py, bool expected)
    {
        var r = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(expected, r.Contains(new Point(px, py)));
    }

    [Fact]
    public void ToString_ShouldFormatCorrectly()
    {
        var r = new Rectangle(1, 2, 5, 6);
        Assert.Equal("(1, 2):(5, 6)", r.ToString());
    }
}
