using AdminPanelAndIndustry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanelAndIndustry.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection value)
        {
            //List<Contact> contacts = new List<Contact>();
            using (IndustryDBContext db = new IndustryDBContext())
            {
                var contact = new Contact()
                {
                    Name = value["name"],
                    Email = value["email"],
                    Subject = value["subject"],
                    Message = value["message"]
                };

                db.Contacts.Add(contact);
                db.SaveChanges();
            }
            return View();
        }



    }
}