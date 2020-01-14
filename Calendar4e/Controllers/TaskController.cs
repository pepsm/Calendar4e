using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Calendar4e.App_Start;
using Calendar4e.Data;
using Calendar4e.Models;

namespace Calendar4e.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskContext db = new TaskContext();

        // GET: Task
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["Username"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Home");

        }

        public JsonResult GetTasks()
        {
            db.Configuration.ProxyCreationEnabled = false;
                
            var tasks = db.Tasks.ToArray();
        
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
        public ActionResult Create([Bind(Include = "subject,description,start,end,allDay")] Task @task)
        {
            if (ModelState.IsValid)
            {
                Student student = (Student)Session["Student"];
                task.Student = student;
                task.color = student.ThemeColor;
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
        public ActionResult Edit([Bind(Include = "TaskID,Subject,Description,Start,End,AllDay")] Task @task)
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
            db.Tasks.Remove(@task);
            db.SaveChanges();
            return RedirectToAction("Index", "Task");
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
