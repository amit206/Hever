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
            return View(db.Users.ToList());
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
            var currentUser = ((Users)HttpContext.Session["user"]);
            if (currentUser == null)
            {
                return View();
            }
            else
            {
                if (currentUser.IsAdmin)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Error", new { message = "you are already logged in" });
                }
            }
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password")] Users user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Where(c => c.UserName.Equals(user.UserName)).Count() > 0)
                {
                    ViewBag.ErrMsg = "User name already exists, please try again";
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    if (System.Web.HttpContext.Current.Session["user"] == null)
                    {
                        System.Web.HttpContext.Current.Session["user"] = user;
                        return RedirectToAction("Index", "Stores");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(user);
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

        // GET: Users/MakeAdmine/5
        public ActionResult MakeAdmin(bool isAdmin, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Users user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            user.IsAdmin = !isAdmin;
            db.SaveChanges();

            return RedirectToAction("Index");
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

        // GET: Users/Search
        public ActionResult Search(string username = null, string isAdmin = "dont filter")
        {
            var returnDataQurey = db.Users.Select(u => u);

            if (isAdmin != "dont filter")
            {
                bool admin = isAdmin.Equals("True");
                returnDataQurey = returnDataQurey.Where(r => r.IsAdmin == admin);
            }

            if (!string.IsNullOrEmpty(username))
            {
                returnDataQurey = returnDataQurey.Where(u => u.UserName.Contains(username));
            }

            return View("Index", returnDataQurey.ToList());
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
                return RedirectToAction("Index", "Home", new { id = userInDataBase.Id });
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
