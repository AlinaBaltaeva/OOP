using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{


    public class Task2SortedDictionary
    {
        private SortedDictionary<int, Student> studentsDict = new SortedDictionary<int, Student>();
        private int nextId = 1;

        public void AddStudent(Student student)
        {
            studentsDict.Add(nextId, student);
            nextId++;
        }

        public void RemoveStudent(int id)
        {
            studentsDict.Remove(id);
        }

        public void CountStudentsByCourse()
        {
            var courseCount = new Dictionary<int, int>();

            foreach (var student in studentsDict.Values)
            {
                if (courseCount.ContainsKey(student.Course))
                    courseCount[student.Course]++;
                else
                    courseCount[student.Course] = 1;
            }

            Console.WriteLine("Количество студентов по курсам:");
            foreach (var item in courseCount)
                Console.WriteLine($"Курс {item.Key}: {item.Value} студентов");
        }

        public void TopStudentsByCourse()
        {
            var topStudents = new Dictionary<int, Student>();

            foreach (var student in studentsDict.Values)
            {
                if (!topStudents.ContainsKey(student.Course) ||
                    student.AverageGrade > topStudents[student.Course].AverageGrade)
                    topStudents[student.Course] = student;
            }

            Console.WriteLine("Лучшие студенты по курсам:");
            foreach (var item in topStudents)
            {
                Console.Write($"Курс {item.Key}: ");
                item.Value.Show();
            }
        }

        public void FindStudentsByName(string name)
        {
            Console.WriteLine($"Студенты с именем {name}:");
            bool found = false;

            foreach (var student in studentsDict.Values)
            {
                if (student.Name.Contains(name))
                {
                    student.Show();
                    found = true;
                }
            }

            if (!found) Console.WriteLine("Студенты не найдены");
        }

        public void PrintAllStudents()
        {
            Console.WriteLine("Все студенты в словаре:");
            foreach (var kvp in studentsDict)
            {
                Console.Write($"ID: {kvp.Key} - ");
                kvp.Value.Show();
            }
        }

        public SortedDictionary<int, Student> CloneDictionary()
        {
            return new SortedDictionary<int, Student>(studentsDict);
        }

        public void SearchStudent(int id)
        {
            if (studentsDict.TryGetValue(id, out Student student))
            {
                Console.Write($"Студент с ID {id}: ");
                student.Show();
            }
            else
                Console.WriteLine($"Студент с ID {id} не найден");
        }

        public int Count => studentsDict.Count;
    }
}
