using IBasket.DataAccess;
using IBasket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IBasket.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }
        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public void OnGet(int id)
        {
            Category = _context.Categories.Where(i => i.Id == id).FirstOrDefault();
        }
        public async Task<IActionResult> OnPost()
        {
            
           
                if (ModelState.IsValid)
                {

            _context.Categories.Remove(Category);
            await _context.SaveChangesAsync();
                TempData["success"] = $"{Category.Title} is removed!";
            return RedirectToPage("Index");

            }

            return Page();
        }
    }
}
