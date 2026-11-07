using System;
using Lab14;

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
    public string Department { get; set; } = "";

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

public class Teacher : Person
{
    public string Department { get; set; }
    public string Position { get; set; }

    public Teacher(string name, int age, string department, string position)
        : base(name, age)
    {
        Department = department;
        Position = position;
    }

    public override void Show()
    {
        Console.WriteLine($"Преподаватель: {Name}, Возраст: {Age}, Кафедра: {Department}, Должность: {Position}");
    }

    public override string ToString()
    {
        return $"Преподаватель: {Name}, {Age} лет, кафедра {Department}, {Position}";
    }
}

public class Employee : Person
{
    public int Experience { get; set; }

    public Employee(string name, int age, int experience)
        : base(name, age)
    {
        Experience = experience;
    }

    public override void Show()
    {
        Console.WriteLine($"Сотрудник: {Name}, Возраст: {Age}, Стаж: {Experience}");
    }

    public override string ToString()
    {
        return $"Сотрудник: {Name}, {Age} лет, стаж {Experience}";
    }
}
