using System;
using System.Collections.Generic;
using BloomFilterApp;
using NUnit.Framework;

namespace BloomFilterTests
{
    internal static class BloomFilterTestHelpers
    {
        private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        
        public static string GetRandomString(int size = 8)
        {
            var stringChars = new char[size];
            var random = CreateRandomWithRandomSeed();

            for (var i = 0; i < stringChars.Length; i++)
            {
                var nextChar = random.Next(CHARS.Length);
                stringChars[i] = CHARS[nextChar];
            }

            return new String(stringChars);
        }

        private static Random CreateRandomWithRandomSeed()
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            return random;
        }

        public static void VerifyStringList(this BloomFilter bloomFilter, IEnumerable<string> stringsToRemember)
        {
            foreach (var testString in stringsToRemember) Assert.IsTrue(bloomFilter.WasAdded(testString));
        }

        public static void AddStringListToFilter(this BloomFilter bloomFilter, IEnumerable<string> stringsToRemember)
        {
            foreach (var testString in stringsToRemember) bloomFilter.Add(testString);
        }

        public static List<string> GetListOfRandomStringsOfSize(int stringsToTest, int stringSize = 8)
        {
            var stringsToRemember = new List<string>();
            for (var i = 0; i < stringsToTest; i++) stringsToRemember.Add(GetRandomString(stringSize));
            return stringsToRemember;
        }
    }
}