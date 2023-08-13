using IBasket.DataAccess;
using IBasket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IBasket.Pages.Lostitem
{
    public class AddModel : PageModel
    {
        public IEnumerable<SelectListItem> categorylist { get; set;  }
        public MissingItem LostItem { get; set; }
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AddModel(ApplicationDbContext dbContext,IWebHostEnvironment webHostEnvironment )
        {
            _context = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
            categorylist = _context.Categories.ToList().Select(z => new SelectListItem { Text = z.Title, Value = z.Id.ToString() });
        }


        public async Task<IActionResult> OnPost(MissingItem item, IFormFile? itemimg)
        {
            if (ModelState.IsValid)
            {
                string wwwrootpath = _webHostEnvironment.WebRootPath;
                if(itemimg != null)
                {
                    string filename = Guid.NewGuid().ToString() + "-pid-" + item.Name + Path.GetExtension(itemimg.FileName);
                    string itemImagePath = Path.Combine(wwwrootpath, @"images\item");
                    using(var filestream = new FileStream(Path.Combine(itemImagePath,filename),FileMode.OpenOrCreate))
                    {
                       await itemimg.CopyToAsync(filestream);
                    }

                    LostItem.Image = @"\images\missing\" + filename;
                }
                await _context.MissingItems.AddAsync(item);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");


            }
            return Page();
        }
    }
}
