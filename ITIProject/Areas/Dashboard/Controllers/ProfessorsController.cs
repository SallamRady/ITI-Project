using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using PagedList;
using System.Web.Mvc;
using ITIProject.Models;
using ITIProject.Models.DBFiles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ITIProject.Areas.Dashboard.Controllers
{
    public class ProfessorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dashboard/Professors
        public ActionResult Index(string searchBy, string SearchKeyWord, int? pageNumber, int? pageSize)
        {
            if (searchBy == "City")
            {
                var professors = db.Professors.Where(x => x.City.Contains(SearchKeyWord)).Include(s => s.Department).Include(s => s.Courses_prof_teach).AsQueryable();
                return View(professors.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 8));
            }
            else if (searchBy == "Department")
            {
                var professors = db.Professors.Where(x => x.Department.Name.Contains(SearchKeyWord)).Include(s => s.Department).Include(s => s.Courses_prof_teach).AsQueryable();
                return View(professors.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 8));
            }
            else if (!string.IsNullOrEmpty(SearchKeyWord))
            {
                var professors = db.Professors.Where(x => x.Name.Contains(SearchKeyWord)).Include(s => s.Department).Include(s => s.Courses_prof_teach).AsQueryable();
                return View(professors.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 8));
            }
            else
            {
                var professors = db.Professors.Include(s => s.Department).Include(s => s.Courses_prof_teach).AsQueryable();
                return View(professors.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 8));
            }
        }

        // GET: Dashboard/Professors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: Dashboard/Professors/Create
        public ActionResult Create()
        {
            ViewBag.Professor_Department_ID = new SelectList(db.Deparments, "ID", "Name");
            return View();
        }

        // POST: Dashboard/Professors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,City,Salary,Roles,Professor_Department_ID")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Professors.Add(professor);
                CreateUser(professor.Name, professor.Email);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Professor_Department_ID = new SelectList(db.Deparments, "ID", "Name", professor.Professor_Department_ID);
            return View(professor);
        }

        private void CreateUser(string name, string email)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser user = new ApplicationUser();
            user.UserName = name;
            user.Email = email;
            var check = userManager.Create(user, "#Sallam@501#");
            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Professors");
            }
        }

        // GET: Dashboard/Professors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Professor_Department_ID = new SelectList(db.Deparments, "ID", "Name", professor.Professor_Department_ID);
            return View(professor);
        }

        // POST: Dashboard/Professors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,City,Salary,Roles,Professor_Department_ID")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Professor_Department_ID = new SelectList(db.Deparments, "ID", "Name", professor.Professor_Department_ID);
            return View(professor);
        }

        // GET: Dashboard/Professors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Dashboard/Professors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor professor = db.Professors.Find(id);
            db.Professors.Remove(professor);
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
