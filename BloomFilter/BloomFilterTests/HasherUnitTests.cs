using BloomFilterApp;
using NUnit.Framework;

namespace BloomFilterTests
{
    [TestFixture]
    internal class HasherUnitTests
    {
        [Test]
        public void AStringCanBeHashed()
        {
            var hasher = new Hasher();

            var hash = hasher.Hash("Cat");

            Assert.IsNotNull(hash);
            Assert.IsNotEmpty(hash);
        }

        [Test]
        public void AStringIsHashedTheSameEveryTime()
        {
            var hasher = new Hasher();

            var hash = hasher.Hash("Cat");
            var secondHash = hasher.Hash("Cat");

            Assert.AreEqual(hash, secondHash);
        }

        [Test]
        public void DifferentStringsCreateDifferentHashes()
        {
            var hasher = new Hasher();

            var hash = hasher.Hash("Cat");
            var secondHash = hasher.Hash("Dog");

            Assert.AreNotEqual(hash, secondHash);
        }

        [Test]
        public void NoTwoHashesAreTheSameWithinReason()
        {
            var hasher = new Hasher();

            var hash = hasher.Hash("Cat");
            for (var i = 0; i < 1000; i++)
            {
                var randomString = BloomFilterTestHelpers.GetRandomString(3);
                var randomStringHash = hasher.Hash(randomString);
                if (randomString != "Cat") Assert.AreNotEqual(randomStringHash, hash);
            }
        }
    }
}