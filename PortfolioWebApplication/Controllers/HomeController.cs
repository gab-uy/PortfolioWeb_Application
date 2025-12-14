using System.Web.Mvc;

namespace PortfolioWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            ViewBag.Title = "Home";
            return View("~/Views/PortfolioWebApplication/Home.cshtml");
        }

        public ActionResult Projects()
        {
            ViewBag.Title = "Projects";
            return View("~/Views/PortfolioWebApplication/Projects.cshtml");
        }

        public ActionResult Resume()
        {
            ViewBag.Title = "Resume";
            return View("~/Views/PortfolioWebApplication/Resume.cshtml");
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";
            return View("~/Views/PortfolioWebApplication/About.cshtml");
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            return View("~/Views/PortfolioWebApplication/Contact.cshtml");
        }
    }
}