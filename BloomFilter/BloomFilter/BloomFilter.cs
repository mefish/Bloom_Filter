using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BloomFilterApp
{
    public class BloomFilter
    {
//        private readonly List<string> _thingsToRemember = new List<string>();

        private BitArray _bitArray = new BitArray(128);

        public void Remember(string thingToRember)
        {
            var md5Haher = MD5.Create();

            var inputBytes = Encoding.ASCII.GetBytes(thingToRember);

            var hash = md5Haher.ComputeHash(inputBytes);

            var bitHash = new BitArray(hash);

            _bitArray = _bitArray.Or(bitHash);
        }

        public bool DidRemember(string thingToRemember)
        {
            if (HasBeenRemembered(thingToRemember)) return true;
            return false;
        }

        private bool HasBeenRemembered(string thingToRemember)
        {
//            return _thingsToRemember.Any(x => x == thingToRemember);
            var md5Hasher = MD5.Create();

            var inputBytes = Encoding.ASCII.GetBytes(thingToRemember);

            var hash = md5Hasher.ComputeHash(inputBytes);

            var bitHash = new BitArray(hash);

            var probablyExists = true;

            for (int i = 0; i < _bitArray.Length; i++)
            {
                if (_bitArray.Get(i))
                {
                    if (!bitHash.Get(i)) probablyExists = false;
                }
            }

            return probablyExists;
        }
    }
}