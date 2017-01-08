using System.Collections.Generic;
using System.Linq;

namespace BloomFilterApp
{
    public class BloomFilter
    {
        private readonly List<string> _thingsToRemember = new List<string>();

        public void Remember(string thingToRember)
        {
            _thingsToRemember.Add(thingToRember);
        }

        public bool DidRemember(string thingToRemember)
        {
            if (_thingsToRemember.Any(x => x == thingToRemember)) return true;
            return false;
        }
    }
}