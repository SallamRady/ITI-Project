using ITIProject.Models;
using ITIProject.Models.DBFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Net;
using System.Net.Mail;

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
            return View(cources.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 6));
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
        public ActionResult Search(string SearchKeyWord,string derp = "test")
        {
            ViewBag.Departments = db.Deparments.ToList();
            ViewBag.Pages = db.Pages.ToList();
            if (derp == "Department")
            {
                var cources_d = db.Courses.Where(c => c.Department.Name.Contains(SearchKeyWord)).Include(s => s.Department).Include(s => s.Professor).AsQueryable();
                return View(cources_d.ToList());
            }
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


        public ActionResult Profile()
        {
            ViewBag.Departments = db.Deparments.ToList();
            ViewBag.Pages = db.Pages.ToList();
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            return View(currentUser);
        }

        
        public ActionResult Register()
        {
            ViewBag.Roles = new SelectList(db.Roles.ToList(), "Name", "Name");
            return View();
        }


        public ActionResult JoinACourse(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home", new { area = "Site" });
            }
            ViewBag.Departments = db.Deparments.ToList();
            ViewBag.Pages = db.Pages.ToList();
            var course = db.Courses.FirstOrDefault(c => c.ID == id);
            if(course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [Authorize]
        public ActionResult PayCourse(int? id)
        {
            ViewBag.Departments = db.Deparments.ToList();
            ViewBag.Pages = db.Pages.ToList();
            return View();
        }
        
        [Authorize]
        public ActionResult Lession(int? id)
        {
            ViewBag.Departments = db.Deparments.ToList();
            ViewBag.Pages = db.Pages.ToList();
            var lession = db.Lessions.FirstOrDefault(l => l.ID == id);
            if(lession == null)
            {
                return HttpNotFound();
            }
            return View(lession);
        }
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string receiver, string subject, string message)
        {
            try
            {
                    var senderEmail = new MailAddress("sallamrady@gmail.com", "sallam");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "#Sallam@501@rady#";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home", new { area = "Site" });
        }


    }
}