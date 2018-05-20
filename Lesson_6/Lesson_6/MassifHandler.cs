using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lesson_6
{
    public class MassifHandler
    {
        private const int _size = 2;
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
            //Initializer();
            InitializerDebug();
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

        private void InitializerDebug()
        {
            _arrayX[0,0] = 1;
            _arrayX[0,1] = 2;
            _arrayX[1,0] = 3;
            _arrayX[1,1] = 4;

            _arrayY[0, 0] = 5;
            _arrayY[0, 1] = 6;
            _arrayY[1, 0] = 7;
            _arrayY[1, 1] = 8;
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
        }

        public void ShowArrayRes()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write("{0} ", _arrayResult[i, j]);
                }

                Console.WriteLine();
            }
        }

        public void Multiply()
        {
            _arrayResult[0,0] = _arrayX[0,0] * _arrayY[0,0] + _arrayX[0,1] * _arrayY[1,0];
            _arrayResult[1,0] = _arrayX[1,0] * _arrayY[0,0] + _arrayX[1,1] * _arrayY[1,0];
            _arrayResult[0,1] = _arrayX[0,0] * _arrayY[0,1] + _arrayX[0,1] * _arrayY[1,1];
            _arrayResult[1,1] = _arrayX[1,0] * _arrayY[0,1] + _arrayX[1,1] * _arrayY[1,1];
        }


        public void Matr()
        {

        }

        public void MultiplyRun()
        {
            /*
               1 2   5 6
               3 4   7 8

               1*5 2*6
               3*7 4*8
               
               5    12
               
               21   32
             
             */
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        int a = _arrayX[i, j] * _arrayY[i, j];

                    }
                    else
                    {
                        int a = _arrayX[i, j] * _arrayY[i, j];
                    }
                }
            }
        }
    }
}
