using System;
using Lab5_6.matrix;
using Lab5_6.Strings;

namespace MainProgram
{
    public class Program
    {
        static void Main()
        {

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Main");
                Console.WriteLine("1. Работа с двумерным массивом");
                Console.WriteLine("2. Работа с рваным массивом");
                Console.WriteLine("3. Работа со строкой");
                Console.WriteLine("0. Выход");
                int choice = 0;
                bool tr = false;
                do
                {
                    tr = int.TryParse(Console.ReadLine(), out choice);
                }
                while (tr != true);
                switch (choice)
                {
                    case 1: MatrixMenu(); break;
                    case 2: JaggedMenu(); break;
                    case 3: StringMenu(); break;
                    case 0: exit = true; break;
                }
            }
        }

        static void MatrixMenu()
        {
            int[,] matrix = null;

            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n ДВУМЕРНЫЙ МАССИВ ");
                Console.WriteLine("1. Создать вручную");
                Console.WriteLine("2. Создать случайно");
                Console.WriteLine("3. Печать");
                Console.WriteLine("4. Добавить строку в конец");
                Console.WriteLine("5. Удалить строку по номеру");
                Console.WriteLine("6. Сумма элементов (foreach)");
                Console.WriteLine("0. Назад");
                Console.Write("Выбор: ");

                int choice = 0;
                bool tr = false;
                do
                {
                    tr = int.TryParse(Console.ReadLine(), out choice);
                }
                while (tr != true);
                switch (choice)
                {
                    case 1: MatrixService.CreateManually(); 
                        matrix = MatrixService.Matrix; break;
                    case 2: MatrixService.CreateRandom();
                        matrix = MatrixService.Matrix; break;
                    case 3: MatrixService.Print(matrix); break;
                    case 4: matrix = MatrixService.AddRow(matrix); break;
                    case 5: matrix = MatrixService.RemoveRow(matrix); break;
                    case 6: MatrixService.PrintSum(matrix); break;
                    case 0: back = true; break;
                }
            }
        }

        static void JaggedMenu()
        {
            int[][] jagged = null;

            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n РВАНЫЙ МАССИВ ");
                Console.WriteLine("1. Создать вручную");
                Console.WriteLine("2. Создать случайно");
                Console.WriteLine("3. Печать");
                Console.WriteLine("4. Добавить строку в конец");
                Console.WriteLine("5. Удалить строку по номеру");
                Console.WriteLine("6. Сумма элементов (foreach)");
                Console.WriteLine("0. Назад");

                int choice = 0;
                bool tr = false;
                do
                {
                    tr = int.TryParse(Console.ReadLine(), out choice);
                }
                while (tr != true);
                switch (choice)
                {
                    case 1: JaggedService.CreateManually();
                        jagged = JaggedService.jagg; break;
                    case 2: JaggedService.CreateRandom();
                        jagged = JaggedService.jagg; break;
                    case 3: JaggedService.Print(jagged); break;
                    case 4: jagged = JaggedService.AddRow(jagged); break;
                    case 5: jagged = JaggedService.RemoveRow(jagged); break;
                    case 6: JaggedService.PrintSum(jagged); break;
                    case 0: back = true; break;
                }
            }
        }
        static void StringMenu()
        {
            string text = "";

            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n СТРОКА");
                Console.WriteLine("1. Ввести с клавиатуры");
                Console.WriteLine("2. Взять тестовую строку");
                Console.WriteLine("3. Показать строку");
                Console.WriteLine("4. Обработка (заглушка)");
                Console.WriteLine("0. Назад");
                Console.Write("Выбор: ");

                int choice = 0;
                bool tr = false;
                do
                {
                    tr = int.TryParse(Console.ReadLine(), out choice);
                }
                while (tr != true);
                switch (choice)
                {
                    case 1: Console.WriteLine("Введите строку");
                        try
                        {
                            text = Console.ReadLine();
                        }
                        catch { Console.WriteLine("Строка введена неверно!"); }
                        break;
                    case 2: text = StringService.GetTestString(); break;
                    case 3: StringService.Print(text); break;
                    case 4: StringService.Process(text); break;
                    case 0: back = true; break;
                }
            }
        }
    }
}