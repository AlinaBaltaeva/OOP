using System;
using System.Collections.Generic;

namespace Lab11
{
    public class HashtableTask
    {

        private Entry[] table;
        private int size;
        private int count;          
        public double LoadFactor//коэфф заполнения хэш-таблицы
        {
           get => (double) count / size;
        }
        public int Count
        {
            get => count;
        }
        public int Size
        {
            get => size;
        }
        public HashtableTask(int size = 11)
        {
            if (size < 2) size = 2;
            this.size = size;
            table = new Entry[size];
            count = 0;
        }


        private int Hash(string key)
        {
            int code = 0;
            foreach (char c in key) code += (int)c;
            return Math.Abs(code) % Size;
            //Получение кода Unicode с помощью char и явного приведения int, далее получаем остаток от деления
        }

        public bool Add(string key, Student student)
        {
            if (string.IsNullOrEmpty(key) || student == null) 
                return false;   
            if ((double)Count / Size >= 0.7)//Если коэфф заполнения больше 70 - расширяем, чтоб не было проблем с памятью
            {
                Rehash();
            }

            int index = Hash(key);
            int startIndex = index;
            int firstDeleted = -1;
            for (int i = 0; i < size; i++)
            {
                int cur = (index + i) % size;
                //Занята ли ячейка с этим ключом
                if (table[cur].IsOccupied && table[cur].Key == key)
                {
                    table[cur].Value = student;
                    return true;
                }
                //Оставляем isDeleted - это флаг того что элемент перенесен и нужно искать дальше
                if (table[cur].IsDeleted && firstDeleted == -1)
                    firstDeleted = cur;
                if (!table[cur].IsOccupied)
                {
                    int insertAt = (firstDeleted != -1) ? firstDeleted : cur;
                    table[insertAt].Key = key;
                    table[insertAt].Value = student;
                    table[insertAt].IsOccupied = true;
                    table[insertAt].IsDeleted = false;
                    count++;
                    return true;
                }
            }

            return false;
        }

        // Поиск по ключу
        public Student Find(string key)
        {
            int index = Hash(key);

            for (int i = 0; i < Size; i++)
            {
                int cur = (index + i) % Size;

                //Нет флага на занятость ячейки и удаленность, значит нет такого ключа
                if (!table[cur].IsOccupied && !table[cur].IsDeleted)
                    return null;

                if (table[cur].IsOccupied && table[cur].Key == key)
                    return table[cur].Value;
            }
            return null;
        }
        public bool Remove(string key)
        {
            int index = Hash(key);

            for (int i = 0; i < Size; i++)
            {
                int cur = (index + i) % Size;//Чтоб точно попасть в хэш-таблицу и не выйти за него

                if (!table[cur].IsOccupied && !table[cur].IsDeleted)
                    return false;

                if (table[cur].IsOccupied && table[cur].Key == key)
                {
                    table[cur].IsOccupied = false;
                    table[cur].IsDeleted = true;
                    table[cur].Key = null;
                    table[cur].Value = null;
                    count--;
                    return true;
                }
            }

            return false;
        }

        // Удвоим размер хэш-таблицы
        private void Rehash()
        {
            var oldTable = table;
            int newSize = 0;
            if (isSimple((Size * 2)+1))
                newSize = (Size * 2)+1;
            else
            {
                int i = 1;
                while (isSimple(newSize) == false)
                {
                    i++;
                    newSize = Size * 2 + i;
                }
            }
            size = newSize;
            table = new Entry[Size];
            count = 0;

            foreach (var e in oldTable)
            {
                if (!e.IsOccupied) continue;

                int index = Hash(e.Key);
                for (int i = 0; i < size; i++)
                {
                    int cur = (index + i) % size;
                    if (!table[cur].IsOccupied)
                    {
                        table[cur].Key = e.Key;
                        table[cur].Value = e.Value;
                        table[cur].IsOccupied = true;
                        count++;
                        break;
                    }
                }
            }
        }
        private bool isSimple(int sizeHash)
        {
            for (int i=2; i < Math.Sqrt(sizeHash)+1; i++)//Если ничего не поделится => простое число
            {
                if(sizeHash % i ==0)
                {
                    return false;
                }
            }
            return true;
        }

        public void Print()
        {
            Console.WriteLine($"Хеш-таблица (размер {Size}, элементов {Count}, заполнение {Math.Round(LoadFactor*100,0)}%):");
            for (int i = 0; i < Size; i++)
            {
                Console.Write($"[{i,2}] ");
                if (table[i].IsOccupied)
                    Console.WriteLine($"\"{table[i].Key}\" -> {table[i].Value.Name}");
                else if (table[i].IsDeleted)
                    Console.WriteLine("<удалено>");
                else
                    Console.WriteLine("—");
            }
        }
    }
}