using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Задание 1: ArrayList");
            Console.WriteLine("Задание 2: SortedDictionary<K,T>");
            Console.WriteLine("Задание 3: LinkedList<T> и SortedDictionary<K,T>");
            Console.WriteLine();

            Console.WriteLine(" Задание 1: Работа с ArrayList");
            Task1ArrayList task1 = new Task1ArrayList();

            task1.AddStudent(new Student("Иванов Иван", 20, 2, 4.2));
            task1.AddStudent(new Student("Петров Петр", 21, 3, 4.5));
            task1.AddStudent(new Student("Сидоров Алексей", 19, 1, 3.8));
            task1.AddStudent(new Student("Кузнецов Дмитрий", 22, 4, 4.7));

            task1.PrintAllStudents();
            Console.WriteLine();

            Console.WriteLine($"Студентов на 2 курсе: {task1.CountStudentsByCourse(2)}");
            task1.PrintStudentsWithGradeAbove(4.0);



            Console.WriteLine(" Задание 2: Работа с SortedDictionary<K,T> ");
            Task2SortedDictionary task2 = new Task2SortedDictionary();

            task2.AddStudent(new Student("Иванов Иван", 20, 2, 4.2));
            task2.AddStudent(new Student("Петров Петр", 21, 3, 4.5));
            task2.AddStudent(new Student("Сидоров Алексей", 19, 1, 3.8));
            task2.AddStudent(new Student("Кузнецов Дмитрий", 22, 4, 4.7));

            task2.PrintAllStudents();
            Console.WriteLine();

            task2.CountStudentsByCourse();
            task2.TopStudentsByCourse();
            Console.WriteLine();

            Console.WriteLine(" Задание 3: TestCollections ");
            TestCollections test = new TestCollections(1000);

            Console.WriteLine($"Коллекция 1 (LinkedList<Student>): {test.collection1.Count} элементов");
            Console.WriteLine($"Коллекция 2 (LinkedList<string>): {test.collection2.Count} элементов");
            Console.WriteLine($"Коллекция 3 (SortedDictionary<Person, Student>): {test.collection3.Count} элементов");
            Console.WriteLine($"Коллекция 4 (SortedDictionary<string, Student>): {test.collection4.Count} элементов");
            Console.WriteLine();

            test.MeasureSearchTime();

            Console.ReadKey();
        }
    }
}
