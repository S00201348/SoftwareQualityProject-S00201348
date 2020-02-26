using CarInsuranceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Calculate()
        {
            ViewBag.Message = "Calculate Insurance Page.";
            return View();
        }
        [HttpPost]
        public ActionResult Result(InsuranceCalculator ins)
        {
            ViewBag.Title = "This is the Paycheck ;)";
            ViewBag.Message = ins.CalculateInsurance().ToString();
            return View(ins);           
        }
    }
}