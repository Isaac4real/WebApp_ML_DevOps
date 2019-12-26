using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.ML;

namespace WebApplication2.Controllers
{
    public class PredictionController : Controller
    {
        public IActionResult Index()
        {
            var result = new Prediction() { predicted = MLtest.MLfunction(1,2)};
            return View(result);
        }
    }
}