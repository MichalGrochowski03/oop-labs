namespace Simulator.Maps
{
    /// <summary>
    /// Mała kwadratowa mapa o wymiarach 5–20.
    /// Logika ruchu pochodzi z klasy bazowej Map.
    /// </summary>
    public class SmallSquareMap : Map
    {
        public int Size => SizeX;

        public SmallSquareMap(int size)
            : base(size, size)
        {
            if (size > 20)
                throw new ArgumentOutOfRangeException(nameof(size),
                    "SmallSquareMap supports sizes up to 20.");
        }
    }
}
