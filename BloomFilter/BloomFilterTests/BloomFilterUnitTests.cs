using BloomFilterApp;
using NUnit.Framework;

namespace BloomFilterTests
{
    [TestFixture]
    public class BloomFilterUnitTests
    {
        private const string THING_TO_REMEMBER = "Cat";
        private readonly BloomFilter _bloomFilter;

        public BloomFilterUnitTests()
        {
            _bloomFilter = new BloomFilter();
        }

        [Test]
        public void ItemNotRemembered_WillReturnFalse()
        {
            Assert.IsFalse(_bloomFilter.DidRemember(THING_TO_REMEMBER));
        }

        [Test]
        public void ItemRemembered_WillReturnTrue()
        {
            _bloomFilter.Remember(THING_TO_REMEMBER);
            Assert.IsTrue(_bloomFilter.DidRemember(THING_TO_REMEMBER));
        }

        [Test]
//        [Ignore("Temporarily broken, fixing now")]
        public void CanRememberManyThings()
        {
            var stringsToRemember = BloomFilterTestHelpers.GetListOfRandomStringsOfSize(10);

            _bloomFilter.RememberStringList(stringsToRemember);

            _bloomFilter.VerifyStringList(stringsToRemember);
        }
    }
}