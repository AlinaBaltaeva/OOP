using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    using System;
    using System.Collections;
    using System.Linq;

    public class Task1ArrayList
    {
        private ArrayList students = new ArrayList();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(int index)
        {
            if (index >= 0 && index < students.Count)
                students.RemoveAt(index);
        }

        public void RemoveStudentByName(string name)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (((Student)students[i]).Name == name)
                {
                    students.RemoveAt(i);
                    return;
                }
            }
        }

        public int CountStudentsByCourse(int course)
        {
            int count = 0;
            foreach (Student student in students)
                if (student.Course == course) count++;
            return count;
        }

        public void PrintStudentsWithGradeAbove(double minGrade)
        {
            Console.WriteLine($"Студенты со средним баллом выше {minGrade}:");
            foreach (Student student in students)
                if (student.AverageGrade > minGrade) student.Show();
        }

        public void PrintStudentsAlphabetically()
        {
            var sorted = students.Cast<Student>().OrderBy(s => s.Name).ToList();
            Console.WriteLine("Студенты по алфавиту:");
            foreach (var student in sorted) student.Show();
        }

        public void PrintAllStudents()
        {
            Console.WriteLine("Все студенты:");
            foreach (Student student in students) student.Show();
        }

        public ArrayList CloneCollection()
        {
            return (ArrayList)students.Clone();
        }

        public void SortAndSearch(string searchName)
        {
            students.Sort();

            Console.WriteLine("Отсортированная коллекция:");
            PrintAllStudents();

            int index = -1;
            for (int i = 0; i < students.Count; i++)
            {
                if (((Student)students[i]).Name == searchName)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
                Console.WriteLine($"Студент {searchName} найден на позиции {index}");
            else
                Console.WriteLine($"Студент {searchName} не найден");
        }

        public int Count => students.Count;
    }
}
