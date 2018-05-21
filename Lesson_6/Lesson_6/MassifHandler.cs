using System;
using System.Threading.Tasks;

namespace Lesson_6
{
    public class MassifHandler
    {
        private const int _size = 100;
        private int[,] _arrayX;
        private int[,] _arrayY;
        private int[,] _arrayResult;
        private Random _rnd;

        public MassifHandler()
        {
            _arrayX = new int[_size, _size];
            _arrayY = new int[_size, _size];
            _arrayResult = new int[_size, _size];
            _rnd = new Random();
            Console.SetWindowSize(10, 60);
            Console.SetWindowSize(205, 63);
            Console.ForegroundColor = ConsoleColor.Green;
            Initializer();
        }

        private void Initializer()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _arrayX[i, j] = _rnd.Next(1, 10);
                    _arrayY[i, j] = _rnd.Next(1, 10);
                }
            }
        }

        public void ShowArray()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write( "{0} ", _arrayX[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write("{0} ", _arrayY[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private Task ShowTask()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < _size; i++)
                {
                    for (int j = 0; j < _size; j++)
                    {
                        Console.Write("{0} ", _arrayResult[i, j]);
                    }

                    Console.WriteLine();
                }
            });           
        }

        private Task MultiplyTask()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < _size; i++)
                {
                    for (int j = 0; j < _size; j++)
                    {
                        for (int k = 0; k < _size; k++)
                        {
                            _arrayResult[i, j] += _arrayX[i, k] * _arrayY[k, j];
                        }
                    }
                }
            });
        }

        public async void TaskRun()
        {
            Task[] tasks = new Task[2];

            tasks[0] = MultiplyTask();
            tasks[1] = ShowTask();

            await Task.WhenAll(tasks);
        }

        public async void MultiplyAsync()
        {
            await MultiplyTask();
        }

        public async void ShowAsync()
        {
            await ShowTask();
        }

        public void MultiplyDebug()
        {
            _arrayResult[0, 0] = _arrayX[0, 0] * _arrayY[0, 0] + _arrayX[0, 1] * _arrayY[1, 0];
            _arrayResult[1, 0] = _arrayX[1, 0] * _arrayY[0, 0] + _arrayX[1, 1] * _arrayY[1, 0];
            _arrayResult[0, 1] = _arrayX[0, 0] * _arrayY[0, 1] + _arrayX[0, 1] * _arrayY[1, 1];
            _arrayResult[1, 1] = _arrayX[1, 0] * _arrayY[0, 1] + _arrayX[1, 1] * _arrayY[1, 1];
        }

        private void InitializerDebug()
        {
            _arrayX[0, 0] = 1;
            _arrayX[0, 1] = 2;
            _arrayX[1, 0] = 3;
            _arrayX[1, 1] = 4;

            _arrayY[0, 0] = 5;
            _arrayY[0, 1] = 6;
            _arrayY[1, 0] = 7;
            _arrayY[1, 1] = 8;
        }
    }
}
