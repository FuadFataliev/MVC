using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        ICompany company;
        public HomeController(ICompany company) => this.company = company;
        public IActionResult Index(DateTime date)
        {
            if (date == DateTime.MinValue)
                date = DateTime.Now.Date;

            ViewBag.Date = date;

            var stuff = company.Stuff.Where(e => e.HireDate <= date).OrderBy(e => e.OrderID).ThenBy(e => e.Name);
            return View(stuff);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
