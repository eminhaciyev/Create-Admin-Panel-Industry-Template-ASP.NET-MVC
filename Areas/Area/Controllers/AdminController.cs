using AdminPanelAndIndustry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanelAndIndustry.Areas.Area.Controllers
{
    public class AdminController : Controller
    {
        // GET: Area/Admin
        public ActionResult AdminPanel()
        {
            if (Session["username"] != null)
            {
                //return RedirectToAction("AdminPanel");
                return View();
            }
            else
            {
                return Content("You can't LogIn.Only must enter ADMIN!!");
            }
        }
        [HttpGet]
        public ActionResult AdminContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminContact(FormCollection value)
        {

            using (IndustryDBContext db = new IndustryDBContext())
            {
                var contact = new Contact();
                contact.Name = value["name"];
                contact.Email = value["email"];
                contact.Subject = value["subject"];
                contact.Message = value["messages"];

                db.Contacts.Add(contact);
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var Username = username;
            var Password = password;
            //var s = Session["Username"];
            //if (s != null)
            //{
            //    Session.Clear();
            //}

            if (Username == "admin" && Password == "admin")
            {
                Session.Add("username", "admin");

                return RedirectToAction("AdminPanel");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            if (Session["username"] != null)
            {
                Session.Abandon();
                return RedirectToAction("Login");
            }
            else
            {
                return Content("What is something wrong! Please check your code!");
            }

            //return View();
        }

    }
}