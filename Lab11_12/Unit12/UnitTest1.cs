using Lab11;

namespace Unit12
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void Person_Creation_SetsPropertiesCorrectly()
        {
            var person = new Person("Иван", 25);

            Assert.That(person.Name, Is.EqualTo("Иван"));
            Assert.That(person.Age, Is.EqualTo(25));
        }

        [Test]
        public void Person_CompareTo_ReturnsCorrectOrder()
        {
            var person1 = new Person("Анна", 20);
            var person2 = new Person("Борис", 25);

            Assert.That(person1.CompareTo(person2), Is.LessThan(0));
            Assert.That(person2.CompareTo(person1), Is.GreaterThan(0));
            Assert.That(person1.CompareTo(new Person("Анна", 30)), Is.EqualTo(0));
        }

        [Test]
        public void Person_ToString_ReturnsCorrectFormat()
        {
            var person = new Person("Иван", 25);

            Assert.That(person.ToString(), Is.EqualTo("Иван, 25 лет"));
        }
    }

    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void Student_Creation_SetsPropertiesCorrectly()
        {
            var student = new Student("Петр", 20, 3, 4.5);

            Assert.That(student.Name, Is.EqualTo("Петр"));
            Assert.That(student.Age, Is.EqualTo(20));
            Assert.That(student.Course, Is.EqualTo(3));
            Assert.That(student.AverageGrade, Is.EqualTo(4.5));
        }

        [Test]
        public void Student_BasePerson_ReturnsCorrectPerson()
        {
            var student = new Student("Мария", 21, 4, 4.7);
            var basePerson = student.BasePerson;

            Assert.That(basePerson.Name, Is.EqualTo("Мария"));
            Assert.That(basePerson.Age, Is.EqualTo(21));
            Assert.That(basePerson, Is.InstanceOf<Person>());
            Assert.That(basePerson, Is.Not.InstanceOf<Student>());
        }

        [Test]
        public void Student_ToString_ReturnsCorrectFormat()
        {
            var student = new Student("Алексей", 22, 5, 4.2);

            Assert.That(student.ToString(), Is.EqualTo("Студент: Алексей, 22 лет, 5 курс, средний балл: 4,2"));
        }
    }

    [TestFixture]
    public class Task1ArrayListTests
    {
        private Task1ArrayList arrayList;
        private Student student1;
        private Student student2;

        [SetUp]
        public void Setup()
        {
            arrayList = new Task1ArrayList();
            student1 = new Student("Иванов", 20, 2, 4.2);
            student2 = new Student("Петров", 21, 3, 4.5);
        }

        [Test]
        public void ArrayList_AddStudent_IncreasesCount()
        {
            Assert.That(arrayList.Count, Is.EqualTo(0));

            arrayList.AddStudent(student1);
            Assert.That(arrayList.Count, Is.EqualTo(1));

            arrayList.AddStudent(student2);
            Assert.That(arrayList.Count, Is.EqualTo(2));
        }

        [Test]
        public void ArrayList_RemoveStudentByIndex_DecreasesCount()
        {
            arrayList.AddStudent(student1);
            arrayList.AddStudent(student2);

            arrayList.RemoveStudent(0);
            Assert.That(arrayList.Count, Is.EqualTo(1));
        }

        [Test]
        public void ArrayList_RemoveStudentByName_RemovesCorrectStudent()
        {
            arrayList.AddStudent(student1);
            arrayList.AddStudent(student2);

            arrayList.RemoveStudentByName("Иванов");
            Assert.That(arrayList.Count, Is.EqualTo(1));
        }

        [Test]
        public void ArrayList_CountStudentsByCourse_ReturnsCorrectCount()
        {
            arrayList.AddStudent(student1);
            arrayList.AddStudent(student2);
            arrayList.AddStudent(new Student("Кузнецов", 22, 2, 4.0));

            int count = arrayList.CountStudentsByCourse(2);
            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public void ArrayList_CloneCollection_CreatesSeparateInstance()
        {
            arrayList.AddStudent(student1);
            arrayList.AddStudent(student2);

            var clone = arrayList.CloneCollection();
            Assert.That(clone.Count, Is.EqualTo(2));

            arrayList.RemoveStudent(0);
            Assert.That(clone.Count, Is.EqualTo(2));
            Assert.That(arrayList.Count, Is.EqualTo(1));
        }
    }

    [TestFixture]
    public class Task2SortedDictionaryTests
    {
        private Task2SortedDictionary dictionary;

        [SetUp]
        public void Setup()
        {
            dictionary = new Task2SortedDictionary();
        }

        [Test]
        public void SortedDictionary_AddStudent_IncreasesCount()
        {
            var student = new Student("Иванов", 20, 2, 4.2);

            dictionary.AddStudent(student);
            Assert.That(dictionary.Count, Is.EqualTo(1));
        }

        [Test]
        public void SortedDictionary_RemoveStudent_DecreasesCount()
        {
            var student = new Student("Иванов", 20, 2, 4.2);

            dictionary.AddStudent(student);
            dictionary.RemoveStudent(1);

            Assert.That(dictionary.Count, Is.EqualTo(0));
        }

        [Test]
        public void SortedDictionary_CloneDictionary_CreatesSeparateInstance()
        {
            var student1 = new Student("Иванов", 20, 2, 4.2);
            var student2 = new Student("Петров", 21, 3, 4.5);

            dictionary.AddStudent(student1);
            dictionary.AddStudent(student2);

            var clone = dictionary.CloneDictionary();
            Assert.That(clone.Count, Is.EqualTo(2));

            dictionary.RemoveStudent(1);
            Assert.That(clone.Count, Is.EqualTo(2));
            Assert.That(dictionary.Count, Is.EqualTo(1));
        }
    }

    [TestFixture]
    public class TestCollectionsTests
    {
        [Test]
        public void TestCollections_Constructor_CreatesCollectionsWithSameSize()
        {
            int count = 10;
            var testCollections = new TestCollections(count);

            Assert.That(testCollections.collection1.Count, Is.EqualTo(count));
            Assert.That(testCollections.collection2.Count, Is.EqualTo(count));
            Assert.That(testCollections.collection3.Count, Is.EqualTo(count));
            Assert.That(testCollections.collection4.Count, Is.EqualTo(count));
        }

        [Test]
        public void TestCollections_AddElement_IncreasesAllCollections()
        {
            int initialCount = 5;
            var testCollections = new TestCollections(initialCount);

            var newStudent = new Student("Новый", 20, 3, 4.0);
            testCollections.AddElement(newStudent);

            Assert.That(testCollections.collection1.Count, Is.EqualTo(initialCount + 1));
            Assert.That(testCollections.collection2.Count, Is.EqualTo(initialCount + 1));
            Assert.That(testCollections.collection3.Count, Is.EqualTo(initialCount + 1));
            Assert.That(testCollections.collection4.Count, Is.EqualTo(initialCount + 1));
        }

        [Test]
        public void TestCollections_RemoveElement_DecreasesAllCollections()
        {
            int initialCount = 5;
            var testCollections = new TestCollections(initialCount);

            var firstStudent = testCollections.collection1.First.Value;
            testCollections.RemoveElement(firstStudent);

            Assert.That(testCollections.collection1.Count, Is.EqualTo(initialCount - 1));
            Assert.That(testCollections.collection2.Count, Is.EqualTo(initialCount - 1));
            Assert.That(testCollections.collection3.Count, Is.EqualTo(initialCount - 1));
            Assert.That(testCollections.collection4.Count, Is.EqualTo(initialCount - 1));
        }

        [Test]
        public void TestCollections_CollectionsContainSameData()
        {
            int count = 3;
            var testCollections = new TestCollections(count);

            var studentFromColl1 = testCollections.collection1.First.Value;
            var stringFromColl2 = testCollections.collection2.First.Value;

            Assert.That(stringFromColl2, Is.EqualTo(studentFromColl1.ToString()));
            Assert.That(testCollections.collection3.ContainsKey(studentFromColl1.BasePerson), Is.True);
            Assert.That(testCollections.collection4.ContainsKey(studentFromColl1.ToString()), Is.True);
        }
    }

    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void AllCollections_WorkWithSameStudentType()
        {
            var student = new Student("Тестовый", 25, 4, 4.8);

            var task1 = new Task1ArrayList();
            task1.AddStudent(student);
            Assert.That(task1.Count, Is.EqualTo(1));

            var task2 = new Task2SortedDictionary();
            task2.AddStudent(student);
            Assert.That(task2.Count, Is.EqualTo(1));

            var testColl = new TestCollections(0);
            testColl.AddElement(student);
            Assert.That(testColl.collection1.Count, Is.EqualTo(1));
            Assert.That(testColl.collection2.Count, Is.EqualTo(1));
            Assert.That(testColl.collection3.Count, Is.EqualTo(1));
            Assert.That(testColl.collection4.Count, Is.EqualTo(1));
        }

        [Test]
        public void Student_CanBeUsedInAllCollectionTypes()
        {
            var student = new Student("Интеграционный", 22, 3, 4.3);

            var arrayList = new System.Collections.ArrayList();
            arrayList.Add(student);
            Assert.That(arrayList.Count, Is.EqualTo(1));

            var linkedList = new LinkedList<Student>();
            linkedList.AddLast(student);
            Assert.That(linkedList.Count, Is.EqualTo(1));

            var sortedDict = new SortedDictionary<string, Student>();
            sortedDict.Add(student.ToString(), student);
            Assert.That(sortedDict.Count, Is.EqualTo(1));
        }
    }

    [TestFixture]
    public class PerformanceTests
    {
        [Test]
        public void TestCollections_SearchPerformance_FirstElementFound()
        {
            var testCollections = new TestCollections(100);

            var firstStudent = new Student(
                testCollections.collection1.First.Value.Name,
                testCollections.collection1.First.Value.Age,
                testCollections.collection1.First.Value.Course,
                testCollections.collection1.First.Value.AverageGrade
            );

            bool foundInColl1 = testCollections.collection1.Contains(firstStudent);
            bool foundInColl2 = testCollections.collection2.Contains(firstStudent.ToString());
            bool foundInColl3 = testCollections.collection3.ContainsKey(firstStudent.BasePerson);
            bool foundInColl4 = testCollections.collection4.ContainsKey(firstStudent.ToString());

            Assert.That(foundInColl1, Is.True);
            Assert.That(foundInColl2, Is.True);
            Assert.That(foundInColl3, Is.True);
            Assert.That(foundInColl4, Is.True);
        }

        [Test]
        public void TestCollections_SearchPerformance_NonExistentElementNotFound()
        {
            var testCollections = new TestCollections(50);

            var nonExistentStudent = new Student("Несуществующий", 0, 0, 0.0);

            bool foundInColl1 = testCollections.collection1.Contains(nonExistentStudent);
            bool foundInColl2 = testCollections.collection2.Contains(nonExistentStudent.ToString());
            bool foundInColl3 = testCollections.collection3.ContainsKey(nonExistentStudent.BasePerson);
            bool foundInColl4 = testCollections.collection4.ContainsKey(nonExistentStudent.ToString());

            Assert.That(foundInColl1, Is.False);
            Assert.That(foundInColl2, Is.False);
            Assert.That(foundInColl3, Is.False);
            Assert.That(foundInColl4, Is.False);
        }
    }
}
