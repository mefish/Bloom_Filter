using BloomFilterApp;
using NUnit.Framework;

namespace BloomFilterTests
{
    [TestFixture]
    internal class BloomFilterAcceptanceTests
    {
        private BloomFilter _bloomFilter;

        [SetUp]
        public void SetUp()
        {
            _bloomFilter = new BloomFilter();
        }

        [Test]
        [Ignore("In progress, needs to be moved to acceptance tests")]
        public void CanRememberThousandsOfThings()
        {
            var stringsToRemember = BloomFilterTestHelpers.GetListOfRandomStringsOfSize(100000);

            _bloomFilter.RememberStringList(stringsToRemember);

            _bloomFilter.VerifyStringList(stringsToRemember);
        }
    }
}