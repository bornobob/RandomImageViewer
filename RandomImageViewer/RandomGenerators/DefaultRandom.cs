using System;
using RandomImageViewer.Interfaces;

namespace RandomImageViewer.RandomGenerators
{
    /// <summary>
    /// DefaultRandom simulates the default Random implementation
    /// </summary>
    public class DefaultRandom : IRandomGenerator
    {
        private Random _random;

        public DefaultRandom()
        {
            _random = new Random();
        }

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }
    }
}
