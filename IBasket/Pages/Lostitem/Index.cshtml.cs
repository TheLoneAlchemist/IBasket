using IBasket.Data;
using IBasket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IBasket.Pages.Lostitem
{
    public class IndexModel : PageModel
    {
        public IEnumerable<MissingItem> LostItem { get; set; }
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public void OnGet()
        {
            LostItem = _context.MissingItems;
        }
    }
}
