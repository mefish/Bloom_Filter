using BloomFilterApp;
using NUnit.Framework;

namespace BloomFilterTests
{
    [TestFixture]
    internal class HasherUnitTests
    {
        private const string TO_HASH = "Cat";
        private const int RANDOM_STRING_SIZE = 3;

        [Test]
        public void AStringCanBeHashed()
        {
            var hasher = new Hasher();

            var hash = hasher.Hash(TO_HASH);

            Assert.IsTrue(hash != 0);
        }

        [Test]
        public void AStringIsHashedTheSameEveryTime()
        {
            var hasher = new Hasher();

            var hash = hasher.Hash(TO_HASH);
            var secondHash = hasher.Hash(TO_HASH);

            Assert.AreEqual(hash, secondHash);
        }

        [Test]
        public void DifferentStringsCreateDifferentHashes()
        {
            var hasher = new Hasher();

            var hash = hasher.Hash(TO_HASH);
            var secondHash = hasher.Hash("Dog");

            Assert.AreNotEqual(hash, secondHash);
        }

        [Test]
        public void NoTwoHashesAreTheSame_InAThousand()
        {
            const int stringsToCreate = 1000;
            var hasher = new Hasher();

            var hash = hasher.Hash(TO_HASH);
            
            for (var i = 0; i < stringsToCreate; i++)
            {
                var randomString = BloomFilterTestHelpers.GetRandomString(RANDOM_STRING_SIZE);
                var randomStringHash = hasher.Hash(randomString);
                if (randomString != TO_HASH) Assert.AreNotEqual(randomStringHash, hash);
            }
        }
    }
}