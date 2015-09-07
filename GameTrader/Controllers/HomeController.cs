using GameTrader.DAL;
using GameTrader.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GameTrader.Controllers
{
    [TrackVisitor]
    public class HomeController : GameTraderBaseController
    {
        public ActionResult Index() => View();

        public ActionResult Resolution(int height, int width)
        {
            BrowserResolution record = new BrowserResolution()
            {
                BrowserResolutionHeight = height.ToString(),
                BrowserResolutionWidth = width.ToString(),
                IPAddress = Request.UserHostAddress,
                Browser = Request.Browser.Browser
            };

            // save the record to the tracking table.
            VisitorStatisticsContext context = new VisitorStatisticsContext();
            context.BrowserResolutionRecord.Add(record);
            context.SaveChanges();
            
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult About()
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\Nour\Downloads\AboutPageText.txt"))
                {
                    ViewBag.Message = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                var logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Nour\Downloads\myapplog.txt", Serilog.Events.LogEventLevel.Error).CreateLogger();
                logger.Error(ex.Message, "This is possibly because file cannot be found.");
                ViewBag.Message = null;
            }
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