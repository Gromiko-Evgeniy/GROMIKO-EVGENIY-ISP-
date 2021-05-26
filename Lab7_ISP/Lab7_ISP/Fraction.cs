using System;

namespace Lab7_ISP
{
    class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction()
        {
            string input;
            char sign = '+';
            int check = 0;
            while (true)
            {
                Console.WriteLine("\nEnter the numerator");
                input = (Console.ReadLine());

                if (input[0] == '-')
                {
                    sign = '-';
                    input = input.Trim(new char[] { '-' });
                }

                for (int i = 0; i < input.Length; i++)
                {

                    if (input[i] < 48 || input[i] > 57)
                    {

                        Console.WriteLine("Incorrect input, try again.");
                        check = 1;
                        break;
                    }
                }
                if (check == 1)
                {
                    check = 0;
                    continue;
                }
                else
                {
                    Console.WriteLine("Correct input.");
                    if (sign == '-')
                    {
                        numerator = 0 - Convert.ToInt32(input);
                        sign = '+';
                    }
                    else
                    {
                        numerator = Convert.ToInt32(input);
                    }
                }

                //--------------------------------------------------------------------

                Console.WriteLine("\nEnter the denominator");
                input = (Console.ReadLine());
                if (input[0] == '-')
                {
                    sign = '-';
                    input = input.Trim(new char[] { '-' });
                }

                for (int i = 0; i < input.Length; i++)
                {
                    if ((int)input[i] < 49 || (int)input[i] > 57)
                    {
                        Console.WriteLine("Incorrect input, try again.");
                        check = 1;
                        break;
                    }
                }
                if (check == 1)
                {
                    check = 0;
                    continue;
                }
                else
                {
                    Console.WriteLine("Correct input.");
                    if (sign == '-')
                    {
                        if (numerator < 0)
                        {
                            numerator = Math.Abs(numerator);
                            denominator = Convert.ToInt32(input);
                        }
                        else
                        {
                            numerator = 0 - numerator;
                            denominator = Convert.ToInt32(input);
                        }
                        sign = '+';
                    }
                    else
                    {
                        denominator = Convert.ToInt32(input);
                    }
                }

                Console.WriteLine($"your fraction is {numerator}/{denominator}");
                break;
            }
        } // not required by the task, i was wrong. Just skip it if're not interested :(

        public Fraction(int numerator, int denominator) 
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public static int StringCheck(string str) // return 0 if str isn't a fraction, if str is a fraction function returns position of "/"
        {                                         // -xxxx/-xxxx or -xxxx/xxxx 
            int i = 0;
            int signamount = 0; 
            int middlesign = 0; // 1 is "/" exists

            if (str[0] != '-' && (str[0] < 48 || str[0] > 57))
            {
                return 0;
            }
             
            else if (str[0] == '-')
            {
                i++;
                signamount++;
            }
            
            if (i == 1 && (str[1] < 48 || str[1] > 57))
            {
                return 0;
            }

            if (i == 0 && (str[0] < 48 || str[0] > 57))
            {
                return 0;
            }

            if (i == 0 && (str[0] > 47 && str[0] < 58))
            {
                signamount++;
            }

            int temp = 0;
            for (; i < str.Length; i++)
            {
                if ((str[i] < 48 || str[i] > 57) && signamount == 1 && middlesign == 0)
                {
                    if (str[i] == '/')
                    {
                        middlesign = 1;
                        temp = i;
                        continue;
                    }
                    else
                    {
                        return 0;
                    }
                }

                if (middlesign == 1 && signamount == 1 && str[temp + 1] == '-')
                {
                    signamount = 2;
                    i++;
                }

                if (middlesign == 1 && signamount == 2 && (str[i] < 48 || str[i] > 57))
                {
                    return 0;
                }

                Console.WriteLine($"str{i} = {str[i]}");
                Console.WriteLine($"middlesign {i}, {middlesign}");
                Console.WriteLine($"signamount {i}, {signamount}");
            }

            return temp; 
        }

