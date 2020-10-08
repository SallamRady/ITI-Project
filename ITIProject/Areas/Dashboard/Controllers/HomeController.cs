using ITIProject.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace ITIProject.Areas.Dashboard.Controllers
{
    [Authorize(Roles ="Admins,Professors,Managers")]
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Dashboard/Home
        public ActionResult Index()
        {
            ViewBag.CoursesCount        = db.Courses.Count();
            ViewBag.MessagesCount       = db.Messages.Count();
            ViewBag.ProfessorsCount     = db.Professors.Count();
            ViewBag.StudentsCount       = db.Students.Count();
            ViewBag.DepartmentsCount    = db.Deparments.Count();
            ViewBag.RolesCount          = db.Roles.Count();
            ViewBag.PagesCount          = db.Pages.Count();
            ViewBag.FollowersCount      = 0;
            ViewBag.Last3Messages       = db.Messages.OrderByDescending(x => x.ID).Take(3).ToList();
            return View();
        }


        //To Login. any one can enter.
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}