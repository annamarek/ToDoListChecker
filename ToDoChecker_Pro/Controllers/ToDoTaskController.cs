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
    }
}
