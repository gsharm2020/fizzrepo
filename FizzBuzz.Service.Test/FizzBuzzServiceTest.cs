﻿using FizzBuzz.Common;
using FizzBuzz.Service.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FizzBuzz.Service.Test
{
    [TestFixture]
    public class FizzBuzzServiceTest
    {
        private IList<IRule> rules;
        private Mock<IRule> ruleMock;
        private FizzBuzzService fizzBuzzBervice;
        private Mock<IRule> fizzRule;
        private Mock<IRule> buzzRule;

        [SetUp]
        public void Setup()
        {
            fizzRule = new Mock<IRule>();
            buzzRule = new Mock<IRule>();

            rules = new List<IRule>()
            {
                fizzRule.Object,
                buzzRule.Object
            };

            fizzBuzzBervice = new FizzBuzzService(rules);
        }

        [TestCase(0, (object)new string[] { })]
        [TestCase(1, (object)new string[] { "1" })]
        [TestCase(2, (object)new string[] { "1", "2" })]
        public void GetFizzBuzzDataTest(int inputValue, string[] expectedResult)
        {
            this.ruleMock = new Mock<IRule>();

            this.ruleMock.Setup(x => x.IsDivisible(inputValue)).Returns(false);

            this.ruleMock.Setup(y => y.GetValue()).Returns(string.Empty);

            var businesrule = new[] 
            {
                this.ruleMock.Object,
                this.ruleMock.Object

            };
            var results = new FizzBuzzService(businesrule);

            var actual = results.GetFizzBuzzData(inputValue);

            Assert.AreEqual(actual, expectedResult);
        }

        [TestCase(3, Constants.Fizz)]
        public void GetFizzBuzzData_ShouldReturnFizz_WhenInputNumberIs3(int inputValue, string expectedResult)
        {
            this.ruleMock = new Mock<IRule>();

            this.ruleMock.Setup(x => x.IsDivisible(inputValue)).Returns(true);

            this.ruleMock.Setup(y => y.GetValue()).Returns(Constants.Fizz);

            var businesrule = new[] 
            {
                this.ruleMock.Object
            };
            var results = new FizzBuzzService(businesrule);

            var actual = results.GetFizzBuzzData(inputValue);

            Assert.AreEqual(actual[2], expectedResult);
        }


        [TestCase(5, Constants.Buzz)]
        public void GetFizzBuzzData_ShouldReturnBuzz_WhenInputNumberIs5(int inputValue, string expectedResult)
        {
            this.ruleMock = new Mock<IRule>();

            this.ruleMock.Setup(x => x.IsDivisible(inputValue)).Returns(true);

            this.ruleMock.Setup(y => y.GetValue()).Returns(Constants.Buzz);

            var businesrule = new[] 
            {
                this.ruleMock.Object
            };
            var results = new FizzBuzzService(businesrule);

            var actual = results.GetFizzBuzzData(inputValue);

            Assert.AreEqual(actual[4], expectedResult);
        }
    }
}
