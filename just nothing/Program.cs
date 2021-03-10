using System;

namespace just_nothing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("instructions: you have 10 attempts. Good luck");
            Console.WriteLine("do you wanna play? (y/n)");
            string answer1 = Console.ReadLine();
            int money = 100;
            do
            {
                if (answer1 == "y")
                {
                    for (int h = 0; h < 10; h++)
                    {
                        string answer2 = "y";
                        if (h > 0)
                        {
                            Console.WriteLine("Wanna try again? (y/n)");
                            answer2 = Console.ReadLine();
                        }

                        if (answer2 == "y")
                        {
                            Console.Clear();
                            Console.WriteLine($"Attempt number {h}");

                            char[] charArray = new char[3] { '#', '@', '&' };
                            char[,] characters = new char[3, 5];
                            Random rnd = new Random();

                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    characters[i, j] = charArray[rnd.Next(3)];
                                }
                            }

                            Console.WriteLine("\n\n");
                            Console.WriteLine("\t____________________________________");

                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    Console.Write("\t  " + characters[i, j] + "  ");
                                }
                                Console.WriteLine("\n\n");
                            }

                            int result1 = 0;


                            for (int j = 0; j < 5; j++)
                            {
                                for (int i = 1; i < 3; i++)
                                {
                                    if (characters[0, j] == characters[i, j])
                                    {
                                        result1++;
                                    }
                                    else
                                    {
                                        result1 = 0;
                                        break;
                                    }
                                }
                                if (result1 == 2)
                                {
                                    Console.WriteLine($"совпал {j} столбец");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"{j} столбец не совпал ");
                                }
                            }

                            Console.WriteLine(result1);
                            int result2 = 0;


                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 1; j < 5; j++)
                                {
                                    if (characters[i, 0] == characters[i, j])
                                    {
                                        result2++;
                                    }
                                    else
                                    {
                                        result2 = 0;
                                        break;
                                    }
                                }

                                if (result2 == 4)
                                {
                                    Console.WriteLine($"совпала {i} строка");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"{i} строка не совпала ");
                                }
                            }

                            Console.WriteLine(result2);

                            if (result1 == 0 && result2 == 0)
                            {
                                Console.WriteLine("So soory, but you're out of luck");
                                money -= 10;
                            }
                            else if (result1 == 2 && result2 == 0)
                            {
                                Console.WriteLine("Wow, you're lucky");
                                money += 20;
                            }
                            else if (result2 == 4 && result1 == 0)
                            {
                                Console.WriteLine("Great! You're so lucky");
                                money += 30;
                            }
                            else if (result1 + result2 == 6)
                            {
                                Console.WriteLine("Incredible! You're very lucky");
                                money += 40;
                            }
                            Console.WriteLine($"Ok, your score is {money}");

                        }
                        else if (answer2 == "n")
                        {
                            Console.WriteLine($"Ok, your total score is {money}");
                            break;

                        }
                        else
                        {
                            Console.WriteLine("wrong answer(y/n)");

                        }
                    }
                }
                else if (answer1 == "n")
                {
                    Console.WriteLine("Ok, i hope i'll see you again");

                }
                else
                {
                    Console.WriteLine("Wrong answer.(You should enter y/n)");
                    string answer3 = Console.ReadLine();
                    answer1 = answer3;
                }

            } while ( answer1 != "n");
            Console.WriteLine("Ok, i hope i'll see you again. Bye)");
        }     
    }
}
