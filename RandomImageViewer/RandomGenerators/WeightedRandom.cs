using System;
using System.Linq;
using RandomImageViewer.Exceptions;
using RandomImageViewer.RandomGenerators;
using RandomImageViewer.Interfaces;

namespace RandomImageViewer
{
    /// <summary>
    /// This class is used to randomly select objects with a weight.
    /// </summary>
    public class WeightedRandom
    {
        private IRandomGenerator _generator; // the generator to use 

        public WeightedRandom() : this(new DefaultRandom()) // empty constructor uses the default random generator
        {
        }

        public WeightedRandom(IRandomGenerator generator) // for a custom generator
        {
            _generator = generator;
        }

        /// <summary>
        /// Randomly chooses an object from <paramref name="objects"/> with weights <paramref name="weights"/>. 
        /// The length of <paramref name="objects"/> must be equal to the length of <paramref name="weights"/> and must also be nonzero.
        /// The weights must also be non-negative.
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="objects">Objects to choose from</param>
        /// <param name="weights">Weights of the objects</param>
        /// <returns>Randomly selected object</returns>
        /// <exception cref="InputArraySizesDifferException">If the sizes of the arrays are not the same</exception>
        /// <exception cref="InputArrayIsEmptyException">If the input array is empty</exception>
        /// <exception cref="NegativeWeightException">If any weight in <paramref name="weights"/> is negative</exception>
        public T Random<T>(T[] objects, int[] weights)
        {
            if (objects.Length != weights.Length) throw new InputArraySizesDifferException();
            if (objects.Length == 0) throw new InputArrayIsEmptyException();
            if (weights.Where(w => w < 0).Any()) throw new NegativeWeightException();

            var weight_sum = weights.Sum();
            var rand_int = _generator.Next(weight_sum);

            for (int i = 0; i<objects.Length; i++)
            {
                if (rand_int < weights[i]) return objects[i];
                rand_int -= weights[i];
            }

            throw new Exception("Arrived at a place you shouldn't be able to");
        }
    }
}
