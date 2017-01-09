using System;
using System.Diagnostics;
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
        public void CanRememberThousandsOfThings()
        {
            var stringsToTest = BloomFilterTestHelpers.GetListOfRandomStringsOfSize(100000);

            _bloomFilter.AddStringListToFilter(stringsToTest);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            _bloomFilter.VerifyStringList(stringsToTest);
            stopWatch.Stop();
            Assert.Less(stopWatch.Elapsed, TimeSpan.FromSeconds(1));
        }
    }
}