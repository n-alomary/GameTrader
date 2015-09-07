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
        public ActionResult UploadEditFilepage()
        {
            return View("UploadEditFile");
        }

        [HttpPost]
        public ActionResult UploadEditFile()
        {
            HttpPostedFileBase uploadedTextFile = Request.Files["textFile"];

            if (uploadedTextFile != null && uploadedTextFile.ContentLength > 0)
            {
                // var fileName = Path.GetFileName(photo.FileName);
                uploadedTextFile.SaveAs(Path.Combine(directory, "EditedFile.txt"));
            }
            using (StreamReader reader = new StreamReader(Path.Combine(directory, "EditedFile.txt")))
            {
                ViewBag.Message = reader.ReadToEnd();
            }
            return RedirectToAction("EditFile", ViewBag);
        }

        public ActionResult EditFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditFile(string file)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(directory, "AboutPageText.txt")))
                {
                    writer.Write(ViewBag.Message);
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