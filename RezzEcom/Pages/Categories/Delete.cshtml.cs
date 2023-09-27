using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RezzEcom.Data;
using RezzEcom.Models;

namespace RezzEcom.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id, Category category)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.FirstOrDefault(c => c.Id == id);
            }
        }
        public IActionResult OnPost(int? id, Category category)
        {

            category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _db.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
