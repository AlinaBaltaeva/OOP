using System;
using System.Collections.Generic;

namespace Lab14
{
    public static class Data
    {
        public static List<Dictionary<int, Person>> CreateSmall()
        {
            var f1 = new Dictionary<int, Person>
            {
                { 1, new Student("Иванов Иван", 20, 2, 4.5) { Department = "ИТ" } },
                { 2, new Student("Петров Петр", 21, 3, 4.0) { Department = "ИТ" } },
                { 3, new Student("Сидоров Алексей", 19, 2, 3.8) { Department = "ИТ" } },
                { 4, new Teacher("Кузнецов Дмитрий", 45, "ИТ", "Доцент") },
                { 5, new Employee("Смирнова Анна", 38, 10) }
            };
            var f2 = new Dictionary<int, Person>
            {
                { 1, new Student("Иванов Иван", 20, 2, 4.5) { Department = "Мат" } },
                { 2, new Student("Орлов Олег", 22, 4, 4.8) { Department = "Мат" } },
                { 3, new Student("Лебедев Павел", 21, 2, 4.1) { Department = "Мат" } },
                { 4, new Teacher("Волкова Елена", 50, "Мат", "Профессор") },
                { 5, new Employee("Попов Игорь", 41, 15) }
            };
            var f3 = new Dictionary<int, Person>
            {
                { 1, new Student("Новиков Сергей", 19, 1, 3.9) { Department = "Физ" } },
                { 2, new Student("Морозов Антон", 20, 1, 4.3) { Department = "Физ" } },
                { 3, new Teacher("Соколов Виктор", 55, "Физ", "Заведующий кафедрой") },
                { 4, new Employee("Козлов Роман", 33, 5) }
            };
            return new List<Dictionary<int, Person>> { f1, f2, f3 };
        }

        public static List<Dictionary<int, Person>> CreateBig(int perFaculty)
        {
            string[] departments = { "ИТ", "Мат", "Физ" };
            Random rnd = new Random(1);
            var university = new List<Dictionary<int, Person>>();
            for (int f = 0; f < 3; f++)
            {
                var faculty = new Dictionary<int, Person>();
                for (int i = 0; i < perFaculty; i++)
                {
                    string name = "Человек" + f + "_" + i;
                    if (i % 10 == 0)
                        faculty.Add(i, new Teacher(name, 40 + rnd.Next(20), departments[f], "Доцент"));
                    else if (i % 10 == 1)
                        faculty.Add(i, new Employee(name, 25 + rnd.Next(30), rnd.Next(30)));
                    else
                        faculty.Add(i, new Student(name, 18 + rnd.Next(7), 1 + rnd.Next(5), Math.Round(3.0 + rnd.NextDouble() * 2.0, 1)) { Department = departments[f] });
                }
                university.Add(faculty);
            }
            return university;
        }
    }
}
