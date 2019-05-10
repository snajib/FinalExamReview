//@author Sammy Najib
using MVC_Schedule_Review.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Schedule_Review.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About the University of Oklahoma Football program";
            About a = new About();


            return View(a);
        }


    }
}