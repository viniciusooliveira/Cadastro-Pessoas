using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PersonController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}