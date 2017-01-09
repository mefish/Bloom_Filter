using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloomFilterApp
{
    public class Hasher
    {
        //Shamelessly ripped from https://gist.github.com/richardkundl/8300092
        public int Hash(string toHash)
        {
            var hash = 0;

            foreach (var character in toHash) {
                hash += character;
                hash += (hash << 10);
                hash ^= (hash >> 6);
            }

            hash += (hash << 3);
            hash ^= (hash >> 11);
            hash += (hash << 15);

            return hash;
        }
    }
}
