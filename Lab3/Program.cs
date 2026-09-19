class lab3
{
    static double Func(double x)
    {
        double y = -Math.Log(Math.Abs(2 * Math.Sin(x / 2)));
        return y;
    }
    static double Summ(double x, int n)
    {
        double s = Math.Cos(n * x) / n;
        return s;
    }
    static void Main()
    {
        double e = 0.0001;
        Console.WriteLine("Введите значения для функций и ряда:");
        Console.WriteLine("Введите значения для функции параметр умножается на Pi/5, Pi/5 <= x <= 9*Pi/5");
        double x = Convert.ToDouble(Console.ReadLine());
        if (x > 9 || x < 1)
            Console.WriteLine("Неверно введен параметр");
        double x1 = (Math.PI * x) / 5;
        double Function1 = Func(x1);
        Console.WriteLine($"Значение функции{Function1}");
        Console.WriteLine("Введите значение n:");
        int n = Convert.ToInt32(Console.ReadLine());
        double result = 0;
        double resultold = 0;
        for(int i = 1; i <= n; i++)
        {
            resultold = result;
            result += Summ(x1, i);
            if (Math.Abs(result - resultold) < e)
            {
                Console.WriteLine("Итерации закончены, т.к. значения меньше точности");
                break;
            }   
        }
        Console.WriteLine(result);
    }
}
