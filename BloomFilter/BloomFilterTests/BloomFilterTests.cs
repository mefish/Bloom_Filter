using NUnit.Framework;
using BloomFilterApp;

namespace BloomFilterTests
{
    [TestFixture]
    public class BloomFilterTests
    {
        [Test]
        public void ItemNotRemembered_WillReturnFalse()
        {
            var bloomFilter = new BloomFilter();
            Assert.IsFalse(bloomFilter.DidRemember("Cat"));
        }

        [Test]
        public void ItemRemembered_WillReturnTrue()
        {
            var bloomFilter = new BloomFilter();
            bloomFilter.Remember("Cat");
            Assert.IsTrue(bloomFilter.DidRemember("Cat"));
        }
    }
}