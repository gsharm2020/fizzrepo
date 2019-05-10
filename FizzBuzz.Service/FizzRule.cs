using FizzBuzz.Common;
using FizzBuzz.Service.Interface;

namespace FizzBuzz.Service
{
    public class FizzRule : IRule
    {
        private readonly ICheckDay checkDay;

        public FizzRule(ICheckDay checkDay)
        {
            this.checkDay = checkDay;
        }

        public bool IsDivisible(int number)
        {
            return number % 3 == 0;
        }

        public string GetValue()
        {
            return this.checkDay.IsDayMatching() ? Constants.Wizz : Constants.Fizz;
        }
    }
}
