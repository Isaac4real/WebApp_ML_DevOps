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
            return PartialView("_partialAjaxForm", model);
            //return Content(("< b > Amount : a Jet!</ b >").ToString());
        }

        [HttpPost]
        public IActionResult OnGetPartial()
        {
            Thread.Sleep(2000);
            return new PartialViewResult
            {
                ViewName = "_partialAjaxForm"
                //ViewData = this.ViewData
            };
        }

        /*
        // GET: Movies/Random
        public IActionResult Random()
        {
            var movie = new Movies() { Name = "Shrek!" };
            return View(movie);
        }

        public void AJAXPostContactForm(string name, string email, string message)
        {
            
        }*/
    }

}