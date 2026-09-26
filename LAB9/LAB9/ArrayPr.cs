using System;

namespace uniq
{
    public class MoneyArray
    {
        public Money[] array;
        public int size;

        public MoneyArray()
        {
            array = new Money[0];
            size = 0;
        }

        public MoneyArray(int inputSize)
        {
            if (inputSize < 0)
                throw new ArgumentException("Неверно введен размер массива");

            array = new Money[inputSize];
            size = inputSize;
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                int rubles = random.Next(0, 200);
                int kopeks = random.Next(0, 100);
                array[i] = new Money(rubles, kopeks);
            }
        }

        public MoneyArray(int inputSize, int type)
        {
            if (inputSize < 0)
                throw new ArgumentException("Размер массива не может быть отрицательным!");

            array = new Money[inputSize];
            size = inputSize;
            if (type == 1)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.Write("Введите кол-во рублей: ");
                    int rubles = ReadInt();
                    Console.Write("Введите кол-во копеек: ");
                    int kopeks = ReadInt();
                    array[i] = new Money(rubles, kopeks);
                }
            }
        }

        public void Show()
        {
            if (size == 0)
            {
                Console.WriteLine("Массив пустой!");
                return;
            }

            Console.Write("Массив: {");
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine($"}}\nВведено {size} элементов");
        }

        private int ReadInt()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                    return result;
                Console.Write("Неправильно, введите целое число: ");
            }
        }
    }
}