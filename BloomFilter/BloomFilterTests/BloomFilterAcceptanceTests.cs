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

        [Test]
        [Ignore("This is a big problem, working on a fix")]
        public void WhenRememberingThousandsOfThingsThereIsNeverAFalseNegative()
        {
            var allStringstoTest = BloomFilterTestHelpers.GetListOfRandomStringsOfSize(10000, 50);

            for (int i = 0; i < allStringstoTest.Count; i++)
            {
                if (i % 2 == 0)
                {
                    _bloomFilter.Add(allStringstoTest[i]);
                }
            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int numberFailed = 0;
            for (int i = 0; i < allStringstoTest.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.IsTrue(_bloomFilter.DidRemember(allStringstoTest[i]));

                }
                else
                {
                    if (_bloomFilter.DidRemember(allStringstoTest[i])) numberFailed++;
                }
            }

            stopWatch.Stop();
            Console.WriteLine(numberFailed);
            Assert.Less(numberFailed, 10);
        }
    }
}