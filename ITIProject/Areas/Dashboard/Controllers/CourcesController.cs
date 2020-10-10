using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using PagedList;
using System.Web;
using System.Web.Mvc;
using ITIProject.Models;
using ITIProject.Models.DBFiles;

namespace ITIProject.Areas.Dashboard.Controllers
{
    public class CourcesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dashboard/Cources
        public ActionResult Index(string searchBy, string SearchKeyWord, int? pageNumber, int? pageSize)
        {
            if (searchBy == "Department")
            {
                var courses = db.Courses.Where(c => c.Department.Name.Contains(SearchKeyWord)).Include(c => c.Department).Include(c => c.Professor).AsQueryable();
                return View(courses.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 8));
            }
            else if (searchBy == "Professor")
            {
                var courses = db.Courses.Where(c => c.Professor.Name.Contains(SearchKeyWord)).Include(c => c.Department).Include(c => c.Professor).AsQueryable();
                return View(courses.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 8));
            }
            else if (!string.IsNullOrEmpty(SearchKeyWord))
            {
                var courses = db.Courses.Where(x => x.Name.Contains(SearchKeyWord)).Include(s => s.Department).Include(s => s.Professor).AsQueryable();
                return View(courses.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 8));
            }
            else
            {
                var courses = db.Courses.Include(s => s.Department).Include(s => s.Professor).AsQueryable();
                return View(courses.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 8));
            }
        }

        // GET: Dashboard/Cources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cource cource = db.Courses.Find(id);
            if (cource == null)
            {
                return HttpNotFound();
            }
            return View(cource);
        }

        // GET: Dashboard/Cources/Create
        public ActionResult Create()
        {
            ViewBag.Course_Department_ID = new SelectList(db.Deparments, "ID", "Name");
            ViewBag.Course_Professor_ID = new SelectList(db.Professors, "ID", "Name");
            return View();
        }

        // POST: Dashboard/Cources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Free,Cost,Hours,Degree,MinDegree,Course_Department_ID,Course_Professor_ID")] Cource cource)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(cource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_Department_ID = new SelectList(db.Deparments, "ID", "Name", cource.Course_Department_ID);
            ViewBag.Course_Professor_ID = new SelectList(db.Professors, "ID", "Name", cource.Course_Professor_ID);
            return View(cource);
        }

        // GET: Dashboard/Cources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cource cource = db.Courses.Find(id);
            if (cource == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_Department_ID = new SelectList(db.Deparments, "ID", "Name", cource.Course_Department_ID);
            ViewBag.Course_Professor_ID = new SelectList(db.Professors, "ID", "Name", cource.Course_Professor_ID);
            return View(cource);
        }

        // POST: Dashboard/Cources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Free,Cost,Hours,Degree,MinDegree,Course_Department_ID,Course_Professor_ID")] Cource cource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_Department_ID = new SelectList(db.Deparments, "ID", "Name", cource.Course_Department_ID);
            ViewBag.Course_Professor_ID = new SelectList(db.Professors, "ID", "Name", cource.Course_Professor_ID);
            return View(cource);
        }

        // GET: Dashboard/Cources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cource cource = db.Courses.Find(id);
            if (cource == null)
            {
                return HttpNotFound();
            }
            return View(cource);
        }

        // POST: Dashboard/Cources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cource cource = db.Courses.Find(id);
            db.Courses.Remove(cource);
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
