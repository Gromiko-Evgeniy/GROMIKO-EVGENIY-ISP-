using System;
using System.Text;

namespace Lab2._3_ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter lowcase english text:");

            StringBuilder line = new StringBuilder();
            int check = 0;
            int temp = 0;
            while (check == 0)
            {
                check = 1;
                line.Append(Console.ReadLine());

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] >= 'a' && (int)line[i] <= 'z')
                    {
                        temp++;
                    }
                }
                if (temp != line.Length)
                {
                    check = 0;
                    Console.WriteLine("Wrong input. Try again");
                }
            }
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == 'a'
                    || line[i] == 'e'
                    || line[i] == 'i'
                    || line[i] == 'o'
                    || line[i] == 'u'
                    || line[i] == 'y')
                {
                    if (line[i + 1] == 'z')
                    {
                        line[i + 1] = 'a';
                    }
                    else
                    {
                        int ch = line[i + 1];
                        ch++;
                        line[i + 1] = (char)ch;
                    }
                }
            }
            Console.WriteLine(line);
        }


    }
}
