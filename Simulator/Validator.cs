namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        string s = (value ?? "").Trim();

        if (s.Length > max)
            s = s.Substring(0, max).TrimEnd();

        if (s.Length < min)
            s = s.PadRight(min, placeholder);

        if (s.Length > 0 && char.IsLower(s[0]))
            s = char.ToUpper(s[0]) + s.Substring(1);

        return s;
    }
}
