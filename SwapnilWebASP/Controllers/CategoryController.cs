using Microsoft.AspNetCore.Mvc;
using SwapnilAsp.DataAccess.Data;
using SwapnilAsp.Models;

namespace SwapnilWebASP.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;

		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<Category> objCategoryList = _db.Categories.ToList();
			return View(objCategoryList);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "The DisplayOrder exacly cannot match the name.");
			}
			if (ModelState.IsValid)
			{
				_db.Categories.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Category created successfully";
				return RedirectToAction("Index");



			}
			return View();

		}
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categorydb = _db.Categories.Find(id);
			//Category? categorydb1 = _db.Categories.FirstOrDefault(c => c.Id == id);
			//Category? categorydb2 = _db.Categories.Where(c => c.Id == id).FirstOrDefault();
			if (categorydb == null)
			{
				return NotFound();
			}
			return View(categorydb);
		}
		[HttpPost]
		public IActionResult Edit(Category obj)
		{


			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Category updated successfully";
				return RedirectToAction("Index");



			}
			return View();

		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categorydb = _db.Categories.Find(id);
			//Category? categorydb1 = _db.Categories.FirstOrDefault(c => c.Id == id);
			//Category? categorydb2 = _db.Categories.Where(c => c.Id == id).FirstOrDefault();
			if (categorydb == null)
			{
				return NotFound();
			}
			return View(categorydb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? id)
		{
			Category? obj = _db.Categories.Find(id);
			if (obj == null)
			{
				return NotFound();
			}


			_db.Categories.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index");






		}
	}
}
