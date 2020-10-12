using ITIProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITIProject.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdminsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Dashboard/Admins
        public ActionResult Index()
        {
            
            var admins = db.Users.Where(a=>a.Role == "Admins").ToList();
            return View(admins);
        }
    }
}