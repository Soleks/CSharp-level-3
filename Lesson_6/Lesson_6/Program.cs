using System;

namespace Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            MassifHandler mh = new MassifHandler();

            mh.ShowArray();
            mh.TaskRun();

            Console.ReadLine();
        }
    }
}
