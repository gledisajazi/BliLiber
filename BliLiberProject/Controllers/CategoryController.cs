using BliLiberProject.Data;
using BliLiberProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BliLiberProject.Controllers
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
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj) 
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Renditja nuk mund të bëhet match me Kategorinë");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Kategoria u krijua";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            } 
            var categoryFromDb = _db.Categories.Find(id);
            //var categeryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categeryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Renditja nuk mund të bëhet match me Kategorinë");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Kategoria u përditësua";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categeryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categeryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (id == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Kategoria u fshi";
            return RedirectToAction("Index");
        }
    }
}

