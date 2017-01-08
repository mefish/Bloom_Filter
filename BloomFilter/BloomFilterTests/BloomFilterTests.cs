using System.Collections.Generic;
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

        [Test]
        public void CanRememberManyThings()
        {
            var bloomFilter = new BloomFilter();
            var stringsToRemember = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                stringsToRemember.Add(BloomFilterTestHelpers.GetRandomString());
            }

            foreach (var testString in stringsToRemember)
            {
                bloomFilter.Remember(testString);
            }

            foreach (var testString in stringsToRemember)
            {
                Assert.IsTrue(bloomFilter.DidRemember(testString));
            }
        }
    }
}