﻿using BloomFilterApp;
using NUnit.Framework;

namespace BloomFilterTests
{
    [TestFixture]
    public class BloomFilterUnitTests
    {
        private const string THING_TO_REMEMBER = "Cat";
        private BloomFilter _bloomFilter;

        [SetUp]
        public void SetUp()
        {
            _bloomFilter = new BloomFilter();
        }

        [Test]
        public void ItemNotAdded_WillReturnFalse()
        {
            Assert.IsFalse(_bloomFilter.WasAdded(THING_TO_REMEMBER));
        }

        [Test]
        public void ItemAdded_WillReturnTrue()
        {
            _bloomFilter.Add(THING_TO_REMEMBER);
            Assert.IsTrue(_bloomFilter.WasAdded(THING_TO_REMEMBER));
        }

        [Test]
        public void CanAddAndTestForManyStrings()
        {
            var stringsToRemember = BloomFilterTestHelpers.GetListOfRandomStringsOfSize(10);

            _bloomFilter.AddStringListToFilter(stringsToRemember);

            _bloomFilter.VerifyStringList(stringsToRemember);
        }
    }
}