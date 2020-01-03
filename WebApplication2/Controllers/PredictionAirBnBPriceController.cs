using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

using WebApplication2ML.Model;

namespace WebApplication.Controllers
{
    public class PredictionAirBnBPriceController : Controller
    {
        public IActionResult Index()
        {
            ModelInput model = new ModelInput();
            return View(model);
        }

        //[HttpPost]
        //public ActionResult PredictPrice(ModelInput model)
        //{
            //var result = new PredictionAirBnBPrice() { predicted = AirBnBProgram2.AirBnBFunction2(1, 2) };
        //    model
        //    return View(result);
        //}
    }

}