        public Fraction(string str)
        {
            int sign1 = 1, sign2 = 1, middlesign = 0;
            numerator = 0;
            denominator = 0;
            int i = 0;

            if (str[0] == '-')
            {
                sign1 = -1;
                i++;
            }

            int temp = 0;
            for (; i < str.Length; i++)
            {
                if (str[i] == '/')
                {
                    middlesign = 1;
                    temp = i;
                    i++;
                }
                if (str[temp + 1] == '-')
                {
                    sign2 = -1;
                    i++;
                }

                if (middlesign == 0 && str[i] != '/')
                {
                    numerator = numerator * 10 + (str[i] - '0');
                }

                if (middlesign == 1)
                {
                    denominator = denominator * 10 + (str[i] - '0');
                }
            }
            numerator = sign1 * numerator;
            denominator = sign2 * denominator;
        }

        public void ShowFraction() 
        {
            Console.WriteLine($"{numerator}/{denominator}");
        }

        public string ReturnFractionASString()
        {
            string str = Convert.ToString(numerator) + "/" + Convert.ToString(denominator);
            return str;
        }

        public static int GreatestCommonDivisor(int num, int den)
        {
            while (den != 0)
            {
                int temp = den;
                den = num % den;
                num = temp;
            }
            return num;
        }

        public static int LeastCommonMultiple(int num, int den)
        {
            return Math.Abs(num * den / GreatestCommonDivisor(num, den));
        }

        public static Fraction operator + (Fraction Fraction1, Fraction Fraction2)
        {
            Fraction NewFraction = new Fraction(0,0);
            NewFraction.denominator = LeastCommonMultiple(Fraction1.denominator, Fraction2.denominator);
            NewFraction.numerator = NewFraction.denominator / Fraction1.denominator * Fraction1.numerator + NewFraction.denominator / Fraction2.denominator * Fraction2.numerator;
            return NewFraction;
        }

        public static Fraction operator - (Fraction Fraction1, Fraction Fraction2)
        {
            Fraction NewFraction = new Fraction(0,0);
            NewFraction.denominator = LeastCommonMultiple(Fraction1.denominator, Fraction2.denominator);
            NewFraction.numerator = NewFraction.denominator / Fraction1.denominator * Fraction1.numerator - NewFraction.denominator / Fraction2.denominator * Fraction2.numerator;
            return NewFraction;
        }

        public static Fraction operator * (Fraction Fraction1, Fraction Fraction2) 
        {
            Fraction NewFraction = new Fraction(0,0);
            NewFraction.denominator = Fraction1.denominator * Fraction2.denominator;
            NewFraction.numerator = Fraction1.numerator * Fraction2.numerator;
            return NewFraction;
        }

        public static Fraction operator / (Fraction Fraction1, Fraction Fraction2)
        {
            Fraction NewFraction = new Fraction(0,0);
            NewFraction.denominator = Fraction1.denominator * Fraction2.numerator;
            NewFraction.numerator = Fraction1.numerator * Fraction2.denominator;
            return NewFraction;
        }

        public static bool operator > (Fraction Fraction1, Fraction Fraction2)
        {
            Fraction NewFraction = new Fraction(0,0);
            NewFraction = Fraction1 - Fraction2;
            if (NewFraction.numerator > NewFraction.denominator )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator < (Fraction Fraction1, Fraction Fraction2)
        {
            Fraction NewFraction = new Fraction(0, 0);
            NewFraction = Fraction1 - Fraction2;
            if (NewFraction.numerator < NewFraction.denominator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator == (Fraction Fraction1, Fraction Fraction2)
        {
            Fraction NewFraction = new Fraction(0, 0);
            NewFraction = Fraction1 - Fraction2;
            if (NewFraction.numerator - NewFraction.denominator == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator != (Fraction Fraction1, Fraction Fraction2)
        {
            Fraction NewFraction = new Fraction(0, 0);
            NewFraction = Fraction1 - Fraction2;
            if (NewFraction.numerator - NewFraction.denominator != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static implicit operator Fraction(int num)
        {
            Fraction NewFraction = new Fraction(num, 1);
            return NewFraction;
        }

        public static explicit operator int(Fraction Fraction1)
        {
            int num = Fraction1.numerator / Fraction1.denominator;
            return num;
        }
    }
}
