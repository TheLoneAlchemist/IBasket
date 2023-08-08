using FirstRazor.Data;
using FirstRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<Category> Categories { get; set; }
        public IndexModel(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public void OnGet()
        {
            Categories = _db.Categories;

        }
        

    }
}
