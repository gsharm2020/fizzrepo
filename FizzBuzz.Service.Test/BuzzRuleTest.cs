using FizzBuzz.Common;
using FizzBuzz.Service.Interface;
using Moq;
using NUnit.Framework;
using System;

namespace FizzBuzz.Service.Test
{
    [TestFixture]
    public class BuzzRuleTest
    {
        private BuzzRule buzzRule;
        private Mock<ICheckDay> checkDayMock;

        [SetUp]
        public void SetUp()
        {
            checkDayMock = new Mock<ICheckDay>();
            buzzRule = new BuzzRule(checkDayMock.Object);
        }

        [TestCase(5, true)]
        [TestCase(3, false)]
        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(4, false)]
        [TestCase(15, true)]
        public void IsDivisible_ShouldReturnTrue_WhenNumberMultipleOf5(int number, bool result)
        {
            Assert.AreEqual(result, buzzRule.IsDivisible(number));
        }

        [TestCase(false, Constants.Buzz)]
        [TestCase(true, Constants.Wuzz)]
        public void Displayvalue_ShouldReturnBuzz_WhenNotWednesday(bool input, string output)
        {
            checkDayMock.Setup(x => x.IsDayMatching()).Returns(input);
            var result = buzzRule.GetValue();
            Assert.AreEqual(output, result);
        }
    }
}
