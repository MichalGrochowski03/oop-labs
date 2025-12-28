using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        int width = _map.SizeX;
        int height = _map.SizeY;

        char[,] cells = new char[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var objects = _map.At(x, y);
                char symbol = ' ';
                int count = 0;

                foreach (var obj in objects)
                {
                    count++;
                    if (count == 1)
                        symbol = obj.Symbol;
                    else
                    {
                        symbol = 'X';
                        break;
                    }
                }

                cells[y, x] = symbol;
            }
        }

        Console.Write(Box.TopLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < width - 1)
                Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);

        for (int y = 0; y < height; y++)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < width; x++)
            {
                Console.Write(cells[y, x]);
                if (x < width - 1)
                    Console.Write(Box.Vertical);
            }
            Console.WriteLine(Box.Vertical);

            if (y < height - 1)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < width; x++)
                {
                    Console.Write(Box.Horizontal);
                    if (x < width - 1)
                        Console.Write(Box.Cross);
                }
                Console.WriteLine(Box.MidRight);
            }
        }

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < width - 1)
                Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);
    }
}
