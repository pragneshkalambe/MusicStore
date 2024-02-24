using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using TestStore.Models;

namespace TestStore.Controllers
{
    public class CartController : Controller
    {
        private TestStoreDbContext _db;

        public CartController()
        {
            _db = new TestStoreDbContext();
        }
        // GET: Cart
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AddToCart(int AlbumID)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                //Item item = new Item();
                //item.Album = _db.Albums.Find(AlbumID);
                //item.Quantity = 1;
                //cart.Add(item);
                cart.Add(new Item() { Album = _db.Albums.Find(AlbumID), Quantity = 1 });
                Session["cart"] = cart;

            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = IsInCart(AlbumID);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item() { Album = _db.Albums.Find(AlbumID), Quantity = 1 });
                }
                Session["cart"] = cart;

            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int AlbumID)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = IsInCart(AlbumID);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        public int IsInCart(int AlbumID)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Album.AlbumID == AlbumID)
                {
                    return i;
                }
            }
            return -1;


        }

        public ActionResult Shopping_Success()
        {
            return View();
        }

        //public PartialViewResult ShoppingCart()
        //{
        //    int total_item = 0;
        //    Cart cart = Session["Cart"] as Cart;
        //    if (cart!=null)
        //    {
        //        List<Item>)total_item = (List<Item>)Session["cart"];
        //    }

        //    return View();
        //}
        public ActionResult CheckOut(Customer customer)
        {
            //if ((List<Item>)Session["cart"]!=null)
            //{
            return RedirectToAction("Shopping_Success");

            //}
                


                //if (ModelState.IsValid)
                //{
                //    bool isValidEmp = _db.Customers.Any(e => e.Email.ToLower() == customer.Email && e.Password == customer.Password);

                //    if (isValidEmp)
                //    {
                //        //Set AuthCookie
                //        FormsAuthentication.SetAuthCookie(customer.CustomerID.ToString(), false);
                //        return RedirectToAction("Index", "Store");

                //    }
                //}

            }

        public ActionResult Payment()
        {

            return View();
        }
            
            //try
            //{
            //    Cart cart = Session["cart"] as Cart;
            //    Order _order = new Order();
            //    _order.OrderDate = DateTime.Now;
            //    _order.Customer.CodeCus = int.Parse(form["CodeCustomer"]);
            //    _order.Customer.Address = form["Address_Delivery"];
            //    _db.Orders.Add(_order);
            //    foreach (var item in (List<Item>)Session["cart"])
            //    {
            //        OrderDetails _orderDetails = new OrderDetails();
            //        _orderDetails.OrderID = _order.OrderID;
            //        _orderDetails.AlbumID = _order.Album.AlbumID;
            //        _orderDetails.Item.Album.Price = _order.Album.Price;
            //        _orderDetails.Item.Quantity = _order.Item.Quantity;
            //        _db.OrderDetails.Add(_orderDetails);

            //    }
            //    _db.SaveChanges();
            //    return RedirectToAction("Shopping_Success","Cart");


            //}
            //catch 
            //{
            //    return Content("Error Checkout.Check Information Of Customer");

            //}


        }

    }
