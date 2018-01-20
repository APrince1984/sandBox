using System.Collections.Generic;
using NUnit.Framework;

namespace Utilities.Tests
{
    [TestFixture]
    public class IntegerExtensionsTests
    {
        private int _integer;
        


        [Repeat(1000)]
        [Test]
        public void GetMinimumIntValueAlwaysReturns0()
        {
            _integer = RandomUtil.GetRandomNumber(2);
            Assert.AreEqual(0, _integer.GetMinimumIntValue());
        }

        [Test]
        public void GetMaximumIntValue_ReturnsCorrectMaximumValue()
        {
            var expectedValuesByIntegerValue = CreateExpectedValuesDictionary();

            foreach (var value in expectedValuesByIntegerValue)
            {
                _integer = value.Key;
                Assert.AreEqual(value.Value, _integer.GetMaximumIntValue());
            }
        }

        private Dictionary<int, int> CreateExpectedValuesDictionary()
        {
            var expectedValuesByIntegerValue = new Dictionary<int, int>();
            expectedValuesByIntegerValue.Add(1, 9);
            expectedValuesByIntegerValue.Add(2, 99);
            expectedValuesByIntegerValue.Add(3, 999);
            expectedValuesByIntegerValue.Add(4, 9999);
            expectedValuesByIntegerValue.Add(5, 99999);
            expectedValuesByIntegerValue.Add(6, 999999);
            return expectedValuesByIntegerValue;
        }
    }
}

