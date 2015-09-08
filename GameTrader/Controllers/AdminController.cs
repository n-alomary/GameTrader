using GameTrader.DAL;
using GameTrader.Models;
using Serilog;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace GameTrader.Controllers
{
    [TrackVisitor]
    [Authorize(Roles = "Admin, AwesomePerson")]
    public class AdminController : GameTraderBaseController
    {
        string directory = @"C:\Users\Nour\Downloads\";

        public ActionResult Admin() => View();

        public ActionResult Index() => View();

        [HttpGet]
        public ActionResult Upload() => View("Upload");

        [HttpPost]
        public ActionResult UploadFile()
        {

            HttpPostedFileBase uploadedTextFile = Request.Files["textFile"];

            if (uploadedTextFile != null && uploadedTextFile.ContentLength > 0)
            {
                uploadedTextFile.SaveAs(Path.Combine(directory, "AboutPageText.txt"));
            }

            return RedirectToAction("Index");
        }

        public ActionResult ViewVisitorStats()
        {
            var stats = new VisitorStatisticsContext().VisitorStatisticRecords;
            return View(stats);
        }

        public ActionResult ViewBrowserStats()
        {
            var stats = new VisitorStatisticsContext().BrowserResolutionRecord;
            return View(stats);
        }

        [HttpGet]
        public ActionResult EditFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Path.Combine(directory, "AboutPageText.txt")))
                {
                     ViewData["FileTextToEdit"] = reader.ReadToEnd();
                }
            }
            catch (System.Exception ex) 
            {
                var logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Nour\Downloads\myapplog.txt", Serilog.Events.LogEventLevel.Error).CreateLogger();
                logger.Error(ex.Message, "cannot read file");
            }
            return View("EditFile",ViewBag);
        }

        [HttpPost]
        public ActionResult EditFile(string editedText)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(directory, "AboutPageText.txt")))
                {
                    writer.Write(editedText);
                }
            }
            catch (System.Exception ex)
            {
                var logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Nour\Downloads\myapplog.txt", Serilog.Events.LogEventLevel.Error).CreateLogger();
                logger.Error(ex.Message, "cannot write file");
            }
            return View("Index");
        }
    }
}