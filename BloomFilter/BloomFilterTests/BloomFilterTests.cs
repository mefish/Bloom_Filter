using NUnit.Framework;

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