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
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dashboard/Departments
        public ActionResult Index()
        {
            var deparments = db.Deparments.Include(d => d.Professor);
            return View(deparments.ToList());
        }

        // GET: Dashboard/Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Deparments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Dashboard/Departments/Create
        public ActionResult Create()
        {
            ViewBag.Manager_ID = new SelectList(db.Professors, "ID", "Name");
            return View();
        }

        // POST: Dashboard/Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Manager_ID")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Deparments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Manager_ID = new SelectList(db.Professors, "ID", "Name", department.Manager_ID);
            return View(department);
        }

        // GET: Dashboard/Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Deparments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.Manager_ID = new SelectList(db.Professors, "ID", "Name", department.Manager_ID);
            return View(department);
        }

        // POST: Dashboard/Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Manager_ID")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Manager_ID = new SelectList(db.Professors, "ID", "Name", department.Manager_ID);
            return View(department);
        }

        // GET: Dashboard/Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Deparments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Dashboard/Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Deparments.Find(id);
            db.Deparments.Remove(department);
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
