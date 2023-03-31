using Microsoft.AspNetCore.Mvc;

namespace Interview.Ui.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
