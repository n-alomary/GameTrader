using GameTrader.DAL;
using GameTrader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameTrader.Controllers
{
    [TrackVisitor]
    public class HomeController : GameTraderBaseController
    {
        // testing upload works
        //[HttpPost]
        //public ActionResult Upload()
        //{
        //    string directory = @"C:\Users\Nour\Downloads\";

        //    HttpPostedFileBase photo = Request.Files["photo"];

        //    if (photo !=null && photo.ContentLength> 0)
        //    {
        //        var fileName = Path.GetFileName(photo.FileName);
        //        photo.SaveAs(Path.Combine(directory, fileName));
        //    }

        //    return RedirectToAction("Index");
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewVisitorStats()
        {
            var stats = new VisitorStatisticsContext().VisitorStatisticRecords;
            return View(stats);
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

        public ActionResult SellSwap() => View("SellSwap");

        public ActionResult BuySwap() => View("BuySwap");
    }
}