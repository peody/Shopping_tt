using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_tt.Models;
using Shopping_tt.Repository;

namespace Shopping_tt.Controllers 
{
   
    public class CategoryController : Controller
    {
		private readonly DataContext _dataContext;
        public CategoryController(DataContext Context) 
        {
            _dataContext = Context;
        }
        public async Task<IActionResult> Index(String Slug )
        {
            CategoryModel category = _dataContext.Categories.Where(c => c.Slug == Slug).FirstOrDefault();
            if (category == null) return RedirectToAction("Index");
            var productsByCategory = _dataContext.Products.Where(p => p.CatagoryId == category.Id );
            return View(await productsByCategory.OrderByDescending(p => p.Id).ToListAsync());
        }
    }
}
