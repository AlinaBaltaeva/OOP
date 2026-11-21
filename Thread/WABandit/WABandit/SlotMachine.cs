using System;
using System.Threading;

namespace Lab15_WPF
{
    public class SlotMachine
    {
        private Thread[] threads;
        private int[] reelValues;
        private Random random;
        private bool isSpinning;
        private ManualResetEvent stopEvent;
        private object lockObject = new object();
        private string resultMessage;
        private bool usePriorities;

        public SlotMachine()
        {
            threads = new Thread[3];
            reelValues = new int[3];
            random = new Random();
            isSpinning = false;
            stopEvent = new ManualResetEvent(false);
            resultMessage = "";
            usePriorities = false;
        }

        public void SetPriorities(bool enable)
        {
            usePriorities = enable;
        }

        private void SpinReel(object indexObj)
        {
            int index = (int)indexObj;

            while (true)
            {
                if (stopEvent.WaitOne(0))
                {
                    break;
                }
                int value;
                lock (lockObject)
                {
                    value = random.Next(0, 10);
                    reelValues[index] = value;
                }

                Thread.Sleep(150);
            }
        }

        public void Start()
        {
            if (isSpinning) return;

            isSpinning = true;
            stopEvent.Reset();

            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(SpinReel);

                if (usePriorities)
                {
                    if (i == 0) threads[i].Priority = ThreadPriority.Lowest;
                    else if (i == 1) threads[i].Priority = ThreadPriority.Normal;
                    else threads[i].Priority = ThreadPriority.Highest;
                }

                threads[i].Start(i);
            }
        }

        public void Stop()
        {
            if (!isSpinning) return;

            stopEvent.Set();

            for (int i = 0; i < 3; i++)
            {
                if (threads[i] != null && threads[i].IsAlive)
                {
                    threads[i].Join(100);
                }
            }

            isSpinning = false;
            AnalyzeCombination();
        }

        public void Reset()
        {
            Stop();
            lock (lockObject)
            {
                reelValues[0] = 0;
                reelValues[1] = 0;
                reelValues[2] = 0;
            }
            resultMessage = "";
        }

        private void AnalyzeCombination()
        {
            int a = reelValues[0];
            int b = reelValues[1];
            int c = reelValues[2];

            string[] jackpotMessages =
            {
                " ДЖЕКПОТ! 🎉 Казино в шоке! Вы только что обанкротили заведение!",
                " ТРИ ОДИНАКОВЫХ! Бухгалтер плачет, крупье увольняется!",
                " ДЕНЬГИ РЕКОЙ! Покупайте остров, пока не передумали!",
                " УДАЧА ЛЫСАЯ! Схватили за хвост!",
                " СЛОТОМАТ СДОХ! Вы выиграли всё, включая сам автомат!"
            };

            string[] sevenMessages =
            {
                " 777! ВЕЗЕНИЕ 777%! Казино закрывается на ремонт после вас!",
                " БРИЛЛИАНТОВАЯ СЕМЕРКА! Вы богаче, чем Дональд Дак!",
                " КОРОЛЬ КАЗИНО! Охрана выносит вас на руках!"
            };

            string[] oneMessages =
            {
                " ТРИ ЕДИНИЦЫ! Вы заняли первое, первое и первое место!",
                " ТОЧНО В ЦЕЛЬ! Даже снайпер позавидует!",
                " ВАМ ЗВОНИТ ПУТИН! Хочет узнать секрет успеха!"
            };

            string[] twoOnesMessages =
            {
                " ДВЕ ЕДИНИЦЫ — ДВА ДРУГА! Где третий, непонятно, но приз даем!",
                " ПОЧТИ ДЖЕКПОТ! Одна единица сбежала в отпуск!",
                " ИЩЕМ ТРЕТЬЮ ЕДИНИЦУ! Нашедшему — бонус!"
            };

            string[] pairMessages =
            {
                " ИДЕАЛЬНАЯ ПАРА! Поженить их?",
                " ДУБЛЬ! В нарды бы так везло!"
            };

            string[] fourMessages =
            {
                " НА ЧЕТВЕРКЕ КАТАЕМСЯ! Не на мерсе, но тоже приятно!",
                "ЧЕТВЕРОЧКА ПОЧТИ ЧТО ПЯТЕРОЧКА!"
            };

            string[] loseMessages =
            {
                " КАЗИНО НЕ ЛЮБИТ БЕДНЫХ!",
                " ЕЩЕ КРУТОЧКА? Следующая точно джекпот!"
            };

            Random rnd = new Random();
            string message = "";

            if (a == 7 && b == 7 && c == 7)
            {
                message = $" {sevenMessages[rnd.Next(sevenMessages.Length)]} ✨✨✨";
            }
            else if (a == 1 && b == 1 && c == 1)
            {
                message = $" {oneMessages[rnd.Next(oneMessages.Length)]} 🎖️🎖️🎖️";
            }
            else if (a == b && b == c)
            {
                message = $" {jackpotMessages[rnd.Next(jackpotMessages.Length)]} 💎💎💎";
            }
            else if ((a == 1 && b == 1) || (a == 1 && c == 1) || (b == 1 && c == 1))
            {
                message = $" {twoOnesMessages[rnd.Next(twoOnesMessages.Length)]} 🎭";
            }
            else if (a == b || a == c || b == c)
            {
                string pairDetail = "";
                if (a == b) pairDetail = $"  {a} и {b} совпадают";
                else if (a == c) pairDetail = $"  {a} и {c} совпадают";
                else if (b == c) pairDetail = $"  {b} и {c} совпадают";
                message = $" {pairMessages[rnd.Next(pairMessages.Length)]} \n{pairDetail}";
            }
            else if (a == 4 || b == 4 || c == 4)
            {
                message = $" {fourMessages[rnd.Next(fourMessages.Length)]} ";
            }
            else
            {
                message = $" {loseMessages[rnd.Next(loseMessages.Length)]} ";
            }

            resultMessage = $"{message}\n\nРезультат: {a} {b} {c}";
        }

        public string GetResultMessage()
        {
            return resultMessage;
        }

        public int[] GetCurrentValues()
        {
            lock (lockObject)
            {
                return (int[])reelValues.Clone();
            }
        }

        public bool IsSpinning => isSpinning;
    }
}