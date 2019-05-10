using System;
using NUnit.Framework;

namespace FizzBuzz.Service.Test
{
    [TestFixture]
    public class CheckDayTest
    {
        [Test]
        public void IsDayMatchingTest_ShouldReturnFalse_WhenDayIsEmpty()
        {
            var businessday = new CheckDay("");
            var actualResult = businessday.IsDayMatching();
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsDayMatching_ShouldReturnTrue_WhenDayIsToday()
        {
            var businessday = new CheckDay(DateTime.Now.DayOfWeek.ToString());
            var actualResult = businessday.IsDayMatching();
            Assert.IsTrue(actualResult);
        }

        [Test]
        public void IsDayMatching_ShouldReturnFalse_WhenDayIsTomorrow()
        {
            var businessday = new CheckDay(DateTime.Now.AddDays(1).DayOfWeek.ToString());
            var actualResult = businessday.IsDayMatching();
            Assert.IsFalse(actualResult);
        }
    }
}
