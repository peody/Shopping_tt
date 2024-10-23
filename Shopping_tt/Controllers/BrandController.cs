using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_tt.Models;
using Shopping_tt.Repository;

namespace Shopping_tt.Controllers
{
	

	public class BrandController : Controller
	{
		private readonly DataContext _dataContext;

		public BrandController(DataContext context)
		{
			_dataContext = context;
		}
		public async Task<IActionResult> Index(string Slug = "")
		{
			BrandModel band = _dataContext.Brands.Where(c => c.Slug == Slug).FirstOrDefault();
			if (band == null) return RedirectToAction("Index");
			var productByBrand = _dataContext.Products.Where(p => p.BrandId == band.Id);
			return View(await productByBrand.OrderByDescending(p => p.Id).ToListAsync());
		}

	}
}
