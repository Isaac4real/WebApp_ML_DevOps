﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2ML.Model;
using WebApplication2.ML;

namespace WebApplication.Controllers
{
    public class PredictionAirBnBPriceController : Controller
    {
        public ActionResult ViewAirBnB()
        {
            ModelInput model = new ModelInput();
            model.Availability_365 = 0;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewAirBnB(ModelInput model)
        {
            model.Availability_365 = 200;
            model.Prediction= AirBnBProgram2.AirBnBFunction2(1, 2);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateViewData(ModelInput model)
        {
            return PartialView("PartialViewAirBnB.cshtml", model);
        }
    }

}