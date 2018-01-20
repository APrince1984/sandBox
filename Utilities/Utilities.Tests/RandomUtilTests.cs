using NUnit.Framework;

namespace Utilities.Tests
{
    [TestFixture]
    public class RandomUtilTests
    {
        [Repeat(10000)]
        [Test]
        public void GetRandomNumberTest_NoLengthGiven_ReturnsNumberBetween0And999999()
        {
            TestReturnedIntValue(6, RandomUtil.GetRandomNumber());
        }

        [Repeat(10000)]
        [Test]
        public void GetRandomNumberTest_LengthIsOne_ReturnsNumberBetween0And9()
        {
            TestReturnedIntValue(1, RandomUtil.GetRandomNumber(1));
        }

        [Repeat(10000)]
        [Test]
        public void GetRandomStringTest_NoLengthGiven_Returns10DigitString()
        {
            TestReturnedStringValue(RandomUtil.GetRandomString(), 10);
        }

        [Repeat(10000)]
        [Test]
        public void GetRandomStringTest_LengthIsGiven_ReturnsStringWithMatchingLenght()
        {
            var length = RandomUtil.GetRandomNumber(2);
            TestReturnedStringValue(RandomUtil.GetRandomString(length), length);
        }

        [Repeat(10000)]
        [Test]
        public void GetRandomAlphaNumericStringTest_NoLengthGiven_Returns10DigitString()
        {
            TestReturnedStringValue(RandomUtil.GetRandomAlphaNumericString(), 10);
        }

        [Repeat(10000)]
        [Test]
        public void GetRandomAlphaNumericStringTest_LengthIsGiven_ReturnsStringWithMatchingLenght()
        {
            var length = RandomUtil.GetRandomNumber(2);
            TestReturnedStringValue(RandomUtil.GetRandomAlphaNumericString(length), length);
        }

        private static void TestReturnedIntValue(int length, int randomInt)
        {
            Assert.IsNotNull(randomInt);
            Assert.IsInstanceOf<int>(randomInt);
            Assert.GreaterOrEqual(randomInt, length.GetMinimumIntValue());
            Assert.LessOrEqual(randomInt, length.GetMaximumIntValue());
        }

        private static void TestReturnedStringValue(string createdString, int length)
        {
            Assert.IsNotNull(createdString);
            Assert.IsInstanceOf<string>(createdString);
            Assert.AreEqual(length, createdString.Length);
        }
    }
}