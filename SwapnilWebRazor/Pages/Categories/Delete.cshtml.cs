using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SwapnilWebRazor.Data;
using SwapnilWebRazor.Models;

namespace SwapnilWebRazor.Pages.Categories
{
	[BindProperties]
	public class DeleteModel : PageModel
	{
		private readonly ApplicationDbContext _db;

		public Category Category { get; set; }
		public DeleteModel(ApplicationDbContext db)
		{
			_db = db;
		}
		public void OnGet(int? id)

		{
			if (id != null && id != 0)
			{
				Category = _db.Categories.Find(id);
			}



			//Category? categorydb1 = _db.Categories.FirstOrDefault(c => c.Id == id);
			//Category? categorydb2 = _db.Categories.Where(c => c.Id == id).FirstOrDefault();

		}

		public IActionResult OnPost()
		{

			_db.Categories.Remove(Category);
			_db.SaveChanges();
			TempData["success"] = "Category deleted successfully";
			return RedirectToPage("Index");


		}
	}
}
