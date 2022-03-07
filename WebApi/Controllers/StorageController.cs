using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class StorageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
