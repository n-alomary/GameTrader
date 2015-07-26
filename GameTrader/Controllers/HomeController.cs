using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameTrader.Controllers
{
    public class HomeController : GameTraderBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to the Game Trader site where you can buy, sell and swap your favorite games!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How to find us.";

            return View();
        }
    }
}