using System;
using System.Threading;

namespace Lesson_5
{
    class Program
    {
        private static object lockObject = new object();
        static void Main(string[] args)
        {
            Console.Write("Введите число : ");

            Arguments arg = new Arguments()
            {
                Value = int.Parse(Console.ReadLine())
            };

            Factorial threadFactorial = new Factorial(arg.Value);

            for (int i = 0; i < arg.Value; i++)
            { 
                Thread thread = new Thread(new ThreadStart(threadFactorial.Run))
                {
                    Priority = ThreadPriority.Highest,
                    Name = "Вторичный поток"
                };

                thread.Start();
            }          

            Console.WriteLine("Ждем окончания работы потока.");           

            Console.ReadLine();
        }
    }
}
