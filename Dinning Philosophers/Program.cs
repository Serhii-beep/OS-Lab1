using System;

namespace Dinning_Philosophers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            ForksProcessor forksProcessor = new ForksProcessor(n);
            for(int i = 0; i < n; ++i)
            {
                new Philosopher(i, forksProcessor);
            }
        }
    }
}
