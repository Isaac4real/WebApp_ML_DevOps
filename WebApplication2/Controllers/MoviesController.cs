using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using CalculateSimpleInterest.Models;
using System.Text;
using System.Threading;

namespace WebApplication2.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Random()
        {
            Movies model = new Movies();
            model.Amount = 0;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Random(Movies model)
        {
            /*
            decimal simpleInteresrt = (model.Amount * model.Year * model.Rate) / 100;
            StringBuilder sbInterest = new StringBuilder();
            sbInterest.Append("<b>Amount :</b> " + model.Amount + "<br/>");
            sbInterest.Append("<b>Rate :</b> " + model.Rate + "<br/>");
            sbInterest.Append("<b>Time(year) :</b> " + model.Year + "<br/>");
            sbInterest.Append("<b>Interest :</b> " + simpleInteresrt);*/
            model.Amount = 200;
            return View(model);
            //return Content(("< b > Amount : a Jet!</ b >").ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateViewData(Movies model)
        {
            return PartialView("PartialMovie.cshtml", model);
        }
    }

}