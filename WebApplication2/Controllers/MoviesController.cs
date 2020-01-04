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
            return View(model);
        }

        [HttpPost]
        public ActionResult CalculateSimpleInterestResult(Movies model)
        {
            /*
            decimal simpleInteresrt = (model.Amount * model.Year * model.Rate) / 100;
            StringBuilder sbInterest = new StringBuilder();
            sbInterest.Append("<b>Amount :</b> " + model.Amount + "<br/>");
            sbInterest.Append("<b>Rate :</b> " + model.Rate + "<br/>");
            sbInterest.Append("<b>Time(year) :</b> " + model.Year + "<br/>");
            sbInterest.Append("<b>Interest :</b> " + simpleInteresrt);*/

            return Content(("< b > Amount : a Jet!</ b >").ToString());
        }

        public IActionResult OnGetPartial()
        {
            Thread.Sleep(2000);
            return new PartialViewResult
            {
                ViewName = "_HelloWorldPartial",
                ViewData = this.ViewData
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