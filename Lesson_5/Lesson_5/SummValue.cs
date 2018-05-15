using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_5
{
    public class SummValue
    {
        private List<int> _values;
        private object _lock;
        public SummValue(List<int> values)
        {
            _values = values;
            _lock = new object();
        }

        public void Run()
        {
            lock (_lock)
            {
                Console.WriteLine($"Sum value: {_values.Sum(x => x)}");
            }
        }
    }
}
