using Microsoft.AspNetCore.Mvc;
using SwapnilAsp.DataAccess.Repository.IRepository;
using SwapnilAsp.Models;

namespace SwapnilWebASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;



        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();

            return View(objCompanyList);
        }
        public IActionResult Upsert(int? id)  //update and insert
        {
            //IEnumerable<SelectListItem> CategoryList =
            //ViewBag.CategoryList = CategoryList;
            //ViewData["CategoryList"] = CategoryList;

            if (id == null || id == 0)
            {
                return View(new Company());

            }
            else
            {
                Company companyobj = _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyobj);
            }

        }
        [HttpPost]
        public IActionResult Upsert(Company Companyobj)
        {

            if (ModelState.IsValid)
            {


                if (Companyobj.Id == 0)
                {
                    _unitOfWork.Company.Add(Companyobj);
                    _unitOfWork.Save();
                    TempData["success"] = "Company created successfully";
                }
                else
                {
                    _unitOfWork.Company.Update(Companyobj);
                    _unitOfWork.Save();
                    TempData["success"] = "Updated created successfully";
                }



                return RedirectToAction("Index");



            }
            else
            {
                return View(Companyobj);

            }

        }






        //public IActionResult Delete(int? id)
        //{
        //	if (id == null || id == 0)
        //	{
        //		return NotFound();
        //	}
        //	Company? productdb = _unitOfWork.Company.Get(u => u.Id == id);
        //	//Category? categorydb1 = _db.Categories.FirstOrDefault(c => c.Id == id);
        //	//Category? categorydb2 = _db.Categories.Where(c => c.Id == id).FirstOrDefault();
        //	if (productdb == null)
        //	{
        //		return NotFound();
        //	}
        //	return View(productdb);
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePost(int? id)
        //{
        //	Company? obj = _unitOfWork.Company.Get(u => u.Id == id);
        //	if (obj == null)
        //	{
        //		return NotFound();
        //	}


        //	_unitOfWork.Company.Remove(obj);
        //	_unitOfWork.Save();
        //	TempData["success"] = "Company deleted successfully";
        //	return RedirectToAction("Index");






        //}
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if (companyToBeDeleted == null)
            {
                return Json(new { sucess = false, message = "Error while deleting" });
            }
            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { succes = true, message = "Delete Successful" });
        }
        #endregion
    }
}
