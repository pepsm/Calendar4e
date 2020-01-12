
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Calendar4e.Data;
using Calendar4e.Models;

namespace Calendar4e.Controllers
{
    public class ComplaintsController : Controller
    {
        private TaskContext db = new TaskContext();

        // GET: Complaints
        public ActionResult Index()
        {
            return View(db.Complaints.ToList());
        }


        // POST: Complaints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description,Email,DirectedToUser")] Complaint @complaint)
        {
            if (ModelState.IsValid)
            {
                complaint.Date = DateTime.Now.ToString();
                db.Complaints.Add(complaint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complaint);
        }


        // No delete, for now.

        /*// GET: Complaints/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // POST: Complaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Complaint complaint = db.Complaints.Find(id);
            db.Complaints.Remove(complaint);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

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