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
            var stringChars = new char[8];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++) stringChars[i] = CHARS[random.Next(CHARS.Length)];

            return new String(stringChars);
        }

        public static void VerifyStringList(this BloomFilter bloomFilter, IEnumerable<string> stringsToRemember)
        {
            foreach (var testString in stringsToRemember) Assert.IsTrue(bloomFilter.DidRemember(testString));
        }

        public static void RememberStringList(this BloomFilter bloomFilter, IEnumerable<string> stringsToRemember)
        {
            foreach (var testString in stringsToRemember) bloomFilter.Remember(testString);
        }

        public static List<string> GetListOfRandomStringsOfSize(int stringsToTest)
        {
            var stringsToRemember = new List<string>();
            for (var i = 0; i < stringsToTest; i++) stringsToRemember.Add(BloomFilterTestHelpers.GetRandomString());
            return stringsToRemember;
        }
    }
}