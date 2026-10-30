using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab13
{
    public class MyCollection : IEnumerable<Student>
    {
        protected List<Student> list = new List<Student>();
        private static Random rnd = new Random();

        public int Length => list.Count;
        protected static Student CreateRandom()
        {
            string[] names = { "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов" };
            string[] firstNames = { "Иван", "Петр", "Алексей", "Дмитрий", "Сергей" };
            string name = names[rnd.Next(names.Length)] + " " + firstNames[rnd.Next(firstNames.Length)];
            return new Student(name, 18 + rnd.Next(7), 1 + rnd.Next(5), Math.Round(3.0 + rnd.NextDouble() * 2.0, 1));
        }
        public virtual void AddDefaults(int count = 5)
        {
            for (int i = 0; i < count; i++)
                list.Add(CreateRandom());
        }

        public virtual void Add(params Student[] students)
        {
            foreach (Student s in students)
                list.Add(s);
        }

        public virtual bool Remove(int j)
        {
            if (j < 0 || j >= list.Count) return false;
            list.RemoveAt(j);
            return true;
        }

        public virtual Student this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }

        public IEnumerator<Student> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
                yield return list[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
