using FizzBuzz.Common;
using FizzBuzz.Controllers;
using FizzBuzz.Models;
using FizzBuzz.Service.Interface;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FizzBuzz.Tests.Controllers
{
    [TestFixture]
    public class FizzBuzzControllerTest
    {
        private Mock<IFizzBuzzService> mockFizzBuzzService;
        private FizzBuzzController fizzBuzzController;
        private IList<string> expectedList;

        [SetUp]
        public void Initialise()
        {
            this.mockFizzBuzzService = new Mock<IFizzBuzzService>();
            this.fizzBuzzController = new FizzBuzzController(this.mockFizzBuzzService.Object);
            this.expectedList = new List<string> { "1", "2", "fizz", "4", "buzz" };
        }

        [Test]
        public void Display_ShouldDisplayView_WithInputNumber5()
        {
            var model = new FizzBuzzModel()
            {
                Number = 5
            };

            this.mockFizzBuzzService.Setup(p => p.GetFizzBuzzData(It.IsAny<int>())).Returns(this.expectedList);

            var result = this.fizzBuzzController.Display(model) as ViewResult;

            Assert.AreEqual(result.ViewName, Constants.ControllerActionName);
            var resultModel = result.Model as FizzBuzzModel;
            Assert.AreEqual(5, this.expectedList.Count);
        }

        [Test]
        public void Display_ShouldDisplayView_WithInvalidModelState()
        {
            var model = new FizzBuzzModel() { };
            this.fizzBuzzController.ViewData.ModelState.AddModelError("Limit", Constants.EnterNumber1To1000);
            var result = fizzBuzzController.Display(model) as ViewResult;

            Assert.AreEqual(result.ViewName, Constants.ControllerActionName);
        }

        [TestCase(5, (object)new string[] { "1", "2", "fizz", "4", "buzz" })]
        [TestCase(15, (object)new string[] { "1", "2", "fizz", "4", "buzz", "fizz", "7", "8", "fizz", "buzz", "11", "fizz", "13", "14", "fizz buzz" })]
        public void Post_DisplayTest(int value, string[] expectedResult)
        {
            this.mockFizzBuzzService.Setup(x => x.GetFizzBuzzData(It.IsAny<int>())).Returns(expectedResult);
            var fizzBuzzController = new FizzBuzzController(this.mockFizzBuzzService.Object);
            var output = fizzBuzzController.Display(new FizzBuzzModel() { Number = value }) as ViewResult;
            var outputList = (FizzBuzzModel)output.ViewData.Model;

            Assert.AreEqual(expectedResult.Length, outputList.Number);
        }
    }
}
