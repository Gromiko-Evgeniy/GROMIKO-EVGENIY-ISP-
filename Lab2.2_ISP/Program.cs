using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._2_ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter any text:");

            StringBuilder line = new StringBuilder();
            line.Append(Console.ReadLine());

            while (line[1] == ' ')
            {
                line.Remove(0, 1);
            }

            int wordCount = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ' ')
                {
                    wordCount++;
                }
            }
            if (line[line.Length - 1] != ' ')
            {
                wordCount++;
            }
            if (line[wordCount - 1] != ' ')
            {
                line.Append(" ");
            }
            Console.WriteLine($"wordCount = {wordCount}");

            string[] arrString = new string[wordCount];
            for (int j = 0; j < wordCount; j++)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != ' ')
                    {
                        arrString[j] += line[i].ToString();
                    }
                    else
                    {
                            line.Remove(0, ++i);
                            break;
                    }
                }
                Console.WriteLine($"j= {j}");
                Console.WriteLine(arrString[j]);
            }

            for (int i = wordCount-1; i >= 0; i--)
            {
                line.Append(arrString[i] + " ");            
            }
            Console.WriteLine($"line = {line}");
        }
    }
}
