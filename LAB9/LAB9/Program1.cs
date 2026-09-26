using System;

namespace uniq
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Класс Money с полями (rubles, kopecks) рублей");
                Console.Write("Ура, у вас есть деньги, введите целое количество рублей: ");
                int rubles = ReadInt();
                Console.Write("Введите количество копеек в вашем кошельке: ");
                int kopeks = ReadInt();

                Money moneyo = new Money(rubles, kopeks);
                Console.WriteLine($"Введено: {moneyo}");

                moneyo++;
                Money moneyPlus = moneyo;
                Console.WriteLine($"Money++: {moneyPlus}");

                moneyo--;
                Money moneyMinus = moneyo;
                Console.WriteLine($"Money--: {moneyMinus}");

                Console.Write("Money + int: ");
                Money otherMoney = moneyo + rubles;
                Console.WriteLine($"Money + int: {otherMoney}");

                Money sumMoney = moneyo + otherMoney;
                Console.WriteLine($"Money + otherMoney: {sumMoney}");

                int intMoney = moneyo;
                double doubleMoney = (double)moneyo;
                Console.WriteLine($"(int)Money: {intMoney}");
                Console.WriteLine($"(double)Money: {doubleMoney:F1}");

                Console.Write("Введите количество новых кошельков: ");
                int count = ReadPositiveInt();

                MoneyArray array = new MoneyArray(count, 1);
                MoneyArray randomArray = new MoneyArray(count);

                array.Show();
                randomArray.Show();

                Money maxArray = FindMax(array);
                Money maxRandomArray = FindMax(randomArray);

                Console.WriteLine($"Максимальное число array: {maxArray}");
                Console.WriteLine($"Максимальное число randomArray: {maxRandomArray}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static Money FindMax(MoneyArray moneyArray)
        {
            Money max = moneyArray.array[0];
            for (int i = 1; i < moneyArray.size; i++)
            {
                if (moneyArray.array[i] > max)
                    max = moneyArray.array[i];
            }
            return max;
        }

        static int ReadInt()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                    return result;
                Console.Write("Ошибка ввода! Введите целое число: ");
            }
        }

        static int ReadPositiveInt()
        {
            while (true)
            {
                int result = ReadInt();
                if (result >= 0)
                    return result;
                Console.Write("Ошибка ввода! Введите неотрицательное число: ");
            }
        }
    }
}