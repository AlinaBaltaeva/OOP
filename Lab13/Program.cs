using System;

namespace Lab13
{
    class Program
    {
        static void Main()
        {
            MyNewCollection mc1 = new MyNewCollection("FIRST");
            MyNewCollection mc2 = new MyNewCollection("SECOND");

            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            mc1.CollectionCountChanged += journal1.CollectionCountChanged;
            mc1.CollectionReferenceChanged += journal1.CollectionReferenceChanged;

            mc1.CollectionReferenceChanged += journal2.CollectionReferenceChanged;
            mc2.CollectionReferenceChanged += journal2.CollectionReferenceChanged;
            mc1.AddDefaults(3);
            mc1.Add(new Student("Орлов Олег", 20, 2, 4.4), new Student("Лебедев Павел", 21, 3, 4.1));
            mc2.AddDefaults(3);
            mc2.Add(new Student("Волков Антон", 19, 1, 3.9));
            mc1.Remove(0);
            mc2.Remove(1);
            Console.WriteLine("Remove(100) в mc1: " + mc1.Remove(100));

            mc1[0] = new Student("Новый Студент", 22, 4, 5.0);
            mc2[0] = new Student("Другой Студент", 23, 5, 4.7);
            Console.WriteLine("\nJournal 1 (Count + Reference из FIRST):");
            journal1.Print();
            Console.WriteLine("\nJournal 2 (Reference из FIRST и SECOND):");
            journal2.Print();

            Console.WriteLine($"\nДлина FIRST: {mc1.Length}, SECOND: {mc2.Length}");
            Console.WriteLine("Элементы FIRST:");
            foreach (Student s in mc1) s.Show();

            Console.ReadKey();
        }
    }
}
