
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MicroMvc.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

    }
}
