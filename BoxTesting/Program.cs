namespace BoxTesting;
using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int size = 1_000_000;

       
        int[] source = new int[size];
        Random rand = new Random();
        for (int i = 0; i < size; i++)
            source[i] = rand.Next();

        int[] destInt = new int[size];
        object[] destObj = new object[size];

        Stopwatch sw = new Stopwatch();

        
        sw.Start();
        for (int i = 0; i < size; i++)
            destInt[i] = source[i];
        sw.Stop();
        Console.WriteLine("Czas kopiowania do int[]: " + sw.ElapsedMilliseconds + " ms");

       
        sw.Restart();
        for (int i = 0; i < size; i++)
            destObj[i] = source[i]; 
        sw.Stop();
        Console.WriteLine("Czas kopiowania do object[]: " + sw.ElapsedMilliseconds + " ms");
    }
}
