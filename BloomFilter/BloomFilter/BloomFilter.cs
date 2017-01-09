using System;
using System.Collections;

namespace BloomFilterApp
{
    public class BloomFilter
    {
        //Left as Max, since we didn't stipulate any other constraints
        private readonly BitArray _bloomArray = new BitArray(int.MaxValue);

        public void Add(string thingToRember)
        {
            var hash = HashString(thingToRember);

            _bloomArray[hash] = true;
        }

        private int HashString(string stringToRemember)
        {
            var hasher = new Hasher();
            var firstHash = hasher.Hash(stringToRemember);
            var secondHash = firstHash.GetHashCode();
            return Math.Abs(secondHash);
        }

        public bool WasAdded(string stringToRemember)
        {
            if (ProbablyHasBeenAdded(stringToRemember)) return true;
            return false;
        }

        private bool ProbablyHasBeenAdded(string thingToRemember)
        {
            var hash = HashString(thingToRemember);

            return _bloomArray[hash];
        }
    }
}