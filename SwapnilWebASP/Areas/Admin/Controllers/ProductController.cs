using Microsoft.AspNetCore.Mvc;
using SwapnilAsp.DataAccess.Repository.IRepository;
using SwapnilAsp.Models;

namespace SwapnilWebASP.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
			return View(objProductList);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Product obj)
		{
			if (obj.Title == obj.Description)
			{
				ModelState.AddModelError("name", "The DisplayOrder exacly cannot match the name.");
			}
			if (ModelState.IsValid)
			{
				_unitOfWork.Product.Add(obj);
				_unitOfWork.Save();
				TempData["success"] = "Product created successfully";
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
			Product? productdb = _unitOfWork.Product.Get(u => u.Id == id);
			//Category? categorydb1 = _db.Categories.FirstOrDefault(c => c.Id == id);
			//Category? categorydb2 = _db.Categories.Where(c => c.Id == id).FirstOrDefault();
			if (productdb == null)
			{
				return NotFound();
			}
			return View(productdb);
		}
		[HttpPost]
		public IActionResult Edit(Product obj)
		{


			if (ModelState.IsValid)
			{
				_unitOfWork.Product.Update(obj);
				_unitOfWork.Save();
				TempData["success"] = "Product updated successfully";
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
			Product? categorydb = _unitOfWork.Product.Get(u => u.Id == id);
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
			Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
			if (obj == null)
			{
				return NotFound();
			}


			_unitOfWork.Product.Remove(obj);
			_unitOfWork.Save();
			TempData["success"] = "Product deleted successfully";
			return RedirectToAction("Index");






		}
	}
}
