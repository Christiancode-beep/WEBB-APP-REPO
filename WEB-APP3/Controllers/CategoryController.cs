using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WEB_APP3.Data;
using WEB_APP3.Models;

namespace WEB_APP3.Controllers
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
            IEnumerable<Category> objCategoriesList = _db.Categories;
            return View(objCategoriesList);
        }

        //GET REQUEST
        public IActionResult Create()
        {
            
            return View();
        }

        //POST REQUEST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category created successfully";
                return RedirectToAction("Index");
            
            }
            return View(obj);
        
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id ==null || id == 0)
            {
                return NotFound(id);

            }

            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (categoryFromDb ==null) {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        //POST REQUEST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category updated successfully";
                return RedirectToAction("Index");
                

            }
            return View(obj);

        }

        //PUT(DELETE)
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(id);

            }

            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        //POST REQUEST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);

          if (obj==null)
            {
                return NotFound();
               
            }
       
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category deleted successfully";
            return RedirectToAction("Index");
            //return View(obj);
        }
        //return View(obj);

        //GET REQUEST
        //public IActionResult Create()
        //{

        //    return View();
        //}
    }
}
