using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_30_MVC_Core.Models;

namespace Lab_30_MVC_Core.Controllers
{
    public class HomeController : Controller
    {
        public static List<string> myList = new List<string>();
        public List<string> myOtherList = new List<string>();
        public IActionResult Index()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult MyAction()
        {
            ViewBag.MyItem = "This is some data";
            ViewData["AnotherItem"] = "And some more data";
            ViewBag.List1 = "First item in list";
            ViewBag.List2 = "Second item in list";
            ViewBag.List3 = "Third item in list";
            HomeController.myList.Add(ViewBag.List1);
            HomeController.myList.Add(ViewBag.List2);
            HomeController.myList.Add(ViewBag.List3);
            myOtherList.Add(ViewBag.List1);
            myOtherList.Add(ViewBag.List2);
            myOtherList.Add(ViewBag.List3);
            return View();
        }
    }
}
