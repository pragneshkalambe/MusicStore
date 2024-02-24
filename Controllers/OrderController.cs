using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestStore.Models;

namespace TestStore.Controllers
{
    public class OrderController : Controller
    {
        [BindProperty]
        public OrderEntity _OrderDetails { get; set; }
      
        // GET: Order
        public IActionResult Index()
        {

            return (IActionResult)View();
        }

        public IActionResult InitiateOrder()
        {
            string secret = "fqgX80Wfits0fbXEMIIUWWZl";
            string key = "rzp_test_ixMffEQ2g1hYGs";

            Random _random = new Random();
            string TransactionId = _random.Next(0,10000).ToString();



            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount",Convert.ToDecimal(_OrderDetails.TotalAmount)*100); // this amount should be same as transaction amount
            input.Add("currency", "INR");
            input.Add("receipt",TransactionId);


            RazorpayClient client = new RazorpayClient(key, secret);
            Razorpay.Api.Order order = client.Order.Create(input);

            ViewBag.orderid = order["id"].ToString();

            return (IActionResult)View("Payment",_OrderDetails);
        }


    }
}