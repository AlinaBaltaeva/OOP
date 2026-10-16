using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class TestCollections
    {
        public LinkedList<Student> collection1 = new LinkedList<Student>();
        public LinkedList<string> collection2 = new LinkedList<string>();
        public SortedDictionary<Person, Student> collection3 = new SortedDictionary<Person, Student>();
        public SortedDictionary<string, Student> collection4 = new SortedDictionary<string, Student>();

        public TestCollections(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Student student = GenerateStudent(i);

                collection1.AddLast(student);
                collection2.AddLast(student.ToString());

                Person basePerson = student.BasePerson;
                collection3.Add(basePerson, student);
                collection4.Add(student.ToString(), student);
            }
        }

        private Student GenerateStudent(int index)
        {
            string[] names = { "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов" };
            string[] firstNames = { "Иван", "Петр", "Алексей", "Дмитрий", "Сергей" };

            Random rnd = new Random(index);
            string name = names[rnd.Next(names.Length)] + " " + firstNames[rnd.Next(firstNames.Length)];
            int age = 18 + rnd.Next(7);
            int course = 1 + rnd.Next(5);
            double grade = 3.0 + rnd.NextDouble() * 2.0;

            return new Student(name, age, course, Math.Round(grade, 1));
        }

        public void AddElement(Student student)
        {
            collection1.AddLast(student);
            collection2.AddLast(student.ToString());

            Person basePerson = student.BasePerson;
            collection3.Add(basePerson, student);
            collection4.Add(student.ToString(), student);
        }

        public void RemoveElement(Student student)
        {
            collection1.Remove(student);
            collection2.Remove(student.ToString());

            Person basePerson = student.BasePerson;
            collection3.Remove(basePerson);
            collection4.Remove(student.ToString());
        }

        public void MeasureSearchTime()
        {
            if (collection1.Count == 0) return;

            var firstNode = collection1.First;
            var middleNode = GetMiddleElement(collection1);
            var lastNode = collection1.Last;

            Student first = new Student(firstNode.Value.Name, firstNode.Value.Age,
                                       firstNode.Value.Course, firstNode.Value.AverageGrade);
            Student middle = new Student(middleNode.Value.Name, middleNode.Value.Age,
                                        middleNode.Value.Course, middleNode.Value.AverageGrade);
            Student last = new Student(lastNode.Value.Name, lastNode.Value.Age,
                                      lastNode.Value.Course, lastNode.Value.AverageGrade);
            Student notInCollection = new Student("Несуществующий", 0, 0, 0);

            Person firstBase = first.BasePerson;
            Person middleBase = middle.BasePerson;
            Person lastBase = last.BasePerson;
            Person notInCollectionBase = notInCollection.BasePerson;

            string firstString = first.ToString();
            string middleString = middle.ToString();
            string lastString = last.ToString();
            string notInCollectionString = notInCollection.ToString();

            Console.WriteLine("Время поиска (тики):");
            Console.WriteLine("| Элемент\t| Коллекция 1\t| Коллекция 2\t| Коллекция 3\t| Коллекция 4\t|");

            MeasureAndPrint("Первый", first, firstString, firstBase);
            MeasureAndPrint("Средний", middle, middleString, middleBase);
            MeasureAndPrint("Последний", last, lastString, lastBase);
            MeasureAndPrint("Не в коллекции", notInCollection, notInCollectionString, notInCollectionBase);

            Console.WriteLine("\nПоиск значения в коллекции 3:");
            MeasureValueSearch(collection3, first, middle, last, notInCollection);
        }

        private LinkedListNode<Student> GetMiddleElement(LinkedList<Student> list)
        {
            if (list.First == null) return null;

            int middleIndex = list.Count / 2;
            var current = list.First;
            for (int i = 0; i < middleIndex; i++)
                current = current.Next;
            return current;
        }

        private void MeasureAndPrint(string label, Student student, string studentString, Person basePerson)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            bool found1 = collection1.Contains(student);
            sw.Stop();
            long time1 = sw.ElapsedTicks;

            sw.Restart();
            bool found2 = collection2.Contains(studentString);
            sw.Stop();
            long time2 = sw.ElapsedTicks;

            sw.Restart();
            bool found3 = collection3.ContainsKey(basePerson);
            sw.Stop();
            long time3 = sw.ElapsedTicks;

            sw.Restart();
            bool found4 = collection4.ContainsKey(studentString);
            sw.Stop();
            long time4 = sw.ElapsedTicks;

            Console.WriteLine($"| {label}\t| {time1}\t| {time2}\t| {time3}\t| {time4}\t|");
        }

        private void MeasureValueSearch(SortedDictionary<Person, Student> dict,
                                       params Student[] students)
        {
            Stopwatch sw = new Stopwatch();

            foreach (var student in students)
            {
                sw.Restart();
                bool found = dict.ContainsValue(student);
                sw.Stop();
                Console.WriteLine($"Поиск {student.Name}: {sw.ElapsedTicks} тиков (найден: {found})");
            }
        }
    }
}
