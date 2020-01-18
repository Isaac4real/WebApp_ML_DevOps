using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2ML.Model;

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
        public ActionResult ViewAirBnB(ModelInput model)
        {
            model.Availability_365 = 200;
            model.Prediction= AirBnBProgram2.AirBnBFunction2(model);

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateViewData(ModelInput model)
        {
            return PartialView("PartialViewAirBnB.cshtml", model);
        }
    }

}