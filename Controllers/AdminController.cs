using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestStore.Models;

namespace TestStore.Controllers
{
    public class AdminController : Controller
    {
        private TestStoreDbContext _context;

        public AdminController()
        {
            _context = new TestStoreDbContext();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employee employee)
        {

            if (ModelState.IsValid)
            {
                bool isValidEmp = _context.Employees.Any(e => e.Email.ToLower() == employee.Email && e.Password == employee.Password);

                if (isValidEmp)
                {
                    //Set AuthCookie
                    FormsAuthentication.SetAuthCookie(employee.EmployeeID.ToString(), false);
                    return RedirectToAction("Index", "Store");

                }

            }
            ModelState.AddModelError("Error", "User Not Found Or Please Register");

            return View(employee);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}