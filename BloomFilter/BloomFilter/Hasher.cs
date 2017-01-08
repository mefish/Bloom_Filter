using System.Collections;

namespace BloomFilterApp
{
    public class Hasher
    {
        //Shamelessly ripped from https://gist.github.com/richardkundl/8300092
        public BitArray Hash(string toHash)
        {
            var hash = 0;

            foreach (var character in toHash)
            {
                hash += character;
                hash += (hash << 10);
                hash ^= (hash >> 6);
            }

            hash += (hash << 3);
            hash ^= (hash >> 11);
            hash += (hash << 15);

            var hashArray = new BitArray(new[]
                                         {
                                                 hash
                                         });

            var bitArray = new BitArray(128);

            for (var i = 0; i < hashArray.Length; i++) bitArray.Set(i, hashArray.Get(i));

            return bitArray;
        }
    }
}