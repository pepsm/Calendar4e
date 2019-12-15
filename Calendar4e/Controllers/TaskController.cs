using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Calendar4e.Data;
using Calendar4e.Models;

namespace Calendar4e.Controllers
{
    public class TaskController : Controller
    {
        private TaskContext db = new TaskContext();

        // GET: Task
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetTasks()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var tasks = db.Tasks.ToList();
            return Json(tasks, JsonRequestBehavior.AllowGet);
        }

        // GET: Tasks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task @task = db.Tasks.Find(id);
            if (@task == null)
            {
                return HttpNotFound();
            }
            return View(@task);
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        
        // POST: Task/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,subject,description,start,end,allDay")] Task @task)
        {
            if (ModelState.IsValid)
            {
                @task.StudentId = 1;
                db.Tasks.Add(@task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@task);
        }



        // GET: Tasks/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task @task = db.Tasks.Find(id);
            if (@task == null)
            {
                return HttpNotFound();
            }
            return View(@task);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,subject,description,start,end,allDay")] Task @task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task @task = db.Tasks.Find(id);
            if (@task == null)
            {
                return HttpNotFound();
            }
            return View(@task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Task @task = db.Tasks.Find(id);
            db.Tasks.Remove(@task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
