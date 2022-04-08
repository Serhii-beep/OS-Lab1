using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Dinning_Philosophers
{
    public class Philosopher
    {
        private int number;
        private int leftFork;
        private int rightFork;
        private ForksProcessor _forks;

        public Philosopher(int n, ForksProcessor forks)
        {
            number = n;
            leftFork = (n + 1) % 5;
            rightFork = n;
            _forks = forks;
            new Thread(new ThreadStart(Run)).Start();
        }

        public void Run()
        {
            while(true)
            {
                Console.WriteLine($"#{ number } philosopher thinks");
                Thread.Sleep(new Random().Next(3000, 5000));
                Console.WriteLine($"#{ number } philosopher is hungry");
                _forks.GetForks(leftFork, rightFork);
                Console.WriteLine($"#{ number } philosopher is eating");
                Thread.Sleep(new Random().Next(3000, 5000));
                _forks.PutForks(leftFork, rightFork);
            }
        }
    }
}
