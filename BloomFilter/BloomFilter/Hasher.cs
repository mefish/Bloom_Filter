using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloomFilterApp
{
    public class Hasher
    {
        //Shamelessly ripped from https://gist.github.com/richardkundl/8300092
        public int Hash(string cat)
        {
            int hash = 0;

            for (int i = 0; i < cat.Length; i++)
            {
                hash += cat[i];
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
