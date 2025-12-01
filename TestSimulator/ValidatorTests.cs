using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(0, 1, 10, 1)]
    [InlineData(11, 1, 10, 10)]
    public void Limiter_ShouldClampValues(int value, int min, int max, int expected)
    {
        Assert.Equal(expected, Validator.Limiter(value, min, max));
    }

    [Theory]
    [InlineData("hello", 3, 10, '#', "Hello")]
    [InlineData("  abc  ", 3, 10, '#', "Abc")]
    [InlineData("abcdefghiXYZ", 3, 5, '#', "Abcde")]
    [InlineData("xy", 3, 5, '_', "Xy_")]
    [InlineData("", 3, 5, '_', "___")]
    public void Shortener_ShouldWorkCorrectly(string input, int min, int max, char fill, string expected)
    {
        Assert.Equal(expected, Validator.Shortener(input, min, max, fill));
    }
}
