﻿using FizzBuzz.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FizzBuzz.Models
{
    public class FizzBuzzModel
    {
        [Required(ErrorMessage = Constants.RequiredErrorMessage)]
        [Range(1, Constants.MaxNumberThousand, ErrorMessage = Constants.EnterNumber1To1000)]
        [Display(Name = Constants.DisplayMessage)]
        public int? Number { get; set; }

        public IPagedList<string> FizzBuzzValue { get; set; }
    }
}