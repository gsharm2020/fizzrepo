using FizzBuzz.Common;
using FizzBuzz.Models;
using FizzBuzz.Service.Interface;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FizzBuzz.Controllers
{
    public class FizzBuzzController : Controller
    {
        private readonly IFizzBuzzService fizzBuzzService;

        /// <summary>
        /// Maximum number of elements displayed in page
        /// </summary>
        private int pageSize = Constants.PageSizeTwenty;

        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            this.fizzBuzzService = fizzBuzzService;
        }

        [HttpGet]
        public ActionResult Display()
        {
            return this.View(Constants.ControllerActionName, new FizzBuzzModel());
        }

        [HttpPost]
        public ActionResult Display(FizzBuzzModel model, int page = 1)
        {
            if (ModelState.IsValid)
            {
                model.FizzBuzzValue = this.PagedList(model.Number.Value, page);
            }
            return this.View(Constants.ControllerActionName, model);
        }

        [HttpGet]
        public ActionResult LoadBasedOnPageIndex(int number, int page)
        {
            var model = new FizzBuzzModel
            {
                Number = number,
                FizzBuzzValue = this.PagedList(number, page)
            };
            return this.View(Constants.ControllerActionName, model);
        }

        private IPagedList<string> PagedList(int number, int pageNumber)
        {
            var resultList = this.fizzBuzzService.GetFizzBuzzData(number).ToPagedList(pageNumber, pageSize);
            return resultList;
        }
    }
}
