using System;

namespace uniq
{
    public class Money
    {
        public int rubles;
        public int kopeks;
        static int count = 0;

        public Money()
        {
            rubles = 0;
            kopeks = 0;
            count++;
        }

        public Money(int rubles, int kopeks)
        {
            this.rubles = rubles;
            this.kopeks = kopeks;
            FixMoney();
            count++;
        }

        public Money(Money other)
        {
            rubles = other.rubles;
            kopeks = other.kopeks;
            FixMoney();
            count++;
        }

        private void FixMoney()
        {
            if (kopeks >= 100 || kopeks < 0)
            {
                rubles += kopeks / 100;
                kopeks = kopeks % 100;

                if (kopeks < 0)
                {
                    rubles--;
                    kopeks += 100;
                }
            }
        }

        public string MoneyString()
        {
            string kopeksStr = kopeks < 10 ? "0" + kopeks : kopeks.ToString();
            return rubles + "," + kopeksStr + " руб.";
        }

        public string Show()
        {
            return MoneyString();
        }

        public void ShowMoney()
        {
            Console.WriteLine(MoneyString());
        }

        public Money AddKopeksMethod(int extraKopeks)
        {
            Money result = new Money(this.rubles, this.kopeks + extraKopeks);
            return result;
        }

        public static Money AddKopeksStatic(Money money, int extraKopeks)
        {
            return new Money(money.rubles, money.kopeks + extraKopeks);
        }

        public static int ObjectsCount()
        {
            return count;
        }

        public static Money operator ++(Money money)
        {
            return new Money(money.rubles, money.kopeks + 1);
        }

        public static Money operator --(Money money)
        {
            return new Money(money.rubles, money.kopeks - 1);
        }

        public static Money operator +(Money money, int addedValue)
        {
            return new Money(money.rubles + addedValue, money.kopeks);
        }

        public static Money operator +(Money money1, Money money2)
        {
            return new Money(money1.rubles + money2.rubles, money1.kopeks + money2.kopeks);
        }

        public static implicit operator int(Money money)
        {
            return money.rubles;
        }

        public static explicit operator double(Money money)
        {
            return money.rubles + (double)money.kopeks / 100.0;
        }

        public static bool operator >(Money money1, Money money2)
        {
            if (money1.rubles != money2.rubles)
                return money1.rubles > money2.rubles;
            return money1.kopeks > money2.kopeks;
        }

        public static bool operator <(Money money1, Money money2)
        {
            if (money1.rubles != money2.rubles)
                return money1.rubles < money2.rubles;
            return money1.kopeks < money2.kopeks;
        }

        public override string ToString()
        {
            return MoneyString();
        }
    }
}