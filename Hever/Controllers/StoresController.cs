﻿using System;
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
    public class StoresController : Controller
    {
        private HeverDbContext db = new HeverDbContext();
        private List<Store> curList;

        // GET: Stores
        public ActionResult Index()
        {
            var currentUser = (Users)HttpContext.Session["user"];
            if (currentUser == null)
            {
                return RedirectToAction("Index", "Error", new { message = "You are not logged in" });
            }

            ViewBag.storeTypeList = db.Stores.Select(s => s.StoreType).Distinct();
            ViewBag.areaList = db.Stores.Select(s => s.Area).Distinct();
            var userFromDb = db.Users.Find(currentUser.Id);
            ViewBag.Liked = userFromDb.LikedStores;

            return View(db.Stores.ToList());
        }

        // GET: Stores/Search
        public ActionResult Search(string storeType = null, string area = null, bool accessible = false)
        {
            var currentUser = (Users)HttpContext.Session["user"];
            if (currentUser == null)
            {
                return RedirectToAction("Index", "Error", new { message = "You are not logged in" });
            }

            ViewBag.storeTypeList = db.Stores.Select(s => s.StoreType).Distinct();
            ViewBag.areaList = db.Stores.Select(s => s.Area).Distinct();

            var returnDataQurey = db.Stores.Select(s => s);

            if (accessible)
            {
                returnDataQurey = returnDataQurey.Where(s => s.IsAccessible);
            }

            if (!string.IsNullOrEmpty(storeType))
            {
                returnDataQurey = returnDataQurey.Where(s => s.StoreType.Equals(storeType));
            }

            if (!string.IsNullOrEmpty(area))
            {
                returnDataQurey = returnDataQurey.Where(s => s.Area.Equals(area));
            }

            return View("Index", returnDataQurey.ToList());
        }


        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            var currentUser = (Users)HttpContext.Session["user"];
            if (currentUser == null)
            {
                return RedirectToAction("Index", "Error", new { message = "You are not logged in" });
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            var currentUser = (Users)HttpContext.Session["user"];
            if (currentUser == null || !currentUser.IsAdmin)
            {
                return RedirectToAction("Index", "Error");
            } 

            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FullAddress,Area,IsAccessible,StoreType")] Store store)
        {
            var currentUser = (Users)HttpContext.Session["user"];
            if (currentUser == null || !currentUser.IsAdmin)
            {
                return RedirectToAction("Index", "Error");
            }

            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(store);
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            var currentUser = (Users)HttpContext.Session["user"];
            if (currentUser == null || !currentUser.IsAdmin)
            {
                return RedirectToAction("Index", "Error");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FullAddress,Area,IsAccessible,StoreType")] Store store)
        {
            var currentUser = (Users)HttpContext.Session["user"];
            if (currentUser == null || !currentUser.IsAdmin)
            {
                return RedirectToAction("Index", "Error");
            }

            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            var currentUser = (Users)HttpContext.Session["user"];
            if (currentUser == null || !currentUser.IsAdmin)
            {
                return RedirectToAction("Index", "Error");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var currentUser = (Users)HttpContext.Session["user"];
            if (currentUser == null || !currentUser.IsAdmin)
            {
                return RedirectToAction("Index", "Error");
            }

            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Stores/Like/5
        public ActionResult Like(int? id)
        {
            ViewBag.storeTypeList = db.Stores.Select(s => s.StoreType).Distinct();
            ViewBag.areaList = db.Stores.Select(s => s.Area).Distinct();
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }

            var currentUser = (Users)HttpContext.Session["user"];
            if (currentUser != null)
            {
                var userFromDb = db.Users.Find(currentUser.Id);
                if (!userFromDb.LikedStores.Contains(store))
                {
                    userFromDb.LikedStores.Add(store);
                }
                else
                {
                    userFromDb.LikedStores.Remove(store);
                }
                db.SaveChanges();
                ViewBag.Liked = userFromDb.LikedStores;
                return View("Index", db.Stores.ToList());
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
