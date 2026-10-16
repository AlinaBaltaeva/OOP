using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab11;


public class Person : IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public int CompareTo(Person other)
    {
        return Name.CompareTo(other.Name);
    }

    public virtual void Show()
    {
        Console.WriteLine($"Имя: {Name}, Возраст: {Age}");
    }

    public override string ToString()
    {
        return $"{Name}, {Age} лет";
    }
}

public class Student : Person
{
    public int Course { get; set; }
    public double AverageGrade { get; set; }

    public Student(string name, int age, int course, double averageGrade)
        : base(name, age)
    {
        Course = course;
        AverageGrade = averageGrade;
    }

    public Person BasePerson
    {
        get { return new Person(Name, Age); }
    }

    public override void Show()
    {
        Console.WriteLine($"Студент: {Name}, Возраст: {Age}, Курс: {Course}, Средний балл: {AverageGrade:F1}");
    }

    public override string ToString()
    {
        return $"Студент: {Name}, {Age} лет, {Course} курс, средний балл: {AverageGrade:F1}";
    }
}