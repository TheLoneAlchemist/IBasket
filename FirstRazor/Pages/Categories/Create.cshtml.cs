using FirstRazor.Data;
using FirstRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstRazor.Pages.Categories
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (int.TryParse(Category.Title, out _))
            {
                ModelState.AddModelError("Category.Title", "Title can not be a number");
            }

            if(ModelState.IsValid)
            {
            await _context.Categories.AddAsync(Category);
            await _context.SaveChangesAsync();
                TempData["success"] = $"{Category.Title} is created!";
            return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
