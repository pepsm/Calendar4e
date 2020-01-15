using Calendar4e.Data;
using Calendar4e.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Calendar4e.Controllers
{
    //      Route /Admin
    public class AdminController : Controller
    {
        private readonly TaskContext db = new TaskContext();

        // GET: /
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Complaints/
        public ActionResult Complaints()
        {
            return View(db.Complaints.ToList());
        }

        // GET: /DeleteComplaint/5
        public ActionResult DeleteComplaint(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint @complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            db.Complaints.Remove(@complaint);
            db.SaveChanges();
            return RedirectToAction("Complaints", "Admin");
        }

        //GET: /DeleteUser/5
        public ActionResult DeleteUser(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student @user = db.Students.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            
            // Delete Complaints of the user
            foreach (var c in db.Complaints.ToList())
            {
                if(c.Student.StudentID == user.StudentID)
                {
                    db.Complaints.Remove(c);
                }
            }

            // Delete Taks of the user
            foreach (var t in db.Tasks.ToList())
            {
                if (t.Student.StudentID == user.StudentID)
                {
                    db.Tasks.Remove(t);
                }
            }

            db.Students.Remove(@user);
            db.SaveChanges();
            return RedirectToAction("Users", "Admin");
        }


        //GET: /Admin/Users

        public ActionResult Users()
        {
            return View(db.Students.ToList());
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