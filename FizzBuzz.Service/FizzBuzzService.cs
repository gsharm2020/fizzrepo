﻿using FizzBuzz.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz.Service
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IEnumerable<IRule> fizzBuzzRules;

        public FizzBuzzService(IEnumerable<IRule> fizzBuzzRules)
        {
            this.fizzBuzzRules = fizzBuzzRules;
        }

        public IList<string> GetFizzBuzzData(int inputNumber)
        {
            var resultList = new List<string>();
            string fizzBuzzText = string.Empty;

            for (var counter = 1; counter <= inputNumber; counter++)
            {
                var matchedRules = this.fizzBuzzRules.Where(x => x.IsDivisible(counter)).ToList();
                fizzBuzzText = matchedRules.Any() ? string.Join(" ", matchedRules.Select(r => r.GetValue())) :
                counter.ToString();
                resultList.Add(fizzBuzzText);
            }
            return resultList;
        }
    }
}
