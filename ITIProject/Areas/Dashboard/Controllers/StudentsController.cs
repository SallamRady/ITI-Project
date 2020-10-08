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
using PagedList;
using System.IO;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ITIProject.Areas.Dashboard.Controllers
{
    [Authorize(Roles ="Admins,Managers,Professors")]
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dashboard/Students
        public ActionResult Index(string searchBy,string SearchKeyWord,int? pageNumber,int? pageSize)
        {
            if(searchBy == "City")
            {
                var students = db.Students.Where(x=>x.City.Contains(SearchKeyWord)).Include(s => s.Department).Include(s => s.Professor).AsQueryable();
                return View(students.ToList().ToPagedList(pageNumber??1, pageSize??8));
            } else if(searchBy == "Department")
            {
                var students = db.Students.Where(x => x.Department.Name.Contains(SearchKeyWord)).Include(s => s.Department).Include(s => s.Professor).AsQueryable();
                return View(students.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 8));
            } else if (!string.IsNullOrEmpty(SearchKeyWord))
            {
                var students = db.Students.Where(x => x.Name.Contains(SearchKeyWord)).Include(s => s.Department).Include(s => s.Professor).AsQueryable();
                return View(students.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 8));
            }
            else {
                var students = db.Students.Include(s => s.Department).Include(s => s.Professor).AsQueryable();
                return View(students.ToList().ToPagedList(pageNumber??1, pageSize ?? 8));
            }
        }

        // GET: Dashboard/Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Dashboard/Students/Create
        public ActionResult Create()
        {
            ViewBag.Student_Department_ID = new SelectList(db.Deparments, "ID", "Name");
            ViewBag.Student_Professor_supervisior_ID = new SelectList(db.Professors, "ID", "Name");
            return View();
        }

        // POST: Dashboard/Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,City,Image,Level,BirthYear,Student_Department_ID,Student_Professor_supervisior_ID")] Student student,HttpPostedFile ImageFile)
        {
            //return Content(ImageFile.FileName);
            //manage Images... :)
            //if(!string.IsNullOrEmpty(ImageFile.FileName))
            //{
            //    string fileName  = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            //    fileName += DateTime.Now.ToString("yymmssfff");
            //    string extention = Path.GetExtension(ImageFile.FileName);
            //    fileName = fileName + extention;
            //    student.Image = "~/Content/Images/" + fileName;
            //    fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
            //    ImageFile.SaveAs(fileName);
            //}
            //else
            //{
            //    student.Image = "~/Content/Images/default.png";
            //}
            
            if (ModelState.IsValid)
            {
                student.Image = "~/Content/Images/default.png";
                db.Students.Add(student);
                db.SaveChanges();
                CreateUser(student.Name, student.Email);
                return RedirectToAction("Index");
            }
            
            ViewBag.Student_Department_ID = new SelectList(db.Deparments, "ID", "Name", student.Student_Department_ID);
            ViewBag.Student_Professor_supervisior_ID = new SelectList(db.Professors, "ID", "Name", student.Student_Professor_supervisior_ID);
            return View(student);
        }

        private void CreateUser(string name,string email)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser user = new ApplicationUser();
            user.UserName = name;
            user.Email = email;
            var check = userManager.Create(user, "#Sallam@501#");
            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Students");
            }
        }
        // GET: Dashboard/Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Student_Department_ID = new SelectList(db.Deparments, "ID", "Name", student.Student_Department_ID);
            ViewBag.Student_Professor_supervisior_ID = new SelectList(db.Professors, "ID", "Name", student.Student_Professor_supervisior_ID);
            return View(student);
        }

        // POST: Dashboard/Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,City,Level,BirthYear,Student_Department_ID,Student_Professor_supervisior_ID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Student_Department_ID = new SelectList(db.Deparments, "ID", "Name", student.Student_Department_ID);
            ViewBag.Student_Professor_supervisior_ID = new SelectList(db.Professors, "ID", "Name", student.Student_Professor_supervisior_ID);
            return View(student);
        }

        // GET: Dashboard/Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Dashboard/Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
