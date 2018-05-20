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
            Console.Write("Задание а\n");
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
                thread.Join();
            }

            //b. сумму целых чисел до N

            int value;
            Arguments arg2 = new Arguments()
            {
                ListValues = new List<int>()
            };

            Console.WriteLine("\n\n\n");          
            
            string console;

            Console.WriteLine("Задание b");
            Console.WriteLine("Вводите числа, подтверждая ввод нажатием Enter");
            Console.WriteLine("Для выхода наберите null\n");

            do
            {
                console = Console.ReadLine();
                
                if (int.TryParse(console, out value))
                {
                    arg2.ListValues.Add(value);
                }
            }
            while (console.ToLowerInvariant() != "null");          

            SummValue sum = new SummValue(arg2.ListValues);

            Thread thread2 = new Thread(new ThreadStart(sum.Run))
            {
                Priority = ThreadPriority.Highest,
                Name = "Вторичный поток"
            };

            thread2.Start();
            thread2.Join();

            Console.ReadLine();
        }
    }
}
