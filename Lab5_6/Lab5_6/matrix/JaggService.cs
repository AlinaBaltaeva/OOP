using System;

namespace Lab5_6.matrix
{
    public static class JaggedService
    {
        private static readonly Random Rnd = new Random();
        public static int[][] jagg;
        public static void CreateManually()
        {
            int rows;
            do
            {
                Console.Write("Количество строк: ");
                if (int.TryParse(Console.ReadLine(), out rows) && rows >= 1 && rows <= 100)
                    break;
                Console.WriteLine("Ошибка: введите число от 1 до 100.");
            } while (true);

            jagg = new int[rows][];// [,] - прямоугольная матрица, [][] - матрица любой длины

            for (int i = 0; i < rows; i++)
            {
                int cols;
                do
                {
                    Console.Write($"  Столбцов в строке {i}: ");
                    if (int.TryParse(Console.ReadLine(), out cols) && cols >= 1 && cols <= 100)
                        break;
                    Console.WriteLine("Ошибка: введите число от 1 до 100.");
                } while (true);

                jagg[i] = new int[cols];
                for (int k = 0; k < cols; k++)
                {
                    int value;
                    do
                    {
                        Console.Write($"    j[{i}][{k}] = ");
                        if (int.TryParse(Console.ReadLine(), out value))
                            break;
                        Console.WriteLine("Ошибка: введите целое число.");
                    } while (true);
                    jagg[i][k] = value;
                }
            }

            Console.WriteLine("Рваный массив создан.");
        }

        public static void CreateRandom()
        {
            int rows;
            do
            {
                Console.Write("Количество строк: ");
                if (int.TryParse(Console.ReadLine(), out rows) && rows >= 1 && rows <= 100) break;
                Console.WriteLine("Ошибка: введите число от 1 до 100.");
            } while (true);

            jagg = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int cols = Rnd.Next(1, 6);
                jagg[i] = new int[cols];
                for (int k = 0; k < cols; k++)
                    jagg[i][k] = Rnd.Next(1, 10);
            }

            Console.WriteLine("Рваный массив создан (случайно).");
        }

        public static void Print(int[][] j)
        {
            if (j == null || j.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
                return;
            }

            Console.WriteLine("Рваный массив:");
            for (int i = 0; i < j.Length; i++)
            {
                if (j[i] == null || j[i].Length == 0)
                {
                    Console.WriteLine($"Строка {i}: (пустая)");
                    continue;
                }
                Console.Write($"Строка {i}: ");
                for (int k = 0; k < j[i].Length; k++)
                    Console.Write($"{j[i][k] + " "}");
                Console.WriteLine();
            }
        }

        public static int[][] AddRow(int[][] j)
        {
            if (j == null)
            {
                Console.WriteLine("Сначала создайте массив.");
                return null;
            }

            int newSize = j.Length + 1;
            int[][] result = new int[newSize][];
            for (int i = 0; i < j.Length; i++) result[i] = j[i];

            int cols;
            do
            {
                Console.Write("Сколько элементов в новой строке: ");
                if (int.TryParse(Console.ReadLine(), out cols) && cols >= 1 && cols <= 100) break;
                Console.WriteLine("Ошибка: введите число от 1 до 100.");
            } while (true);

            result[newSize - 1] = new int[cols];
            for (int k = 0; k < cols; k++)
            {
                int value;
                do
                {
                    Console.Write($"  [{newSize - 1}][{k}] = ");
                    if (int.TryParse(Console.ReadLine(), out value)) break;
                    Console.WriteLine("Ошибка: введите целое число.");
                } while (true);
                result[newSize - 1][k] = value;
            }

            Console.WriteLine("Строка добавлена.");
            return result;
        }

        public static int[][] RemoveRow(int[][] j)
        {
            if (j == null || j.Length == 0)
            {
                Console.WriteLine("Массив пуст, удалять нечего.");
                return j;
            }

            int k;
            do
            {
                Console.Write($"Номер удаляемой строки (0..{j.Length - 1}): ");
                if (int.TryParse(Console.ReadLine(), out k) && k >= 0 && k < j.Length) break;
                Console.WriteLine($"Ошибка: введите число от 0 до {j.Length - 1}.");
            } while (true);

            int[][] result = new int[j.Length - 1][];
            int r = 0;
            for (int i = 0; i < j.Length; i++)
            {
                if (i == k) continue;
                result[r++] = j[i];
            }

            Console.WriteLine($"Строка {k} удалена.");
            return result;
        }

        public static void PrintSum(int[][] j)
        {
            if (j == null || j.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
                return;
            }

            int sum = 0;
            for (int i = 0; i < j.Length; i++)
            {
                if (j[i] == null) continue;
                foreach (int x in j[i]) sum += x;
            }
            Console.WriteLine($"Сумма элементов: {sum}");
        }
    }
}