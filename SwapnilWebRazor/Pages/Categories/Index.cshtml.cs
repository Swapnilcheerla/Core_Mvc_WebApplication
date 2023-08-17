using Microsoft.AspNetCore.Mvc.RazorPages;
using SwapnilWebRazor.Data;
using SwapnilWebRazor.Models;

namespace SwapnilWebRazor.Pages.Categories
{
	public class IndexModel : PageModel
	{
		private readonly ApplicationDbContext _db;
		public List<Category> CategoryList { get; set; }
		public IndexModel(ApplicationDbContext db)
		{
			_db = db;
		}
		public void OnGet()
		{
			CategoryList = _db.Categories.ToList();
		}
	}
}
