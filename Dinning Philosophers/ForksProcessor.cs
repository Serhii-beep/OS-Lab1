using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Dinning_Philosophers
{
    public class ForksProcessor
    {
        private Fork[] _forks;

        public ForksProcessor(int n)
        {
            _forks = new Fork[n];
            for(int i = 0; i < n; ++i)
            {
                _forks[i] = new Fork();
                _forks[i].IsAvailable = true;
            }
        }

        public void GetForks(int leftFork, int rightFork)
        {
            lock(this)
            {
                while(!_forks[leftFork].IsAvailable || !_forks[rightFork].IsAvailable)
                {
                    Monitor.Wait(this);
                }
                _forks[leftFork].IsAvailable = false;
                _forks[rightFork].IsAvailable = false;
            }
        }

        public void PutForks(int leftFork, int rightFork)
        {
            lock(this)
            {
                _forks[leftFork].IsAvailable = true;
                _forks[rightFork].IsAvailable = true;
                Monitor.PulseAll(this);
            }
        }
    }
}
