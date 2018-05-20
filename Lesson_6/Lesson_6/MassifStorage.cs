using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    class MassifStorage
    {
        private int[,] _arrayX;
        private int[,] _arrayY;

        public MassifStorage()
        {
            _arrayX = new int[Size, Size];
            _arrayY = new int[Size, Size];
        }

        public int Size { get; set; }

        public int[,] ArrayX { get; set; }

        public int[,] ArrayY { get; set; }
    }
}
