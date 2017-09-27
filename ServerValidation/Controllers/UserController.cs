using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServerValidation.Models;
using System.Text.RegularExpressions;

namespace ServerValidation.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ServerValidation.Models.User model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Name is required");
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(model.Email))
                {
                    ModelState.AddModelError("Email", "Email is not valid");
                }
            }
            else
            {
                ModelState.AddModelError("Email", "Email is required");
            }
            if (string.IsNullOrEmpty(model.Age))
            {
                ModelState.AddModelError("Age", "Age is required");
            }
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Address", "Address is required and it should not exceed 255 characters");
            }
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Contact", "Contact is required");
            }

            if (ModelState.IsValid)
            {
                ViewBag.Name = model.Name;
                ViewBag.Email = model.Email;
                ViewBag.Age = model.Age;
                ViewBag.Address = model.Address;
                ViewBag.Contact = model.Contact;
            }
            return View(model);
        }
    }
}