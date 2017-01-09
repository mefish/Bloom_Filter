using System;
using System.Collections;

namespace BloomFilterApp
{
    public class BloomFilter
    {
        //        private readonly List<string> _thingsToRemember = new List<string>();

        private BitArray _bitArray = new BitArray(int.MaxValue);

        public void Remember(string thingToRember)
        {
            var hash = HashString(thingToRember);

            _bitArray[hash] = true;
        }

        private int HashString(string thingToRember)
        {
            var hasher = new Hasher();

            var firstHash = hasher.Hash(thingToRember);
            var secondHash = firstHash.GetHashCode();
            return Math.Abs(secondHash);
        }

        public bool DidRemember(string thingToRemember)
        {
            if (HasBeenRemembered(thingToRemember)) return true;
            return false;
        }

        private bool HasBeenRemembered(string thingToRemember)
        {
            var hash = HashString(thingToRemember);

            return _bitArray[hash];
        }
    }
}