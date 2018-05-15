using System;
using System.Threading;

namespace Lesson_5
{
    public class Factorial
    {
        private int _num;
        private int _factorial;
        private object _lock;
        private int _i;

        public Factorial(int num)
        {
            _num = num;
            _lock = new object();
            _i = 1;
            _factorial = 1;
        }

        public void Run()
        {
            lock (_lock)
            {
                if (_i <= _num)
                {
                    _factorial *= _i;
                }

                _i++;
                
                Console.WriteLine($"{Thread.CurrentThread.Name} _factorial {_num} = {_factorial}");
            }
        }
    }
}
