using System.Collections.Generic;
using System.Linq;

namespace Lab14
{
    public static class Queries
    {
        public static IEnumerable<Student> Students(List<Dictionary<int, Person>> u)
        {
            return u.SelectMany(f => f.Values).OfType<Student>();
        }

        public static IEnumerable<Teacher> Teachers(List<Dictionary<int, Person>> u)
        {
            return u.SelectMany(f => f.Values).OfType<Teacher>();
        }

        public static IEnumerable<string> WhereLinq(List<Dictionary<int, Person>> u, int course)
        {
            return from s in Students(u)
                   where s.Course == course
                   select s.Name;
        }

        public static IEnumerable<string> WhereExt(List<Dictionary<int, Person>> u, int course)
        {
            return Students(u).Where(s => s.Course == course).Select(s => s.Name);
        }

        public static List<string> WhereFor(List<Dictionary<int, Person>> u, int course)
        {
            var result = new List<string>();
            foreach (var faculty in u)
            {
                foreach (var p in faculty.Values)
                {
                    if (p is Student s && s.Course == course)
                        result.Add(s.Name);
                }
            }
            return result;
        }

        public static (List<string> Union, List<string> Except, List<string> Intersect) SetsLinq(List<Dictionary<int, Person>> u)
        {
            var a = from p in u[0].Values select p.Name;
            var b = from p in u[1].Values select p.Name;
            return (a.Union(b).ToList(), a.Except(b).ToList(), a.Intersect(b).ToList());
        }

        public static (List<string> Union, List<string> Except, List<string> Intersect) SetsExt(List<Dictionary<int, Person>> u)
        {
            var a = u[0].Values.Select(p => p.Name);
            var b = u[1].Values.Select(p => p.Name);
            return (a.Union(b).ToList(), a.Except(b).ToList(), a.Intersect(b).ToList());
        }

        public static (double Sum, double Max, double Min, double Average) AggregateLinq(List<Dictionary<int, Person>> u)
        {
            var grades = from s in Students(u) select s.AverageGrade;
            return (grades.Sum(), grades.Max(), grades.Min(), grades.Average());
        }

        public static (double Sum, double Max, double Min, double Average) AggregateExt(List<Dictionary<int, Person>> u)
        {
            var students = Students(u);
            return (students.Sum(s => s.AverageGrade), students.Max(s => s.AverageGrade),
                    students.Min(s => s.AverageGrade), students.Average(s => s.AverageGrade));
        }

        public static IEnumerable<object> GroupLinq(List<Dictionary<int, Person>> u)
        {
            return from s in Students(u)
                   group s by s.Course into g
                   orderby g.Key
                   select new { Course = g.Key, Count = g.Count(), Average = g.Average(s => s.AverageGrade) };
        }

        public static IEnumerable<object> GroupExt(List<Dictionary<int, Person>> u)
        {
            return Students(u).GroupBy(s => s.Course)
                              .OrderBy(g => g.Key)
                              .Select(g => new { Course = g.Key, Count = g.Count(), Average = g.Average(s => s.AverageGrade) });
        }

        public static IEnumerable<object> LetLinq(List<Dictionary<int, Person>> u)
        {
            return from s in Students(u)
                   let rating = s.AverageGrade >= 4.5 ? "отличник" : s.AverageGrade >= 4.0 ? "хорошист" : "остальные"
                   select new { s.Name, s.Course, Rating = rating };
        }

        public static IEnumerable<object> LetExt(List<Dictionary<int, Person>> u)
        {
            return Students(u)
                .Select(s => new { s, rating = s.AverageGrade >= 4.5 ? "отличник" : s.AverageGrade >= 4.0 ? "хорошист" : "остальные" })
                .Select(x => new { x.s.Name, x.s.Course, Rating = x.rating });
        }

        public static IEnumerable<object> JoinLinq(List<Dictionary<int, Person>> u)
        {
            return from s in Students(u)
                   join t in Teachers(u) on s.Department equals t.Department
                   select new { Student = s.Name, Teacher = t.Name, s.Department };
        }

        public static IEnumerable<object> JoinExt(List<Dictionary<int, Person>> u)
        {
            return Students(u).Join(Teachers(u),
                                    s => s.Department,
                                    t => t.Department,
                                    (s, t) => new { Student = s.Name, Teacher = t.Name, s.Department });
        }
    }
}
