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
            var stringsToRemember = BloomFilterTestHelpers.GetListOfRandomStringsOfSize(10000);

            _bloomFilter.RememberStringList(stringsToRemember);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            _bloomFilter.VerifyStringList(stringsToRemember);
            stopWatch.Stop();
            Assert.Less(stopWatch.Elapsed, TimeSpan.FromSeconds(1));
        }
    }
}