using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab14
{
    public static class MyCollectionExtensions
    {
        public static IEnumerable<Student> Filter(this MyNewCollection collection, Func<Student, bool> predicate)
        {
            return collection.Where(predicate);
        }

        public static double AverageOf(this MyNewCollection collection, Func<Student, double> selector)
        {
            return collection.Average(selector);
        }

        public static IEnumerable<Student> SortBy<TKey>(this MyNewCollection collection, Func<Student, TKey> key, bool descending = false)
        {
            return descending ? collection.OrderByDescending(key) : collection.OrderBy(key);
        }

        public static IEnumerable<IGrouping<TKey, Student>> GroupByKey<TKey>(this MyNewCollection collection, Func<Student, TKey> key)
        {
            return collection.GroupBy(key);
        }
    }
}
