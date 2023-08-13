using IBasket.DataAccess;
using IBasket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IBasket.Pages.Categories
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public void OnGet(int id)
        {
            Category = _context.Categories.Where(i => i.Id == id).FirstOrDefault();
        }
        public async Task<IActionResult> OnPost()
        {
            if (int.TryParse(Category.Title, out _))
            {
                ModelState.AddModelError("Category.Title", "Title can not be a number");
            }
           
                if (ModelState.IsValid)
                {

                _context.Categories.Update(Category);
                await _context.SaveChangesAsync();
                TempData["success"] = $"{Category.Title} is updated!";
                return RedirectToPage("Index");

                }
            
            return Page();
        }
    }
}
