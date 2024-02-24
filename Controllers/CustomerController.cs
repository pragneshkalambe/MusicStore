using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using TestStore.Dto;
using TestStore.Models;

namespace TestStore.Controllers
{
    public class CustomerController : Controller
    {
        private TestStoreDbContext _db;
        private SqlConnection connection;

        public CustomerController()
        {
            _db = new TestStoreDbContext();
            string connStr = ConfigurationManager.ConnectionStrings["TestStoreDb"].ToString();
            connection = new SqlConnection(connStr);
        }
        // GET: Customer
        //public ActionResult Index()
        //{
        //    return View();
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Customer customer)
        {

            SqlCommand sqlCommand = new SqlCommand("dbo.sp_saveCustomerSignUp", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@FirstName", customer.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", customer.LastName);
            sqlCommand.Parameters.AddWithValue("@Address", customer.Address);
            sqlCommand.Parameters.AddWithValue("@Phone", customer.Phone);
            sqlCommand.Parameters.AddWithValue("@Email", customer.Email);
            sqlCommand.Parameters.AddWithValue("@PassWord", customer.Password);
            sqlCommand.Parameters.AddWithValue("@CodeCus", customer.CodeCus);

            sqlCommand.ExecuteNonQuery();
            connection.Close();
            ViewData["Message"] = "User Record " + customer.FirstName + " Is Saved Succesfully";


            return View();
        }
        //}
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account customer)
        {
            if (ModelState.IsValid)
            {
                bool isValidEmp = _db.Customers.Any(e => e.Email.ToLower() == customer.Email && e.Password == customer.Password);

                if (isValidEmp)
                {
                    //Set AuthCookie
                    FormsAuthentication.SetAuthCookie(customer.CustomerID.ToString(), false);
                    //return RedirectToAction("Shopping_Success", "Cart");
                    return RedirectToAction("Payment", "Cart");


                }

            }
            ModelState.AddModelError("Error", "User Not Found Or Please Register");

            return View(customer);
        }

            //if (ModelState.IsValid)
            //{
            //    bool isValidEmp = _db.Customers.Any(e => e.Email.ToLower() == customer.Email && e.Password == customer.Password);

            //    if (isValidEmp)
            //    {
            //        //Set AuthCookie
            //        FormsAuthentication.SetAuthCookie(customer.CustomerID.ToString(), false);
            //        return RedirectToAction("Shopping_Success","Cart");

            //    }

            //}
            //ModelState.AddModelError("Error", "User Not Found Or Please Register");

            //return View(customer);
        }

        //public ActionResult LogOut()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Login");
        //}
    }

    

