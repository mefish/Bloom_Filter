using System;

namespace BloomFilterTests
{
    internal class BloomFilterTestHelpers
    {
        private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string GetRandomString()
        {
            var stringChars = new char[8];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++) stringChars[i] = CHARS[random.Next(CHARS.Length)];

            return new String(stringChars);
        }
    }
}