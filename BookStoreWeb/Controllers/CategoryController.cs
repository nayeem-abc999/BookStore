using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Controllers
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
            List<Category> categoriesList = _db.Categories.ToList();

			return View(categoriesList);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Category obj)
		{
			if (ModelState.IsValid)
			{
				_db.Categories.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Category created successfully";
				return RedirectToAction("Index");
			}
			return View();
			
		}
		public IActionResult Edit(int id)
		{
			Category obj = _db.Categories.Find(id);

			return View(obj);
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

		public IActionResult Delete(int id)
		{
			Category obj = _db.Categories.Find(id);

			return View(obj);
		}


		//I can use Category obj as parametet but doing with id
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int id)
		{
			if (ModelState.IsValid)
			{
				Category obj = _db.Categories.Find(id);
				_db.Categories.Remove(obj);
				_db.SaveChanges();
				TempData["success"] = "Category deleted successfully";
				return RedirectToAction("Index");
			}
			return View();

		}


	}
}
