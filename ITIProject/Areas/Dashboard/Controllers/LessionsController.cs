using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITIProject.Models;
using ITIProject.Models.DBFiles;

namespace ITIProject.Areas.Dashboard.Controllers
{
    public class LessionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dashboard/Lessions
        public ActionResult Index()
        {
            var lessions = db.Lessions.Include(l => l.Cource);
            return View(lessions.ToList());
        }

        // GET: Dashboard/Lessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lession lession = db.Lessions.Find(id);
            if (lession == null)
            {
                return HttpNotFound();
            }
            return View(lession);
        }

        // GET: Dashboard/Lessions/Create
        public ActionResult Create()
        {
            ViewBag.course_id = new SelectList(db.Courses, "ID", "Name");
            return View();
        }

        // POST: Dashboard/Lessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,SubTitle,Content,course_id")] Lession lession)
        {
            if (ModelState.IsValid)
            {
                db.Lessions.Add(lession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.course_id = new SelectList(db.Courses, "ID", "Name", lession.course_id);
            return View(lession);
        }

        // GET: Dashboard/Lessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lession lession = db.Lessions.Find(id);
            if (lession == null)
            {
                return HttpNotFound();
            }
            ViewBag.course_id = new SelectList(db.Courses, "ID", "Name", lession.course_id);
            return View(lession);
        }

        // POST: Dashboard/Lessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,SubTitle,Content,course_id")] Lession lession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.course_id = new SelectList(db.Courses, "ID", "Name", lession.course_id);
            return View(lession);
        }

        // GET: Dashboard/Lessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lession lession = db.Lessions.Find(id);
            if (lession == null)
            {
                return HttpNotFound();
            }
            return View(lession);
        }

        // POST: Dashboard/Lessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lession lession = db.Lessions.Find(id);
            db.Lessions.Remove(lession);
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
