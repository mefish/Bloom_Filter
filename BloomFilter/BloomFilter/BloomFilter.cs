namespace BloomFilterApp
{
    public class BloomFilter
    {
        private string _thingToRemember;

        public void Remember(string thingToRember)
        {
            _thingToRemember = "Cat";
        }

        public bool DidRemember(string thingToRemember)
        {
            if (_thingToRemember == thingToRemember) return true;
            return false;
        }
    }
}