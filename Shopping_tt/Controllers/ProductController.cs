using Microsoft.AspNetCore.Mvc;

namespace Shopping_tt.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index() { return View(); }
		public IActionResult Details()
		{
			return View();
		}
	}
}
