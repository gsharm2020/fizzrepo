using FizzBuzz.Common;
using FizzBuzz.Service.Interface;

namespace FizzBuzz.Service
{
    public class BuzzRule : IRule
    {
        private readonly ICheckDay checkDay;

        public BuzzRule(ICheckDay checkDay)
        {
            this.checkDay = checkDay;
        }

        public bool IsDivisible(int number)
        {
            return number % 5 == 0;
        }

        public string GetValue()
        {
            return this.checkDay.IsDayMatching() ? Constants.Wuzz : Constants.Buzz;
        }
    }
}
