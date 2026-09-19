using System;
namespace app;

class Programlabpart3
{
    static void Main()
    {
        double a = 1000;
        double b = 0.0001;
        Console.WriteLine($"Значения при типе данных double: {doublevir(a, b)} ");
        float a1 = 1000;
        float b1 = 0.0001f;
        Console.WriteLine($"Значения при типе данных float: {floatvir(a1, b1)} ");

    }
    static double doublevir(double a, double b)
    {
        return (Math.Pow(a - b, 2) - (Math.Pow(a, 2) - 2 * a * b)) / (Math.Pow(b, 2));
    }
    static double floatvir(float a, float b)
    {
        return (Math.Pow(a - b, 2) - (Math.Pow(a, 2) - 2 * a * b)) / (Math.Pow(b, 2));
    }
}

