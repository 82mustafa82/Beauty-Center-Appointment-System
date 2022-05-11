using Beauty.Models;
using Microsoft.AspNetCore.Mvc;

namespace Beauty.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            CountView m = new CountView();
            return View(m);
        }
    }
}
