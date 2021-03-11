using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._1_ISP
{
    class Program
    {
        static void ZeroCounter(string dateTime)
        {
            int numberOfZeros = 0;
            for (int i = 0; i < dateTime.Length; i++)
            {
                if (dateTime[i] == '0')
                {
                    numberOfZeros++;
                }
            }
            Console.WriteLine($"\ncurrent date & time: {dateTime}");
            Console.WriteLine($"number of zeros in this format: {numberOfZeros}");
        }

        static void Main(string[] args)
        {
            string dateTime1 = DateTime.Now.ToString();
            ZeroCounter(dateTime1);

            string dateTime2 = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
            ZeroCounter(dateTime2);
        }
    }
}
