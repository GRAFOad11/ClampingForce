using System;

namespace MouldingApp
{
    public class Statiscics
    {
        public double High;
        public double Low;
        public double Width;
        public double Hight;
        public double Sum;
        public int Count;
        public Statiscics()
        {
            Count = 0;
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public double Averadge
        {
            get
            {
                return Sum / Count;
            }
        }
        public void Add(string number)
        {
            Console.WriteLine($"{number}");
            /*--------------------NOT USED-----------------------
            Sum += number;
            Count++;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
            */
        }
    }
}