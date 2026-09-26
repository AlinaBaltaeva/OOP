using System;

namespace Lab5_6.matrix
{
    public static class MatrixService
    {
        private static readonly Random Rnd = new Random();
        public static int[,] Matrix;
        public static void CreateManually()
        {
            int rows, cols;

            do
            {
                Console.Write("Количество строк: ");
                if (int.TryParse(Console.ReadLine(), out rows) && rows >= 1 && rows <= 100) 
                    break;
                Console.WriteLine("Ошибка: введите число от 1 до 100.");
            } while (true);

            do
            {
                Console.Write("Количество столбцов: ");
                if (int.TryParse(Console.ReadLine(), out cols) && cols >= 1 && cols <= 100)
                    break;
                Console.WriteLine("Ошибка: введите число от 1 до 100.");
            } while (true);

            Matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int value;
                    do
                    {
                        Console.Write($"Matroix[{i},{j}] = ");
                        if (int.TryParse(Console.ReadLine(), out value))
                            break;
                        Console.WriteLine("Ошибка: введите целое число");
                    } while (true);
                    Matrix[i, j] = value;
                }
            }

            Console.WriteLine("Массив создан!");
        }

        public static void CreateRandom()
        {
            int rows, cols;

            do
            {
                Console.Write("Количество строк: ");
                if (int.TryParse(Console.ReadLine(), out rows) && rows >= 1 && rows <= 100)
                    break;
                Console.WriteLine("Ошибка: введите число от 1 до 100.");
            } while (true);

            do
            {
                Console.Write("Количество столбцов: ");
                if (int.TryParse(Console.ReadLine(), out cols) && cols >= 1 && cols <= 100)
                    break;
                Console.WriteLine("Ошибка: введите число от 1 до 100.");
            } while (true);

            Matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    Matrix[i, j] = Rnd.Next(1, 10);

            Console.WriteLine("Массив создан (случайно).");
        }

        public static void Print(int[,] m)
        {
            if (m == null || m.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
                return;
            }

            Console.WriteLine("Массив:");
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                    Console.Write($"{m[i, j]+" "}");
                Console.WriteLine();
            }
        }

        public static int[,] AddRow(int[,] m)
        {
            if (m == null)
            {
                Console.WriteLine("Сначала создайте массив.");
                return null;
            }

            int rows = m.GetLength(0);
            int cols = m.GetLength(1);

            int[,] result = new int[rows + 1, cols];
            Array.Copy(m, result, m.Length);

            Console.WriteLine("Введите новую строку:");
            for (int j = 0; j < cols; j++)
            {
                int value;
                do
                {
                    Console.Write($"  [{rows},{j}] = ");
                    if (int.TryParse(Console.ReadLine(), out value)) break;
                    Console.WriteLine("Ошибка: введите целое число.");
                } while (true);
                result[rows, j] = value;
            }

            Console.WriteLine("Строка добавлена.");
            return result;
        }

        public static int[,] RemoveRow(int[,] m)
        {
            if (m == null || m.GetLength(0) == 0)
            {
                Console.WriteLine("Массив пуст, удалять нечего.");
                return m;
            }

            int rows = m.GetLength(0);
            int cols = m.GetLength(1);

            int k;
            do
            {
                Console.Write($"Номер удаляемой строки (0..{rows - 1}): ");
                if (int.TryParse(Console.ReadLine(), out k) && k >= 0 && k < rows)
                    break;
                Console.WriteLine($"Ошибка: введите число от 0 до {rows - 1}.");
            } while (true);

            int[,] result = new int[rows - 1, cols];
            int r = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < cols; j++)
                    result[r, j] = m[i, j];
                r++;
            }

            Console.WriteLine($"Строка {k} удалена.");
            return result;
        }

        public static void PrintSum(int[,] m)
        {
            if (m == null || m.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
                return;
            }

            int sum = 0;
            foreach (int x in m) sum += x;
            Console.WriteLine($"Сумма элементов: {sum}");
        }
    }
}