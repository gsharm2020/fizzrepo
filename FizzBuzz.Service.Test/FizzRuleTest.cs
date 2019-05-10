using System;
using NUnit.Framework;
using FizzBuzz.Service.Interface;
using Moq;
using FizzBuzz.Common;

namespace FizzBuzz.Service.Test
{
    [TestFixture]
    public class FizzRuleTests
    {
        private FizzRule fizzRule;
        private Mock<ICheckDay> checkDayMock;

        [SetUp]
        public void SetUp()
        {
            checkDayMock = new Mock<ICheckDay>();
            fizzRule = new FizzRule(checkDayMock.Object);
        }

        [TestCase(5, false)]
        [TestCase(3, true)]
        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(4, false)]
        [TestCase(15, true)]
        public void IsDivisible_ShouldReturnTrue_WhenNumberMultipleOf3(int number, bool result)
        {
            Assert.AreEqual(result, fizzRule.IsDivisible(number));
        }

        [TestCase(false, Constants.Fizz)]
        [TestCase(true, Constants.Wizz)]
        public void DisplayValue_ShouldReturnFizz_WhenNotWednesday(bool input, string output)
        {
            checkDayMock.Setup(x => x.IsDayMatching()).Returns(input);
            var result = fizzRule.GetValue();
            Assert.AreEqual(output, result);
        }
    }
}
