﻿using System.Collections.Generic;

namespace FizzBuzz.Service.Interface
{
    public interface IFizzBuzzService
    {
        IList<string> GetFizzBuzzData(int inputNumber);
    }
}
