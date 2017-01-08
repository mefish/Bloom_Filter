using System.Collections;

namespace BloomFilterApp
{
    public class BloomFilter
    {
        //        private readonly List<string> _thingsToRemember = new List<string>();

        private BitArray _bitArray = new BitArray(128);

        public void Remember(string thingToRember)
        {
            var hash = HashString(thingToRember);

            _bitArray = _bitArray.Or(hash);
        }

        private static BitArray HashString(string thingToRember)
        {
            var hasher = new Hasher();

            var hash = hasher.Hash(thingToRember);
            return hash;
        }

        public bool DidRemember(string thingToRemember)
        {
            if (HasBeenRemembered(thingToRemember)) return true;
            return false;
        }

        private bool HasBeenRemembered(string thingToRemember)
        {
            var hash = HashString(thingToRemember);

            var probablyExists = true;

            for (var i = 0; i < hash.Length; i++) if (_bitArray.Get(i) == false) probablyExists = false;

            return probablyExists;
        }
    }
}