using GameTrader.DAL;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace GameTrader.Controllers
{
    [TrackVisitor]
    [Authorize(Roles = "Admin, AwesomePerson")]
    public class AdminController : GameTraderBaseController
    {
        public ActionResult Admin() => View();

        public ActionResult Index() => View();


        [HttpPost]
        public ActionResult Upload()
        {
            string directory = @"C:\Users\Nour\Downloads\";

            HttpPostedFileBase photo = Request.Files["photo"];

            if (photo != null && photo.ContentLength > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);
                photo.SaveAs(Path.Combine(directory, fileName));
            }

            return RedirectToAction("Index");
        }
    }
}