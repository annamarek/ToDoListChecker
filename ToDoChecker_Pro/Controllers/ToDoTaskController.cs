using Microsoft.AspNetCore.Mvc;
using ToDoChecker_Pro.Data;
using ToDoChecker_Pro.Models;

namespace ToDoChecker_Pro.Controllers
{
    public class ToDoTaskController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ToDoTaskController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            List<ToDoTask> ToDoTasksList = _db.ToDoTasks.ToList();
            return View(ToDoTasksList);
        }
        [HttpPost]
        public IActionResult Ex([FromBody] int id)
        {
            var model = _db.ToDoTasks.FirstOrDefault(x => x.Id == id);

            if (model != null)
            {
                model.IsDone = !model.IsDone;
                _db.SaveChanges();

                return Json(new { success = true, isDone = model.IsDone });
            }

            return Json(new { success = false, message = "Task not found." });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToDoTask obj)
        {
            if (ModelState.IsValid)
            {
                _db.ToDoTasks.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Task was added successfully";
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
            ToDoTask? task = _db.ToDoTasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(ToDoTask obj)
        {
            if (ModelState.IsValid)
            {
                _db.ToDoTasks.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Task was updated successfully";
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
            ToDoTask? task = _db.ToDoTasks.Find(id);
            
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            ToDoTask? obj = _db.ToDoTasks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ToDoTasks.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Task was deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
