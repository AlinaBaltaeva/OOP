using System;
namespace app;

public class Firstlab
{
    static void Main()
    {
        Firstpoint();
        Secondpoint();
        Thirdpoint();
        Fourthpoint();

    }
    static void Firstpoint()
    {
        Console.WriteLine("Первая задача пункт 1");
        try
        {
            Console.Write("Введите значения m и n: ");
            decimal m = Convert.ToDecimal(Console.ReadLine());
            decimal n = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine($"1-ый пункт: {++n*++m}");
        }
        catch
        {
            Console.WriteLine("Неверно введен тип данных");
        }
    }
    static void Secondpoint()
    {
        Console.WriteLine("Первая задача пункт 2");
        try
        {
            Console.Write("Введите значения m и n: ");
            decimal m = Convert.ToDecimal(Console.ReadLine());
            decimal n = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine(m++<n);
        }
        catch
        {
            Console.WriteLine("Неверно введен тип данных");
        }
    }
    static void Thirdpoint()
    {
        Console.WriteLine("Первая задача пункт 3");
        try
        {
            Console.Write("Введите значения m и n: ");
            decimal m = Convert.ToDecimal(Console.ReadLine() as string);
            decimal n = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine(++n>m);
        }
        catch
        {
            Console.WriteLine("Неверно введен тип данных");
        }
    } 
    static void Fourthpoint()
    {
        Console.WriteLine("Первая задача пункт 4");
        try
        {
            Console.Write("Введите значения x: ");
            decimal x = Convert.ToDecimal(Console.ReadLine());
            if (x * x + x >= 0)
            {
                double f = Convert.ToDouble(x);
                double f1 = f + 1/(Math.Pow(f, 3) - f) - 2;
                Console.WriteLine($"4-ый пункт:{f1}");
            }
            else
            {
                Console.WriteLine("Некорректно введены данные для X!");
            }
        }
        catch
        {
            Console.WriteLine("Неверно введен тип данных");
        }
    }
}
