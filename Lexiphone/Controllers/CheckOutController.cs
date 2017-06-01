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
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddressAndPayment(Order myOrder)
        {
            var order = new Order();
            TryValidateModel(order);
            try
            {
               
                order.Username = User.Identity.Name;
                order.OrderDate = DateTime.Now;
                order.FirstName = myOrder.FirstName;
                order.LastName = myOrder.LastName;
                order.Phone = myOrder.Phone;
                order.PostalCode = myOrder.PostalCode;
                order.State = myOrder.State;
                order.Email = myOrder.Email;
                order.Address = myOrder.Address;
                order.City = myOrder.City;
                order.Country = myOrder.Country;
                db.Orders.Add(order);
                db.SaveChanges();

                var cart = ShoppingCart.GetCart(this.HttpContext);
                order.Total = cart.GetTotal();
                cart.CreateOrder(order);
                db.SaveChanges();

                return RedirectToAction("Complete", new { id = order.OrderId, total=order.Total, time=order.OrderDate });
                //}
            }
            catch
            {
                return View(order);
            }
        }
        public ActionResult Complete(int id ,decimal total, DateTime time)
        {
            bool isValid = db.Orders.Any(o => o.OrderId == id && o.Username == User.Identity.Name);
            if (isValid)
            {
                ViewBag.id = id;
                ViewBag.total = total;
                ViewBag.time = time;
                return View();
            }
            else
            {
                return View("Error");
            }
        }
    }
}