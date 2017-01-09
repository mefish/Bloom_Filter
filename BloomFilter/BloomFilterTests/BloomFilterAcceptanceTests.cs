using System;
using System.Diagnostics;
using BloomFilterApp;
using NUnit.Framework;

namespace BloomFilterTests
{
    [TestFixture]
    internal class BloomFilterAcceptanceTests
    {
        private const int FALSE_POSITIVE_TOLERANCE = 10;
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
        public void FalsePositivesAreInAcceptableBoundries()
        {
            var allStringstoTest = BloomFilterTestHelpers.GetListOfRandomStringsOfSize(100000, 50);

            for (int i = 0; i < allStringstoTest.Count; i++)
            {
                if (i % 2 == 0)
                {
                    _bloomFilter.Add(allStringstoTest[i]);
                }
            }

            int falsePositives = 0;
            for (int i = 0; i < allStringstoTest.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.IsTrue(_bloomFilter.WasAdded(allStringstoTest[i]));

                }
                else
                {
                    if (_bloomFilter.WasAdded(allStringstoTest[i])) falsePositives++;
                    
                }
            }

            Console.WriteLine(falsePositives);
            Assert.Less(falsePositives, FALSE_POSITIVE_TOLERANCE);
        }
    }
}