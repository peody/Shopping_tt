using Microsoft.AspNetCore.Mvc;

namespace Shopping_tt.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
