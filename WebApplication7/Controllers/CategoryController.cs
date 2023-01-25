using Microsoft.AspNetCore.Mvc;
using WebApplication7.Data;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{

    public class CategoryController : Controller
    {
        private readonly WebappDb _db;

        public CategoryController(WebappDb db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> CategorieList= _db.Categories.ToList();
            return View(CategorieList);
        }

      
        public IActionResult CreateNewCat() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNewCat(Category category) 
        {
            if(_db.Categories.Any(x=>x.Name==category.Name)) 
            {
                ModelState.AddModelError("ExistingError", "This category already exits!");
            }
            if(ModelState.IsValid) 
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            {
                return View(category);
            }
           
        }
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null) 
            {
                return NotFound();  
            }
            var category = _db.Categories.FirstOrDefault(x=>x.Id==id);

            if (category == null) 
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Category category)
        {
            if (_db.Categories.Any(x => x.Name == category.Name))
            {
                ModelState.AddModelError("ExistingError", "This category already exits!");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }

        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeletePost(int? id)
        {
            var obj=_db.Categories.Find(id);
            
            if (obj==null)
            {
                return NotFound(nameof(obj));
            }

           
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
    
            

        }
    }
}
