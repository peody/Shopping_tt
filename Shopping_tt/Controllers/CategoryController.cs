using Microsoft.AspNetCore.Mvc;
using Shopping_tt.Models;
using Shopping_tt.Repository;

namespace Shopping_tt.Controllers 
{
   
    public class CategoryController : Controller
    {
		private readonly DataContext _dataContext;
        public CategoryController(DataContext context)
        {
            _dataContext = context;
        }
		public async Task<IActionResult> Index(string Slug = "")
        {
            CategoryModel category = _dataContext.Categories.Where(c => c.Slug == Slug).FirstOrDefault();
        }
    }
}
