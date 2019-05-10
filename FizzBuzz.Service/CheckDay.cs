using FizzBuzz.Service.Interface;
using System;

namespace FizzBuzz.Service
{
    public class CheckDay : ICheckDay
    {
        private readonly string day;

        public CheckDay(string dayOfWeek)
        {
            this.day = dayOfWeek;
        }

        public bool IsDayMatching()
        {
            return DateTime.Now.DayOfWeek.ToString() == this.day;
        }
    }
}

