using Ecom.Models;
using Microsoft.AspNetCore.Mvc;
using Ecom.DataAccess.Data;
using Ecom.DataAccess.Repository.IRepository;
using Ecom.DataAccess.Repository;

namespace RzEcom.Areas.Admin.Controllers
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
            var productList = _unitOfWork.Product.GetAll().ToList();
            return View(productList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            //if(category.Name == category.DisplayOrder.ToString())
            //{
            //   ModelState.AddModelError("name", "The Display Order cannot exactly match with the Name.");
            // }

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully!";
                return Redirect("Index");
            }

            return View();
        }
        public IActionResult Edit(int? id, Product product)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            product = _unitOfWork.Product.Get(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            //if(category.Name == category.DisplayOrder.ToString())
            //{
            //   ModelState.AddModelError("name", "The Display Order cannot exactly match with the Name.");
            // }

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully!";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id, Product product)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            product = _unitOfWork.Product.Get(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id, Product product)
        {

            product = _unitOfWork.Product.Get(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully!";
            return RedirectToAction("Index");
        }

    }
}
