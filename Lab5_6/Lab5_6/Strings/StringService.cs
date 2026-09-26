using System;

namespace Lab5_6.Strings
{
    public static class StringService
    {
        public static string GetTestString()
        {
            return "В лесу родилась елочка. В лесу она росла. Зимой и летом стройная, зеленая была.";
        }

        public static void Print(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Строка пуста.");
                return;
            }
            Console.WriteLine($"Строка: {s}");
            Console.WriteLine($"Длина: {s.Length}");
        }

        public static void Process(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Строка пуста, обрабатывать нечего.");
                return;
            }

            Console.WriteLine("Обработка (заглушка):");

            Console.WriteLine(" Разбиение на предложения:");
            string[] sentences = s.Split(new[] { '.', '!', '?' },
                                         StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sentences.Length; i++)
                Console.WriteLine($"   {i + 1}: {sentences[i].Trim()}");

            Console.WriteLine(" Разбиение на слова:");
            char[] separators = { ' ', ',', ';', ':', '.', '!', '?' };
            string[] words = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
                Console.WriteLine($"   {i + 1}: {words[i]}");

            Console.WriteLine(" Верхний регистр всей строки:");
            Console.WriteLine("   " + s.ToUpper());

            Console.WriteLine(" Первое вхождение 'елочка':");
            int pos = s.IndexOf("елочка");
            Console.WriteLine(pos >= 0 ? $"   позиция {pos}" : "   не найдено");
        }
    }
}