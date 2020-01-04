﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.ML;

namespace WebApplication2.Controllers
{
    public class PredictionTaxiFareController : Controller
    {
        public IActionResult Index()
        {
            var result = new PredictionTaxiFare() { predicted = mainProgram.mainFunc(1,2)};
            return View(result);
        }
    }
}