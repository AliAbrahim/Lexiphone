using Lexiphone.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lexiphone.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        ApplicationDbContext ctx;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public RoleController()
        {
            ctx = new ApplicationDbContext();
        }
        // GET: Role
        public ActionResult Index()
        {
            var roles = ctx.Roles.ToList();
            return View(roles);
        }
        public ActionResult UsersList()
        {
            var userList = ctx.Users.ToList();
            return View(userList);
        }


        // GET: Role/Create
        public ActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            try
            {
                // TODO: Add insert logic here
                ctx.Roles.Add(Role);
                ctx.SaveChanges();

                return RedirectToAction("AssignRoleToUser", "Role");
            }
            catch
            {
                return View(Role);
            }
        }
        public ActionResult AssignRoleToUser()
        {
            ViewBag.Name = new SelectList(ctx.Roles.ToList(), "Name", "Name");
            ViewBag.UserName = new SelectList(ctx.Users.ToList(), "UserName", "UserName");
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AssignRoleToUser(RegisterViewModel model, ApplicationUser user)
        {
            var userId = ctx.Users.Where(i => i.UserName == user.UserName).Select(c => c.Id);
            string updateId = "";
            foreach (var i in userId)
            {
                updateId = i.ToString();
            }
            await (this.UserManager.AddToRoleAsync(updateId, model.Name));
            return RedirectToAction("Index", "Home");
        }


        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IdentityRole Role)
        {
            try
            {
                // TODO: Add delete logic here
                ctx.Roles.Remove(Role);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
