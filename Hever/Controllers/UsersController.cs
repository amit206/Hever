using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hever.Models;

namespace Hever.Controllers
{
    public class UsersController : Controller
    {
        private HeverDbContext db = new HeverDbContext();

        // GET: Users
        public ActionResult Index()
        {
            var currentUser = ((Users)HttpContext.Session["user"]);
            return View(db.Users.ToList());
            //Todo:
            /*if (currentUser != null)
            {
                var users = db.Users.Select(s => s);
                if (!currentUser.IsManager)
                {
                    users = users.Where(u => u.Id == currentUser.Id);
                //} 
                return View(users.Include(r => r.UserName).ToList());
            }
            return RedirectToAction("Index", "Error");*/
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password,IsAdmine,CardNumber,CardExpirationDate,Cvs")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,IsAdmine,CardNumber,CardExpirationDate,Cvs")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userName, string password)
        {
            var userInDataBase = db.Users.Where(u =>
                        u.UserName.Equals(userName, System.StringComparison.Ordinal) &&
                        u.Password.Equals(password, System.StringComparison.Ordinal)).SingleOrDefault();
            if (userInDataBase != null)
            {
                System.Web.HttpContext.Current.Session["user"] = userInDataBase;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrMsg = "User name or password are incorrect.";
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Users/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userName, string password)
        {
            var userInDataBase = db.Users.Where(u => u.UserName.Equals(userName, System.StringComparison.Ordinal) &&
                                                 u.Password.Equals(password, System.StringComparison.Ordinal)).SingleOrDefault();
                
            if (userInDataBase != null)
            {
                System.Web.HttpContext.Current.Session["user"] = userInDataBase;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrMsg = "User name or password are incorrect.";
            return View();
        }

        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session["User"] = null;
            return RedirectToAction("Login");
        }
    }
}
