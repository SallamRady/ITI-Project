using ITIProject.Models;
using ITIProject.Models.DBFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity;

namespace ITIProject.Areas.Site.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Login()
        {
            return View();
        }

        // GET: Site/Home
        public ActionResult Index(int? pageNumber, int? pageSize)
        {
            ViewBag.Departments = db.Deparments.ToList();
            ViewBag.Pages = db.Pages.ToList();
            var cources = db.Courses.Include(s => s.Department).Include(s => s.Professor).AsQueryable();
            return View(cources.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 5));
        }

        [HttpPost]
        public ActionResult SendMessage(string Email,string Content)
        {
            Message message = new Message();
            message.Email   = Email;
            message.Content = Content;
            message.Time    = DateTime.Now.ToString();
            db.Messages.Add(message);
            db.SaveChanges();
            ViewBag.Departments = db.Deparments.ToList();
            ViewBag.Pages = db.Pages.ToList();
            return RedirectToAction("LandScap");
        }
        public ActionResult Search(string SearchKeyWord)
        {
            ViewBag.Departments = db.Deparments.ToList();
            ViewBag.Pages = db.Pages.ToList();
            var cources = db.Courses.Where(c=>c.Name.Contains(SearchKeyWord)).Include(s => s.Department).Include(s => s.Professor).AsQueryable();
            return View(cources.ToList());
        }

        public ActionResult LandScap()
        {
            ViewBag.Departments = db.Deparments.ToList();
            ViewBag.Pages = db.Pages.ToList();
            return View();
        }

        public ActionResult Page(int id)
        {
            ViewBag.Departments = db.Deparments.ToList();
            ViewBag.Pages = db.Pages.ToList();
            var page = db.Pages.FirstOrDefault(p => p.ID == id);
            if(page != null)
            {
                return View(page);
            }else
            {
                return HttpNotFound();
            }
        }


    }
}