using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab14
{
    class Program
    {
        static void Print<T>(string title, IEnumerable<T> items)
        {
            Console.WriteLine(title);
            foreach (T item in items) Console.WriteLine("  " + item);
        }
        //Создаем alias и можно выполнять запросы прям как в обычном sql
        static void PrintSets(string title, (List<string> Union, List<string> Except, List<string> Intersect) r)
        {
            Console.WriteLine(title);
            Console.WriteLine(" LINQ Union: " + string.Join(", ", r.Union));
            Console.WriteLine(" LINQ Except: " + string.Join(", ", r.Except));
            Console.WriteLine(" LINQ Intersect: " + string.Join(", ", r.Intersect));
        }

        static void PrintAgg(string title, (double Sum, double Max, double Min, double Average) r)
        {
            Console.WriteLine($"{title}: Sum={r.Sum:F1}, Max={r.Max:F1}, Min={r.Min:F1}, Average={r.Average:F2}");
        }

        static long Measure(Action action)//нужно для сравнения, будем вызывать информацию о студенте 3 разными способами
                                          //и увидим разницу
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 100; i++) action();
            sw.Stop();
            return sw.ElapsedTicks;
        }

        static void Main()
        {
            Console.WriteLine("ЧАСТЬ 1");
            var u = Data.CreateSmall();

            Print("Where (LINQ), студенты 2 курса:", Queries.WhereLinq(u, 2));
            Print("Where (методы), студенты 2 курса:", Queries.WhereExt(u, 2));
            Print("Where (for), студенты 2 курса:", Queries.WhereFor(u, 2));

            PrintSets("Множества (LINQ), факультет 1 и 2:", Queries.SetsLinq(u));
            PrintSets("Множества (методы), факультет 1 и 2:", Queries.SetsExt(u));
            PrintAgg("Баллы (LINQ)", Queries.AggregateLinq(u));
            PrintAgg("Баллы (методы)", Queries.AggregateExt(u));
            Print("Group by (LINQ):", Queries.GroupLinq(u));
            Print("Group by (методы):", Queries.GroupExt(u));
            Print("Let (LINQ):", Queries.LetLinq(u));
            Print("Let (методы):", Queries.LetExt(u));
            Print("Join (LINQ):", Queries.JoinLinq(u));
            Print("Join (методы):", Queries.JoinExt(u));
            var big = Data.CreateBig(10000);
            long tLinq = Measure(() => Queries.WhereLinq(big, 3).ToList());
            long tExt = Measure(() => Queries.WhereExt(big, 3).ToList());
            long tFor = Measure(() => Queries.WhereFor(big, 3));
            Console.WriteLine("\nВремя 100 запросов Where (тики):");
            Console.WriteLine($"  LINQ: {tLinq}");
            Console.WriteLine($"  Методы расширения: {tExt}");
            Console.WriteLine($"  for: {tFor}");

            Console.WriteLine("\nЧАСТЬ 2");
            MyNewCollection mc = new MyNewCollection("FIRST")
            { new Student("Иванов Иван", 20, 2, 4.5),
                   new Student("Петров Петр", 21, 3, 4.0),
                   new Student("Сидоров Алексей", 19, 2, 3.8),
                   new Student("Орлов Олег", 22, 4, 4.8)
            };
            Print("Filter (оценка выше 4):", mc.Filter(s => s.AverageGrade > 4.0));
            Console.WriteLine("AverageOf (средний балл): " + mc.AverageOf(s => s.AverageGrade));
            Print("SortBy (по баллу, по убыванию):", mc.SortBy(s => s.AverageGrade, true));
            Print("SortBy (по имени, по возрастанию):", mc.SortBy(s => s.Name));
            Console.WriteLine("GroupByKey (по курсу):");
            foreach (var g in mc.GroupByKey(s => s.Course))
                Console.WriteLine($"  Курс {g.Key}: {g.Count()} студ.");
            Console.ReadKey();
        }
    }
}
