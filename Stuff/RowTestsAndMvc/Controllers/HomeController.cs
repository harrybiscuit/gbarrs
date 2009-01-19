using System.Web.Mvc;
using RowTestsAndMvc.Models;

namespace RowTestsAndMvc.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            ViewData["Colour"] = Colour.red;

            return View();
        }

        public ActionResult About()
        {
            ViewData["Title"] = "About Page";
            ViewData["Colour"] = Colour.blue;

            return View();
        }
    }
}