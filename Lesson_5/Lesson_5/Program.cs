using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_5
{
    class Program
    {
        //1. Написать приложение, считающее в раздельных потоках:
        static void Main(string[] args)
        {
            //a. факториал числа N, которое вводится с клавиатуру; 
            Console.Write("Введите число : ");

            Arguments arg = new Arguments()
            {
                Value = double.Parse(Console.ReadLine())
            };

            Factorial threadFactorial = new Factorial(arg.Value);
            for (ulong i = 0; i < arg.Value; i++)
            { 
                Thread thread = new Thread(new ThreadStart(threadFactorial.Run))
                {
                    Priority = ThreadPriority.Highest,
                    Name = "Вторичный поток"
                };

                thread.Start();
            }

            //b. сумму целых чисел до N
            Arguments arg2 = new Arguments()
            {
                ListValues = new List<int>() { 1, 2, 3, 4, 5 }
            };

            SummValue sum = new SummValue(arg2.ListValues);

            Thread thread2 = new Thread(new ThreadStart(sum.Run))
            {
                Priority = ThreadPriority.Highest,
                Name = "Вторичный поток"
            };

            thread2.Start();

            Console.ReadLine();
        }
    }
}
