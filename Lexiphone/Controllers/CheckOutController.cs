using Lexiphone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lexiphone.Controllers
{
    [Authorize]
    public class CheckOutController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        const string PromoCode = "FREE";
        // GET: CheckOut
        //public ActionResult AddressAndPayment()
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult AddressAndPayment(Order myOrder)
        {
            var order = new Order();
            TryValidateModel(order);
            try
            {
                //if(string.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase) == false)
                //{
                //    return View(order);
                //}
                //else
                //{
                order.Username = User.Identity.Name;
                order.OrderDate = DateTime.Now;
                order.Address = myOrder.Address;
                order.City = myOrder.City;
                order.Country = myOrder.Country;
                order.Country = myOrder.Email;
                order.FirstName = myOrder.FirstName;
                order.LastName = myOrder.LastName;
                order.Phone = myOrder.Phone;
                order.PostalCode = myOrder.PostalCode;
                order.PostalCode = myOrder.State;
                
                db.Orders.Add(order);
                db.SaveChanges();
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);
                    return RedirectToAction("Complete", new { id = order.OrderId });
                //}
            }
            catch
            {
                return View(order);
            }
        }
        public ActionResult Complete(int id)
        {
            
            bool isValid = db.Orders.Any(o => o.OrderId == id && o.Username == User.Identity.Name);
            if (isValid)
            {
                ViewBag.id = id;
                return View();
            }
            else
            {
                return View("Error");
            }
        }
    }
}