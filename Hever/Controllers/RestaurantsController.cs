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
    public class RestaurantsController : Controller
    {
        private HeverDbContext db = new HeverDbContext();

        // GET: Restaurants
        public ActionResult Index()
        {
            ViewBag.restaurantTypeList = db.Restaurants.Select(r => r.RestaurantType).Distinct();
            ViewBag.areaList = db.Restaurants.Select(r => r.Area).Distinct();
            var currentUser = (Users)HttpContext.Session["user"];
            if (currentUser != null)
            {
                var userFromDb = db.Users.Find(currentUser.Id);
                ViewBag.Liked = userFromDb.LikedRestaurants;
            }
            return View(db.Restaurants.ToList());
        }

        // GET: Fabric/Search
        public ActionResult Search(string restaurantType = null, string area = null, bool kosher = false, bool accessible = false)
        {
            ViewBag.restaurantTypeList = db.Restaurants.Select(r => r.RestaurantType).Distinct();
            ViewBag.areaList = db.Restaurants.Select(r => r.Area).Distinct();

            var returnDataQurey = db.Restaurants.Select(r => r);

            if (kosher)
            {
                returnDataQurey = returnDataQurey.Where(r => r.IsKosher);
            }

            if (accessible)
            {
                returnDataQurey = returnDataQurey.Where(r => r.IsAccessible);
            }

            if (!string.IsNullOrEmpty(restaurantType))
            {
                returnDataQurey = returnDataQurey.Where(r => r.RestaurantType.Equals(restaurantType));
            }

            if (!string.IsNullOrEmpty(area))
            {
                returnDataQurey = returnDataQurey.Where(r => r.Area.Equals(area));
            }

            return View("Index", returnDataQurey.ToList());
        }


        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StreetAndNum,IsAccessible,IsKosher,RestaurantType,FacebookLink,CityId")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StreetAndNum,IsAccessible,IsKosher,RestaurantType,FacebookLink,CityId")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Restaurants/Like/5
        public ActionResult Like(int? id)
        {
            ViewBag.restaurantTypeList = db.Restaurants.Select(r => r.RestaurantType).Distinct();
            ViewBag.areaList = db.Restaurants.Select(r => r.Area).Distinct();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            var currentUser = (Users)HttpContext.Session["user"];
            if (currentUser != null)
            {
                var userFromDb = db.Users.Find(currentUser.Id);
                if (!userFromDb.LikedRestaurants.Contains(restaurant))
                {
                    userFromDb.LikedRestaurants.Add(restaurant);
                }
                else
                {
                    userFromDb.LikedRestaurants.Remove(restaurant);
                }
                db.SaveChanges();
                ViewBag.Liked = userFromDb.LikedRestaurants;
                return View("Index", db.Restaurants.ToList());
            }

            return RedirectToAction("Index", "Error", new { message = "you are not logged in" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
