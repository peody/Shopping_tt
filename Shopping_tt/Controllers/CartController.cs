using Microsoft.AspNetCore.Mvc;

namespace Shopping_tt.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index() { return View(); }
	}
}
