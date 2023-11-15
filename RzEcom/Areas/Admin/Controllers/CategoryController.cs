using Ecom.Models;
using Microsoft.AspNetCore.Mvc;
using Ecom.DataAccess.Data;
using Ecom.DataAccess.Repository.IRepository;
using Ecom.DataAccess.Repository;
using Ecom.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace RzEcom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var categoryList = _unitOfWork.Category.GetAll().ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            //if(category.Name == category.DisplayOrder.ToString())
            //{
            //   ModelState.AddModelError("name", "The Display Order cannot exactly match with the Name.");
            // }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully!";
                return Redirect("Index");
            }

            return View();
        }
        public IActionResult Edit(int? id, Category category)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            category = _unitOfWork.Category.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //if(category.Name == category.DisplayOrder.ToString())
            //{
            //   ModelState.AddModelError("name", "The Display Order cannot exactly match with the Name.");
            // }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id, Category category)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            category = _unitOfWork.Category.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id, Category category)
        {

            category = _unitOfWork.Category.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }

    }
}
