﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab_35_MVC_Core_Entity_Northwind.Controllers
{
    public class SpecialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Special()
        {
            return View("SingleSpecial");
        }
    }
}