using Microsoft.AspNetCore.Mvc;
using Shopping_tt.Models;
using Shopping_tt.Repository;
using Shopping_tt.Models.ViewModel;

namespace Shopping_tt.Controllers
{
	public class CartController : Controller
	{
		private readonly DataContext _dataContext;
		public CartController(DataContext context)
		{
			_dataContext = context;
		}
		public IActionResult Index() 
		{
			List<CartitemModel> cartitems = HttpContext.Session.GetJson<List<CartitemModel>>("Cart") ?? new List<CartitemModel>();
			CartItemViewModel cartVM = new()
			{
				Cartitems = cartitems,
				GrandTotal = cartitems.Sum(x => x.Quality*x.Price)
			};

			return View(cartVM);
		}
		public ActionResult CheckOut()
		{
			return View("~/Views/CheckOut/Index.cshtml");
		}
		public async Task<IActionResult> Add(int Id)
		{
			ProductModel product = await _dataContext.Products.FindAsync(Id);
			List<CartitemModel> cart = HttpContext.Session.GetJson<List<CartitemModel>>("Cart") ?? new List<CartitemModel>();
			CartitemModel cartItems = cart.Where(x => x.ProductId == Id).FirstOrDefault();
			if (cartItems == null)
			{
				cart.Add(new CartitemModel(product));
			}
			else
			{
				cartItems.Quality += 1;
			}
			HttpContext.Session.SetJson("Cart", cart);
			TempData["success"] = "Add item success";
			return Redirect(Request.Headers["Referer"].ToString());
		}
		public async Task<IActionResult> Decrease(int Id)
		{
			List<CartitemModel> cart = HttpContext.Session.GetJson<List<CartitemModel>>("Cart") ;
			CartitemModel cartItem = cart.Where(c => c.ProductId==Id).FirstOrDefault();
			if (cartItem.Quality > 1)
			{
				--cartItem.Quality;
			}
			else
			{
				cart.RemoveAll(p => p.ProductId == Id);
			}
			if (cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);
			}
            TempData["success"] = "Decraese item success";
            return RedirectToAction("Index");

		}
		public async Task<IActionResult> Increase(int Id)
		{
			List<CartitemModel> cart = HttpContext.Session.GetJson<List<CartitemModel>>("Cart");
			CartitemModel cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();
			if (cartItem.Quality >= 1)
			{
				++cartItem.Quality;
			}
			else
			{
				cart.RemoveAll(p => p.ProductId == Id);
			}
			if (cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);
			}
            TempData["success"] = "Increase item success";
            return RedirectToAction("Index");
		}
		public async Task<IActionResult> Remove(int Id)
		{
			List<CartitemModel> cart = HttpContext.Session.GetJson<List<CartitemModel>>("Cart");
			cart.RemoveAll(p => p.ProductId == Id);
			if (cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);
			}
            TempData["success"] = "Remove item success";
            return RedirectToAction("Index");
		}
		public async Task<IActionResult> Clear()
		{
			HttpContext.Session.Remove("Cart");
            TempData["success"] = "Remove cart success";
            return RedirectToAction("Index");
		}
		}
}
