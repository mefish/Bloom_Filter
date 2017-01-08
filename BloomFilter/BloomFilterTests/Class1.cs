using NUnit.Framework;
using BloomFilter;

namespace BloomFilterTests
{
    [TestFixture]
    public class BloomFilterTests
    {
        [Test]
        public void ItemNotRemembered_WillReturnFalse()
        {
            var bloomFilter = new BloomFilter.BloomFilter();
            Assert.IsFalse(bloomFilter.DidRemember("Cat"));
        }
    }
}