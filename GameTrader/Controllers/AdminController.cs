using System.Web.Mvc;

namespace GameTrader.Controllers
{
    [Authorize(Roles ="Admin, AwesomePerson")]
    public class AdminController : GameTraderBaseController
    {
        public ActionResult Admin()
        {
            return View();
        }
    }
}